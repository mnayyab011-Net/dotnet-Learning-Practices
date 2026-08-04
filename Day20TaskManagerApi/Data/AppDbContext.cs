using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Models;
namespace TaskManagerApi.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<TaskItem> TaskItems { get; set; }
}