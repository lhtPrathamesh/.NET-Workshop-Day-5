using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_APP.Data;
using MVC_APP.Models;
using System.Data;

namespace MVC_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalMoviesController : ControllerBase
    {
        private MovieRentalDbContext _dbContext;

        public RentalMoviesController(MovieRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("AddMovie")]
        [Authorize]
        public IActionResult AddMovie([FromBody] RentalMovie movieDetails)
        {
            try
            {
                _dbContext.RentalMovies.Add(movieDetails);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok("Movie Added successfully");
        }

        [HttpGet("GetAllMovies")]
        public IActionResult GetAllMovies()
        {
            try
            {
                var movies = _dbContext.RentalMovies.ToList();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
