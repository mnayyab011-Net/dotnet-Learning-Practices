using LibraryApiTesting.Models;
namespace LibraryApiTesting.Services
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book? GetById(int id);
        void Add(Book book);
        bool Update(int id, Book book);
        bool Delete(int id);
    }
}
