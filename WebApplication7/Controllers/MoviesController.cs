using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data;
using WebApplication7.Models;
using WebApplication7.Requests;
using WebApplication7.DTOs;

namespace WebApplication7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly DataContext _context;

    public MoviesController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("add-movie")]
    public ActionResult AddMovie(AddMovie req)
    {
        Movie movie = new Movie
        {
            Title = req.Title,
            Rating = req.Rating,
            ReleaseYear = req.ReleaseYear,
            Budget = req.Budget,
            CountryFrom = req.CountryFrom,
            Duration = req.Duration,
            Genre = req.Genre,
            HasOscar = req.HasOscar,
        };

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return Ok(movie);
    }

    [HttpGet("get-all-movies")]
    public List<Movie> GetMovies()
    {
        return _context.Movies.ToList();
    }

    [HttpGet("get-oscar-movies")]
    public ActionResult GetOscarMovies()
    {
        var allMovies = _context.Movies.Where(m => m.HasOscar == true).ToList();

        if(allMovies.Count > 0)
        {
            var dataToReturn = allMovies.Select(m => new OscarMovieDTO
            {
                Genre = m.Genre,
                Rating = m.Rating,
                Title = m.Title,
            });

            return Ok(dataToReturn);
        }
        else
        {
            return NotFound(new { Message = "Data Not Found" });
        }
    }

    [HttpGet("get-all-genres")]
    public ActionResult GetAllGenres()
    {
        return Ok(_context.Movies.ToList().Select(m => new GenreDTO { Genre = m.Genre }).DistinctBy(m => m.Genre));
    }

    [HttpGet("get-by-budget")]
    public ActionResult GetByBudget()
    {
            
        var byBudget = _context.Movies
            .Select(m => new BudgetDTO { Title = m.Title, Budget = m.Budget })
            .OrderByDescending(m => m.Budget);


        return Ok(byBudget);
    }
}
