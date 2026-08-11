using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
namespace WinFormsApp3
{
    public partial class MainForm : Form
    {
        private ProductsContext? dbContext;

        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dbContext = new ProductsContext();
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();
            this.dbContext.Categories.Load();
            this.categoryBindingSource.DataSource =
                this.dbContext.Categories.Local.ToBindingList();
            this.dataGridViewCategories.SelectionChanged +=
                dataGridViewCategories_SelectionChanged;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.dbContext?.Dispose();
            this.dbContext = null;
        }
        private void dataGridViewCategories_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (this.dbContext == null ||
                this.dataGridViewCategories.CurrentRow == null)
            {
                return;
            }
            var category =
                this.dataGridViewCategories.CurrentRow.DataBoundItem
                as Category;
            if (category != null)
            {
                this.dbContext.Entry(category)
                              .Collection(x => x.Products)
                              .Load();

                productBindingSource.DataSource = category.Products;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.dbContext!.SaveChanges();
            this.dataGridViewCategories.Refresh();
            this.dataGridViewProducts.Refresh();
        }

        private void dataGridViewCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}