using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new List<object>
        {
            new
            {
                Id = 1,
                Name = "Laptop",
                Price = 80000
            },

            new
            {
                Id = 2,
                Name = "Mobile",
                Price = 50000
            },

            new
            {
                Id = 3,
                Name = "Keyboard",
                Price = 5000
            }
        };

        return Ok(products);
    }


    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = new
        {
            Id = id,
            Name = "Sample Product",
            Price = 1000
        };

        return Ok(product);
    }
}