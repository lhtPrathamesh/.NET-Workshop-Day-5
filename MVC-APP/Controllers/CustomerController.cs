using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_APP.Data;
using MVC_APP.Models;

namespace MVC_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private MovieRentalDbContext _dbContext;

        public CustomerController(MovieRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("AddCustomer")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCustomer([FromBody] Customer customerDetails)
        {
            try
            {
                _dbContext.Customers.Add(customerDetails);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok("Customer Added successfully");
        }


        [HttpGet("GetAllCustomers")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _dbContext.Customers.ToList();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut("UpdateCustomer/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer updateObject)
        {
            var customer = _dbContext.Customers.FirstOrDefault(customer => customer.Id == id);
            if (customer == null) return NotFound("Customer not found");

            // compares the properties of the `updateObject` object with the existing customer entity and
            // updates only the properties that have changed.
            _dbContext.Entry(customer).CurrentValues.SetValues(new
            {
                updateObject.CustomerName,
                updateObject.CustomerEmail,
                updateObject.MembershipType,
            });

            try
            {
                _dbContext.SaveChanges();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpDelete("DeleteCustomer/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(customer => customer.Id == id);
            if (customer == null) return NotFound("Customer not found");

            try
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
                return Ok("Customer deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
