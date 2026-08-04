using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repositories;
namespace ProductApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repository;
    public ProductsController(ProductRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _repository.GetAll();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _repository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        _repository.Add(product);
        return Ok(product);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        var existingProduct = _repository.GetById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Category = product.Category;
        _repository.Update(existingProduct);
        return Ok(existingProduct);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _repository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        _repository.Delete(product);
        return Ok("Product deleted successfully");
    }
}