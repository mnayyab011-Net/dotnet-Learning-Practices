using System.Data;
using Microsoft.EntityFrameWorkCore;
using TaskManagerApi.Data;
using TaskManagerApi.Models;
namespace TaskManagerApi.Data;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options) 
    :base(options)
    {
    }
    public DataSet <TaskItems>TaskItem {get;set;}
}