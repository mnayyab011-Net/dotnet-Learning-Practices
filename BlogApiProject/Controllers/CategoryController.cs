using BlogApiProject.Data;
using BlogApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BlogApiProject.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;
    public CategoryController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return Ok(categories);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound("Category not found.");
        return Ok(category);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return Ok(category);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, Category category)
    {
        var existingCategory = await _context.Categories.FindAsync(id);
        if (existingCategory == null)
            return NotFound("Category not found.");
        existingCategory.Name = category.Name;
        await _context.SaveChangesAsync();
        return Ok(existingCategory);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound("Category not found.");
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return Ok("Category deleted successfully.");
    }
}