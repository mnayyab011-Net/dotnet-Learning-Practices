using MovieApi.Services;
using MovieApi.Settings;
var builder = WebApplication.CreateBuilder(args);
var mongoSettings = builder.Configuration
    .GetSection("MongoDB")
    .Get<MongoDBSettings>();
builder.Services.AddSingleton(mongoSettings!);
builder.Services.AddSingleton<MovieService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();