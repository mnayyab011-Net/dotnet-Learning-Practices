using RestaurantsApi.Services;
using RestaurantsApi.Settings;

var builder = WebApplication.CreateBuilder(args);

var mongoSettings = builder.Configuration
    .GetSection("MongoDB")
    .Get<MongoDBSettings>();

builder.Services.AddSingleton(mongoSettings!);

builder.Services.AddSingleton<RestaurantService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();