using Microsoft.AspNetCore.Mvc;
using CustomerManagement.UI.Models;

namespace CustomerManagement.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient _httpClient;

        public CustomerController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _httpClient.GetFromJsonAsync<List<Customer>>("http://localhost:52952/api/customers");
            return View(customers);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:52952/api/customers", customer);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(customer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"http://localhost:52952/api/customers/{id}");
            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:52952/api/customers/{customer.Id}", customer);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"http://localhost:52952/api/customers/{id}");
            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"http://localhost:52952/api/customers/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}