namespace WinFormsApp3
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = "String.Empty";
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
