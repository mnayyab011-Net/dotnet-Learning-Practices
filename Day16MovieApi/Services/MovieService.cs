using MovieApi.Models;
using MovieApi.Settings;
using MongoDB.Driver;
namespace MovieApi.Services;
public class MovieService
{
    private readonly IMongoCollection<Movie> _movies;
    public MovieService(MongoDBSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);

        var database = client.GetDatabase(settings.DatabaseName);

        _movies = database.GetCollection<Movie>(settings.CollectionName);
    }
    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        return await _movies
            .Find(movie => true)
            .ToListAsync();
    }
    public async Task<Movie?> GetMovieByIdAsync(string id)
    {
        return await _movies
            .Find(movie => movie.Id == id)
            .FirstOrDefaultAsync();
    }
    public async Task CreateMovieAsync(Movie movie)
    {
        movie.CreatedAt = DateTime.UtcNow;

        await _movies.InsertOneAsync(movie);
    }
    public async Task UpdateMovieAsync(string id, Movie movie)
    {
        await _movies.ReplaceOneAsync(
            movie => movie.Id == id,
            movie
        );
    }
    public async Task DeleteMovieAsync(string id)
    {
        await _movies.DeleteOneAsync(
            movie => movie.Id == id
        );
    }
}