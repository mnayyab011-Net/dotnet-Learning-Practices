using ProductApi.Data;
using ProductApi.Models;
namespace ProductApi.Repositories;
public class ProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }
    public Product? GetById(int id)
    {
        return _context.Products.Find(id);
    }
    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}