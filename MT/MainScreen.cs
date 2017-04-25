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
        private DataSet datasetMT;
        private SqlDataAdapter productItemsAdapter;
        private SqlDataAdapter orderRowsAdapter;
        private SqlDataAdapter customersAdapter;
        private SqlDataAdapter ordersAdapter;
        private SqlConnection connectionMT;
        private SqlDataAdapter productsAdapter;
        private SqlDataAdapter colorsAdapter;
        private SqlDataAdapter packingsAdapter;

        private void Reset()
        {
            this.orderDate.ResetText();
            this.orderingCompanyComboBox.ResetText();
            this.orderRowsDataGrid.RowCount = 1;
        }

        private void RecordOrderInDatabase()
        {
            DataRow order = this.datasetMT.Tables["Orders"].NewRow();

            order["CustomerId"] = this.orderingCompanyComboBox.SelectedValue;
            order["Date"] = this.orderDate.Value;

            this.datasetMT.Tables["Orders"].Rows.Add(order);

            SqlCommandBuilder builder = new SqlCommandBuilder(this.ordersAdapter);
            builder.GetInsertCommand();

            this.ordersAdapter.Update(this.datasetMT, "Orders");

            foreach (DataGridViewRow row in this.orderRowsDataGrid.Rows)
            {
                DataRow orderRow = this.datasetMT.Tables["OrderRows"].NewRow();
                orderRow["OrderId"] = this.datasetMT.Tables["Orders"].Rows.Count;

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

                cmd.Connection = this.connectionMT;

                orderRow["ProductItemId"] = cmd.ExecuteScalar();
                orderRow["Quantity"] = row.Cells[4].Value;

                this.datasetMT.Tables["OrderRows"].Rows.Add(orderRow);
                builder = new SqlCommandBuilder(this.orderRowsAdapter);
                builder.GetInsertCommand();

                this.orderRowsAdapter.Update(this.datasetMT, "OrderRows");
            }
        }

        public MainScreen()
        {
            try
            {
                this.connectionMT =
                   new SqlConnection(
                       @"Data Source=(local);Database=MT;Integrated Security=true;"
                   );

                InitializeComponent();

                string queryCustomers = "SELECT * FROM Customers";
                this.customersAdapter = new SqlDataAdapter(queryCustomers, connectionMT);
                string queryOrders = "SELECT * FROM Orders";
                this.ordersAdapter = new SqlDataAdapter(queryOrders, connectionMT);
                string queryOrderRows = "SELECT * FROM OrderRows";
                this.orderRowsAdapter = new SqlDataAdapter(queryOrderRows, connectionMT);
                string queryProducts = "SELECT * FROM Products";
                this.productsAdapter = new SqlDataAdapter(queryProducts, connectionMT);
                string queryProductItems = "SELECT * FROM ProductItems";
                this.productItemsAdapter = new SqlDataAdapter(queryProductItems, connectionMT);
                string queryColors = "SELECT * FROM Colors";
                this.colorsAdapter = new SqlDataAdapter(queryColors, connectionMT);
                string queryPackings = "SELECT * FROM Packings";
                this.packingsAdapter = new SqlDataAdapter(queryPackings, connectionMT);

                connectionMT.Open();
                this.datasetMT = new DataSet();
                customersAdapter.Fill(this.datasetMT, "Customers");
                ordersAdapter.Fill(this.datasetMT, "Orders");
                orderRowsAdapter.Fill(this.datasetMT, "OrderRows");
                productsAdapter.Fill(this.datasetMT, "Products");
                productItemsAdapter.Fill(this.datasetMT, "ProductItems");
                colorsAdapter.Fill(this.datasetMT, "Colors");
                packingsAdapter.Fill(this.datasetMT, "Packings");

                orderingCompanyComboBox.DataSource = this.datasetMT.Tables["Customers"];
                orderingCompanyComboBox.DisplayMember = "Name";
                orderingCompanyComboBox.ValueMember = "Id";

                this.OrderRowsArticleNo.DataSource = this.datasetMT.Tables["Products"];
                this.OrderRowsArticleNo.DisplayMember = "ArticleNumber";
                this.OrderRowsArticleNo.ValueMember = "Id";

                this.OrderRowsColor.DataSource = this.datasetMT.Tables["Colors"];
                this.OrderRowsColor.DisplayMember = "Color";
                this.OrderRowsColor.ValueMember = "Id";

                this.OrderRowsPacking.DataSource = this.datasetMT.Tables["Packings"];
                this.OrderRowsPacking.DisplayMember = "Packing";
                this.OrderRowsPacking.ValueMember = "Id";
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

        private void orderRowsDataGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                DataGridView senderItem = (DataGridView)sender;
                var articleNumber = senderItem.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;   //this.orderRowsDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                cmd.CommandText = "SELECT ProductName FROM Products WHERE ArticleNumber=" +
                    articleNumber;
                cmd.Connection = this.connectionMT;
                var productName = cmd.ExecuteScalar();

                this.orderRowsDataGrid.Rows[e.RowIndex].Cells[2].Value = productName;
            }
        }

        private void orderRowsDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }
    }
}
