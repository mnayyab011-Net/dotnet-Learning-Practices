using Microsoft.AspNetCore.Mvc;
using BookStoreApi.Models;
using BookStoreApi.Services;


namespace BookStoreApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{

    private readonly BookService _service;


    public BooksController(BookService service)
    {
        _service = service;
    }



    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(
            await _service.GetAsync()
        );
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var book =
            await _service.GetByIdAsync(id);


        if(book == null)
            return NotFound();


        return Ok(book);
    }



    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        await _service.CreateAsync(book);

        return Ok(book);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        string id,
        Book book)
    {
        await _service.UpdateAsync(id,book);

        return Ok("Updated");
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteAsync(id);

        return Ok("Deleted");
    }

}