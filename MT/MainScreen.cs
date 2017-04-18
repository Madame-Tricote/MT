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
using System.Data.OleDb;

namespace MT
{
    public partial class MainScreen : Form
    {
        private SqlDataAdapter productItemsAdapter;
        private SqlDataAdapter orderRowsAdapter;

        private DataSet DatasetMT { get; set; }
        private SqlDataAdapter CustomersAdapter { get; set; }
        private SqlDataAdapter OrdersAdapter { get; set; }
        private SqlConnection ConnectionMT { get; set; }

        private void Reset()
        {
            this.orderDate.ResetText();
            this.orderingCompanyComboBox.ResetText();
            this.orderRowsDataGrid.RowCount = 1;
        }

        private void RecordOrderInDatabase()
        {
            DataRow order = this.DatasetMT.Tables["Orders"].NewRow();

            order["CustomerId"] = this.orderingCompanyComboBox.SelectedValue;
            order["Date"] = this.orderDate.Value;

            this.DatasetMT.Tables["Orders"].Rows.Add(order);

            SqlCommandBuilder builder = new SqlCommandBuilder(this.OrdersAdapter);
            builder.GetInsertCommand();

            this.OrdersAdapter.Update(this.DatasetMT, "Orders");

            foreach (DataGridViewRow row in this.orderRowsDataGrid.Rows)
            {
                DataRow orderRow = this.DatasetMT.Tables["OrderRows"].NewRow();
                orderRow["OrderId"] = this.DatasetMT.Tables["Orders"].Rows.Count;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                var selectedProduct = row.Cells[0].Value;
                var selectedColor = row.Cells[1].Value;
                var selectedPacking = row.Cells[3].Value;

                if (selectedProduct==null)
                {
                    break;
                }

                cmd.CommandText = "SELECT Id FROM ProductItems WHERE ProductId = " + selectedProduct.ToString() + 
                    " AND ColorId = " + selectedColor.ToString() +
                    " AND PackingId = " + selectedPacking.ToString();

                cmd.Connection = this.ConnectionMT;

                orderRow["ProductItemId"] = cmd.ExecuteScalar();
                orderRow["Quantity"] = row.Cells[4].Value;

                this.DatasetMT.Tables["OrderRows"].Rows.Add(orderRow);
                builder = new SqlCommandBuilder(this.orderRowsAdapter);
                builder.GetInsertCommand();

                this.orderRowsAdapter.Update(this.DatasetMT, "OrderRows");

            }
        }

        public MainScreen()
        {

            try
            {
                this.ConnectionMT =
                   new SqlConnection(
                       @"Data Source=(local);Database=MT;Integrated Security=true;"
                   );

                InitializeComponent();

                string queryCustomers = "SELECT * FROM Customers";
                this.CustomersAdapter = new SqlDataAdapter(queryCustomers, ConnectionMT);
                string queryOrders = "SELECT * FROM Orders";
                this.OrdersAdapter = new SqlDataAdapter(queryOrders, ConnectionMT);
                string queryOrderRows = "SELECT * FROM OrderRows";
                this.orderRowsAdapter = new SqlDataAdapter(queryOrderRows, ConnectionMT);
                string queryProducts = "SELECT * FROM Products";
                SqlDataAdapter productsAdapter = new SqlDataAdapter(queryProducts, ConnectionMT);
                string queryProductItems = "SELECT * FROM ProductItems";
                this.productItemsAdapter = new SqlDataAdapter(queryProductItems, ConnectionMT);
                string queryColors = "SELECT * FROM Colors";
                SqlDataAdapter colorsAdapter = new SqlDataAdapter(queryColors, ConnectionMT);
                string queryPackings = "SELECT * FROM Packings";
                SqlDataAdapter packingsAdapter = new SqlDataAdapter(queryPackings, ConnectionMT);

                ConnectionMT.Open();
                this.DatasetMT = new DataSet();
                CustomersAdapter.Fill(this.DatasetMT, "Customers");
                OrdersAdapter.Fill(this.DatasetMT, "Orders");
                orderRowsAdapter.Fill(this.DatasetMT, "OrderRows");
                productsAdapter.Fill(this.DatasetMT, "Products");
                productItemsAdapter.Fill(this.DatasetMT, "ProductItems");
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

                //this.ConnectionMT.Close();
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.Message, ex.HResult.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.RecordOrderInDatabase();
            this.Reset();
        }
    }
}
