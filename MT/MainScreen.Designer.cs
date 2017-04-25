namespace MT
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.orderHeading = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.orderNumberField = new System.Windows.Forms.Label();
            this.orderDateLabel = new System.Windows.Forms.Label();
            this.orderDate = new System.Windows.Forms.DateTimePicker();
            this.companyLabel = new System.Windows.Forms.Label();
            this.orderingCompanyComboBox = new System.Windows.Forms.ComboBox();
            this.orderRowsDataGrid = new System.Windows.Forms.DataGridView();
            this.OrderRowsArticleNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderRowsColor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderRowsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderRowsPacking = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderRowsQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderRowsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // orderHeading
            // 
            this.orderHeading.AutoSize = true;
            this.orderHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderHeading.Location = new System.Drawing.Point(300, 99);
            this.orderHeading.Name = "orderHeading";
            this.orderHeading.Size = new System.Drawing.Size(104, 29);
            this.orderHeading.TabIndex = 0;
            this.orderHeading.Text = "ORDER";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(289, 153);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(30, 17);
            this.numberLabel.TabIndex = 1;
            this.numberLabel.Text = "No.";
            // 
            // orderNumberField
            // 
            this.orderNumberField.AutoSize = true;
            this.orderNumberField.Location = new System.Drawing.Point(341, 153);
            this.orderNumberField.Name = "orderNumberField";
            this.orderNumberField.Size = new System.Drawing.Size(72, 17);
            this.orderNumberField.TabIndex = 2;
            this.orderNumberField.Text = "<number>";
            // 
            // orderDateLabel
            // 
            this.orderDateLabel.AutoSize = true;
            this.orderDateLabel.Location = new System.Drawing.Point(473, 152);
            this.orderDateLabel.Name = "orderDateLabel";
            this.orderDateLabel.Size = new System.Drawing.Size(42, 17);
            this.orderDateLabel.TabIndex = 3;
            this.orderDateLabel.Text = "Date:";
            // 
            // orderDate
            // 
            this.orderDate.Location = new System.Drawing.Point(545, 152);
            this.orderDate.Name = "orderDate";
            this.orderDate.Size = new System.Drawing.Size(200, 22);
            this.orderDate.TabIndex = 4;
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Location = new System.Drawing.Point(43, 219);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(129, 17);
            this.companyLabel.TabIndex = 5;
            this.companyLabel.Text = "Ordering company:";
            // 
            // orderingCompanyComboBox
            // 
            this.orderingCompanyComboBox.FormattingEnabled = true;
            this.orderingCompanyComboBox.Location = new System.Drawing.Point(203, 216);
            this.orderingCompanyComboBox.Name = "orderingCompanyComboBox";
            this.orderingCompanyComboBox.Size = new System.Drawing.Size(551, 24);
            this.orderingCompanyComboBox.TabIndex = 6;
            // 
            // orderRowsDataGrid
            // 
            this.orderRowsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderRowsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderRowsArticleNo,
            this.OrderRowsColor,
            this.OrderRowsName,
            this.OrderRowsPacking,
            this.OrderRowsQuantity});
            this.orderRowsDataGrid.Location = new System.Drawing.Point(46, 282);
            this.orderRowsDataGrid.Name = "orderRowsDataGrid";
            this.orderRowsDataGrid.RowTemplate.Height = 24;
            this.orderRowsDataGrid.Size = new System.Drawing.Size(1075, 150);
            this.orderRowsDataGrid.TabIndex = 7;
            this.orderRowsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.orderRowsDataGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderRowsDataGrid_CellLeave);
            this.orderRowsDataGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.orderRowsDataGrid_CellValidating);
            // 
            // OrderRowsArticleNo
            // 
            this.OrderRowsArticleNo.HeaderText = "Article No.";
            this.OrderRowsArticleNo.Name = "OrderRowsArticleNo";
            // 
            // OrderRowsColor
            // 
            this.OrderRowsColor.HeaderText = "Color";
            this.OrderRowsColor.Name = "OrderRowsColor";
            // 
            // OrderRowsName
            // 
            this.OrderRowsName.HeaderText = "Product Name";
            this.OrderRowsName.Name = "OrderRowsName";
            this.OrderRowsName.ReadOnly = true;
            this.OrderRowsName.Width = 300;
            // 
            // OrderRowsPacking
            // 
            this.OrderRowsPacking.HeaderText = "Packing";
            this.OrderRowsPacking.Name = "OrderRowsPacking";
            // 
            // OrderRowsQuantity
            // 
            this.OrderRowsQuantity.HeaderText = "Quantity";
            this.OrderRowsQuantity.Name = "OrderRowsQuantity";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1138, 412);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 539);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.orderRowsDataGrid);
            this.Controls.Add(this.orderingCompanyComboBox);
            this.Controls.Add(this.companyLabel);
            this.Controls.Add(this.orderDate);
            this.Controls.Add(this.orderDateLabel);
            this.Controls.Add(this.orderNumberField);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.orderHeading);
            this.Name = "MainScreen";
            this.Text = "Order Form";
            ((System.ComponentModel.ISupportInitialize)(this.orderRowsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label orderHeading;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label orderNumberField;
        private System.Windows.Forms.Label orderDateLabel;
        private System.Windows.Forms.DateTimePicker orderDate;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.ComboBox orderingCompanyComboBox;
        private System.Windows.Forms.DataGridView orderRowsDataGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn OrderRowsArticleNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn OrderRowsColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderRowsName;
        private System.Windows.Forms.DataGridViewComboBoxColumn OrderRowsPacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderRowsQuantity;
        private System.Windows.Forms.Button SaveButton;
    }
}

