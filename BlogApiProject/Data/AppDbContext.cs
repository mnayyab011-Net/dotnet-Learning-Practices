using Microsoft.EntityFrameworkCore;
using BlogApiProject.Models;
using BlogApiProject.Data;
namespace BlogApiProject.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
    : base (options)
{
}
 public DbSet <User> Users {get;set;} 
 public DbSet <Category> Categories {get;set;}
 public DbSet <Post> Posts {get;set;}  
 }