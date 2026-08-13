using BlogApiProject.Data;
using BlogApiProject.DTOs;
using BlogApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace BlogApiProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly AppDbContext _context;
    public PostController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Category)
            .Select(p => new PostResponseDto
            {
                Id = p.Id,
                UserId = p.UserId,
                UserName = p.User!.Name,
                CategoryId = p.CategoryId,
                CategoryName = p.Category!.Name,
                Title = p.Title,
                Content = p.Content,
                ImageUrl = p.ImageUrl,
                CreatedAt = p.CreatedAt
            })
            .ToListAsync();
        return Ok(posts);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(int id)
    {
        var post = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Category)
            .Where(p => p.Id == id)
            .Select(p => new PostResponseDto
            {
                Id = p.Id,
                UserId = p.UserId,
                UserName = p.User!.Name,
                CategoryId = p.CategoryId,
                CategoryName = p.Category!.Name,
                Title = p.Title,
                Content = p.Content,
                ImageUrl = p.ImageUrl,
                CreatedAt = p.CreatedAt
            })
            .FirstOrDefaultAsync();
        if (post == null)
            return NotFound("Post not found.");
        return Ok(post);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return Unauthorized();
        post.UserId = int.Parse(userId);
        post.CreatedAt = DateTime.UtcNow;
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return CreatedAtAction(
            nameof(GetPost),
            new { id = post.Id },
            new PostResponseDto
            {
                Id = post.Id,
                UserId = post.UserId,
                CategoryId = post.CategoryId,
                Title = post.Title,
                Content = post.Content,
                ImageUrl = post.ImageUrl,
                CreatedAt = post.CreatedAt
            });
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
        var existingPost = await _context.Posts.FindAsync(id);
        if (existingPost == null)
            return NotFound("Post not found.");
        existingPost.Title = post.Title;
        existingPost.Content = post.Content;
        existingPost.ImageUrl = post.ImageUrl;
        existingPost.CategoryId = post.CategoryId;
        await _context.SaveChangesAsync();
        return Ok("Post updated successfully.");
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound("Post not found.");
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return Ok("Post deleted successfully.");
    }
}