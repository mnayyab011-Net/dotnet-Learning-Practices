using BlogApiProject.Models;
namespace BlogApiProject.Services;
public interface IPostService
{
    Task<List<Post>> GetPosts();
    Task <Post?> GetPost(int id);
}