using CustomerManagement.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CustomerManagement.UI.Models;

namespace CustomerManagement.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customer.GetCustomersAsync();
            return View(customers.ToList());
        }
        
        public IActionResult Create() => View();
        
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _customer.CreateCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customer.GetCustomerAsync(id);
            if (customer == null)
                return NotFound();

            return View(customer);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            await _customer.UpdateCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _customer.GetCustomerAsync(id);
            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customer.DeleteCustomerAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}