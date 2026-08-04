using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductValidationApi.Data;
using ProductValidationApi.Models;
namespace ProductValidationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found."
                });
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(new
                {
                    message = "Product ID mismatch."
                });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == id))
                {
                    return NotFound(new
                    {
                        message = "Product not found."
                    });
                }
                throw;
            }
            return Ok(new
            {
                message = "Product updated successfully."
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found."
                });
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Product deleted successfully."
            });
        }
    }
}
