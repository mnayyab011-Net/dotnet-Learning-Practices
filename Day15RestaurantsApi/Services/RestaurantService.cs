using MongoDB.Driver;
using RestaurantsApi.Models;
using RestaurantsApi.Settings;

namespace RestaurantsApi.Services;

public class RestaurantService
{
    private readonly IMongoCollection<Restaurant> _restaurants;

    public RestaurantService(MongoDBSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _restaurants = database.GetCollection<Restaurant>(
            settings.CollectionName);
    }


    public async Task<List<Restaurant>> GetAsync()
    {
        return await _restaurants.Find(_ => true).ToListAsync();
    }


    public async Task<Restaurant?> GetByIdAsync(string id)
    {
        return await _restaurants
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
    }


    public async Task CreateAsync(Restaurant restaurant)
    {
        await _restaurants.InsertOneAsync(restaurant);
    }


    public async Task UpdateAsync(string id, Restaurant restaurant)
    {
        await _restaurants.ReplaceOneAsync(
            x => x.Id == id,
            restaurant);
    }


    public async Task DeleteAsync(string id)
    {
        await _restaurants.DeleteOneAsync(
            x => x.Id == id);
    }
}