using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Repositories;
using ProductApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddOpenApi();
var app = builder.Build();

app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseStaticFiles();
app.MapControllers();
app.MapFallbackToFile("index.html");
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product
            {
                Name = "Laptop",
                Price = 80000,
                Category = "Electronics"
            },
            new Product
            {
                Name = "Mobile",
                Price = 50000,
                Category = "Electronics"
            },
            new Product
            {
                Name = "Keyboard",
                Price = 5000,
                Category = "Accessories"
            },
            new Product
            {
                Name = "Mouse",
                Price = 2500,
                Category = "Accessories"
            },
            new Product
            {
                Name = "Monitor",
                Price = 35000,
                Category = "Electronics"
            }
        );
        context.SaveChanges();
    }
}
app.Run();