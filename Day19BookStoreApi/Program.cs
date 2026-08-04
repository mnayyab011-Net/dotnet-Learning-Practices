using BookStoreApi.Services;
using BookStoreApi.Settings;
var builder = WebApplication.CreateBuilder(args);
var mongoSettings =
builder.Configuration
.GetSection("MongoDB")
.Get<MongoDBSettings>();
builder.Services.AddSingleton(
    mongoSettings!
);
builder.Services.AddSingleton<BookService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();