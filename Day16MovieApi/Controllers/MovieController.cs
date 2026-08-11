using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Services;
namespace MovieApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;
    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetMovies()
    {
        var movies = await _movieService.GetAllMoviesAsync();
        return Ok(movies);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(string id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound(new
            {
                message = "Movie not found"
            });
        }
        return Ok(movie);
    }
    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
    {
        await _movieService.CreateMovieAsync(movie);
        return CreatedAtAction(
            nameof(GetMovie),
            new { id = movie.Id },
            movie
        );
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(
        string id,
        Movie movie)
    {
      var existingMovie = await _movieService.GetMovieByIdAsync(id);
        if (existingMovie == null)
        {
            return NotFound(new
            {
                message = "Movie not found"
            });
        }
        movie.Id = id;
        await _movieService.UpdateMovieAsync(id, movie);
        return Ok(new
        {
            message = "Movie updated successfully"
        });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(string id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound(new
            {
                message = "Movie not found"
            });
        }
        await _movieService.DeleteMovieAsync(id);
        return Ok(new
        {
            message = "Movie deleted successfully"
        });
    }
}