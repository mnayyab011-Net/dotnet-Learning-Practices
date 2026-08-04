using Microsoft.AspNetCore.Mvc;
using RestaurantsApi.Models;
using RestaurantsApi.Services;

namespace RestaurantsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    private readonly RestaurantService _service;

    public RestaurantsController(RestaurantService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAsync());
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var restaurant = await _service.GetByIdAsync(id);

        if (restaurant == null)
            return NotFound();

        return Ok(restaurant);
    }


    [HttpPost]
    public async Task<IActionResult> Create(Restaurant restaurant)
    {
        await _service.CreateAsync(restaurant);

        return Ok(restaurant);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        string id,
        Restaurant restaurant)
    {
        await _service.UpdateAsync(id, restaurant);

        return Ok("Updated");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteAsync(id);

        return Ok("Deleted");
    }
}