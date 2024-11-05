using CustomerManagement.API.Data;
using CustomerManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersController()
        {
            _context = new CustomerContext();
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers() => _context.GetCustomers();

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _context.GetCustomer(id);
            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer customer)
        {
            _context.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            _context.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _context.DeleteCustomer(id);
            return NoContent();
        }
    }
}