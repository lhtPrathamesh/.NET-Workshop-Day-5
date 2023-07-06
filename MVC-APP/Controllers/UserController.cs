using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_APP.Data;
using MVC_APP.Models;
using MVC_APP.Controllers;

namespace MVC_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private MovieRentalDbContext _dbContext;
        private readonly AuthController _authController;

        public UserController(MovieRentalDbContext dbContext, AuthController authController)
        {
            _dbContext = dbContext;
            _authController = authController;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] User userDetails)
        {
            try
            {
                _dbContext.Users.Add(userDetails);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok("User register successfully");
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] Login userDetails)
        {
            try
            {
                var user = _authController.Authenticate(userDetails);

                if (user != null)
                {
                    var token = _authController.GenerateToken(user);
                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NotFound("Invalid username or password");
        }
    }
}
