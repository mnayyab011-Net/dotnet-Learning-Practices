namespace WinFormsApp3
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            buttonSave = new Button();
            categoryBindingSource = new BindingSource(components);
            dataGridViewCategories = new DataGridView();
            categoryIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewProducts = new DataGridView();
            productIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            categoryIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            categoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)categoryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(306, 188);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(172, 40);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // categoryBindingSource
            // 
            categoryBindingSource.DataSource = typeof(Category);
            // 
            // dataGridViewCategories
            // 
            dataGridViewCategories.AutoGenerateColumns = false;
            dataGridViewCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategories.Columns.AddRange(new DataGridViewColumn[] { categoryIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            dataGridViewCategories.DataSource = categoryBindingSource;
            dataGridViewCategories.Location = new Point(77, 32);
            dataGridViewCategories.Name = "dataGridViewCategories";
            dataGridViewCategories.Size = new Size(240, 150);
            dataGridViewCategories.TabIndex = 3;
            dataGridViewCategories.CellContentClick += dataGridViewCategories_CellContentClick;
            // 
            // categoryIdDataGridViewTextBoxColumn
            // 
            categoryIdDataGridViewTextBoxColumn.DataPropertyName = "CategoryId";
            categoryIdDataGridViewTextBoxColumn.HeaderText = "CategoryId";
            categoryIdDataGridViewTextBoxColumn.Name = "categoryIdDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.AutoGenerateColumns = false;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Columns.AddRange(new DataGridViewColumn[] { productIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn1, categoryIdDataGridViewTextBoxColumn1, categoryDataGridViewTextBoxColumn });
            dataGridViewProducts.DataSource = productBindingSource;
            dataGridViewProducts.Location = new Point(486, 32);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.Size = new Size(240, 150);
            dataGridViewProducts.TabIndex = 4;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            productIdDataGridViewTextBoxColumn.DataPropertyName = "ProductId";
            productIdDataGridViewTextBoxColumn.HeaderText = "ProductId";
            productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // categoryIdDataGridViewTextBoxColumn1
            // 
            categoryIdDataGridViewTextBoxColumn1.DataPropertyName = "CategoryId";
            categoryIdDataGridViewTextBoxColumn1.HeaderText = "CategoryId";
            categoryIdDataGridViewTextBoxColumn1.Name = "categoryIdDataGridViewTextBoxColumn1";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Product);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewProducts);
            Controls.Add(dataGridViewCategories);
            Controls.Add(buttonSave);
            Name = "MainForm";
            Text = "Products and Categories";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)categoryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private Button buttonSave;
        private BindingSource categoryBindingSource;
        private DataGridView dataGridViewCategories;
        private DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridView dataGridViewProducts;
        private DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private BindingSource productBindingSource;
    }
}
