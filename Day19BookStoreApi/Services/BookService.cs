using MongoDB.Driver;
using BookStoreApi.Models;
using BookStoreApi.Settings;

namespace BookStoreApi.Services;

public class BookService
{
    private readonly IMongoCollection<Book> _books;


    public BookService(MongoDBSettings settings)
    {
        var client = new MongoClient(
            settings.ConnectionString
        );

        var database = client.GetDatabase(
            settings.DatabaseName
        );

        _books = database.GetCollection<Book>(
            settings.CollectionName
        );
    }



    public async Task<List<Book>> GetAsync()
    {
        return await _books
            .Find(_ => true)
            .ToListAsync();
    }



    public async Task<Book?> GetByIdAsync(string id)
    {
        return await _books
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
    }



    public async Task CreateAsync(Book book)
    {
        await _books.InsertOneAsync(book);
    }



    public async Task UpdateAsync(
        string id,
        Book book)
    {
        await _books.ReplaceOneAsync(
            x => x.Id == id,
            book
        );
    }



    public async Task DeleteAsync(string id)
    {
        await _books.DeleteOneAsync(
            x => x.Id == id
        );
    }
}