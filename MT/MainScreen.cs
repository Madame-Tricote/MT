using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MT
{
    public partial class MainScreen : Form
    {
        private DataSet DatasetMT { get; set; }

        private void RecordOrderInDatabase()
        {
            DataRow order = this.DatasetMT.Tables["Orders"].NewRow();
            order["CustomerId"] = this.orderingCompanyComboBox.SelectedItem;
            order["Date"] = this.orderDate.Value;

            this.DatasetMT.Tables["Orders"].Rows.Add(order);

            foreach (DataGridViewRow row in this.orderRowsDataGrid.Rows)
            {
                DataRow orderRow = this.DatasetMT.Tables["OrderRows"].NewRow();
                orderRow["OrderId"] = 
            }
        }

        public MainScreen()
        {
            InitializeComponent();

            using (SqlConnection conn = 
                new SqlConnection(
                    @"Data Source=(local);Database=MT;User ID=MT-User;Password=31415;Integrated Security=true;
"
                ))
            {
                try
                {
                    string queryCustomers = "SELECT * FROM Customers";
                    SqlDataAdapter customersAdapter = new SqlDataAdapter(queryCustomers, conn);
                    string queryOrders = "SELECT * FROM Orders";
                    SqlDataAdapter ordersAdapter = new SqlDataAdapter(queryOrders, conn);
                    string queryOrderRows = "SELECT * FROM OrderRows";
                    SqlDataAdapter orderRowsAdapter = new SqlDataAdapter(queryOrderRows, conn);
                    string queryProducts = "SELECT * FROM Products";
                    SqlDataAdapter productsAdapter = new SqlDataAdapter(queryProducts, conn);
                    string queryColors = "SELECT * FROM Colors";
                    SqlDataAdapter colorsAdapter = new SqlDataAdapter(queryColors, conn);
                    string queryPackings = "SELECT * FROM Packings";
                    SqlDataAdapter packingsAdapter = new SqlDataAdapter(queryPackings, conn);

                    conn.Open();
                    this.DatasetMT = new DataSet();
                    customersAdapter.Fill(this.DatasetMT, "Customers");
                    ordersAdapter.Fill(this.DatasetMT, "Orders");
                    orderRowsAdapter.Fill(this.DatasetMT, "OrderRows");
                    productsAdapter.Fill(this.DatasetMT, "Products");
                    colorsAdapter.Fill(this.DatasetMT, "Colors");
                    packingsAdapter.Fill(this.DatasetMT, "Packings");

                    orderingCompanyComboBox.DataSource = this.DatasetMT.Tables["Customers"];
                    orderingCompanyComboBox.DisplayMember = "Name";
                    orderingCompanyComboBox.ValueMember = "Id";

                    this.OrderRowsArticleNo.DataSource = this.DatasetMT.Tables["Products"];
                    this.OrderRowsArticleNo.DisplayMember = "ArticleNumber";
                    this.OrderRowsArticleNo.ValueMember = "Id";

                    this.OrderRowsColor.DataSource = this.DatasetMT.Tables["Colors"];
                    this.OrderRowsColor.DisplayMember = "Color";
                    this.OrderRowsColor.ValueMember = "Id";

                    this.OrderRowsPacking.DataSource = this.DatasetMT.Tables["Packings"];
                    this.OrderRowsPacking.DisplayMember = "Packing";
                    this.OrderRowsPacking.ValueMember = "Id";

                    //this.OrderRowsColor
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
