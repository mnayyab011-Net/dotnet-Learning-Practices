using LibraryApiTesting.Models;
namespace LibraryApiTesting.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new();
        public List<Book> GetAll()
        {
            return _books;
        }
        public Book? GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }
        public void Add(Book book)
        {
            _books.Add(book);
        }
        public bool Update(int id, Book book)
        {
            var existingBook = GetById(id);
            if (existingBook == null)
                return false;
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Category = book.Category;
            existingBook.Price = book.Price;
            existingBook.IsAvailable = book.IsAvailable;
            return true;
        }
        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book == null)
                return false;
            _books.Remove(book);
              return true;
        }
    }
}