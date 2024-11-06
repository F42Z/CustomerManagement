using CustomerManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using CustomerManagement.API.Interfaces;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customerService;

        public CustomersController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers() => _customerService.GetCustomers();

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            _customerService.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}