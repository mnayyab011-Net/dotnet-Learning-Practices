using Microsoft.EntityFrameworkCore;
using BlogApiProject.Models;
using BlogApiProject.Data;
namespace BlogApiProject.Services;
public class PostService:IPostService
{
    private readonly AppDbContext _context;
    public PostService(AppDbContext context)
    {
        _context=context;
    }
   public async Task<List<Post>> GetPosts()
 {
    return await _context.Posts.ToListAsync();
 }
 public async Task <Post?> GetPost(int id)
 {
    return await _context.Posts.FindAsync(id);
 }
}