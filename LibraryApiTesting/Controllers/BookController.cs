using LibraryApiTesting.Models;
using LibraryApiTesting.Services;
using Microsoft.AspNetCore.Mvc;
namespace LibraryApiTesting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            return Ok(book);
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.Add(book);
            return CreatedAtAction(
                nameof(GetBookById),
                new { id = book.Id },
                book);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            var updated = _bookService.Update(id, book);

            if (!updated)
            {
                return NotFound("Book not found.");
            }
            return Ok("Book updated successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var deleted = _bookService.Delete(id);
            if (!deleted)
            {
                return NotFound("Book not found.");
            }
            return Ok("Book deleted successfully.");
        }
    }
}