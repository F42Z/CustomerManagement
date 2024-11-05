using CustomerManagement.UI.Models;

namespace CustomerManagement.UI.Services;

public class CustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("api/customers");
    }

    public async Task<Customer> GetCustomerAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Customer>($"api/customers/{id}");
    }

    public async Task CreateCustomerAsync(Customer customer)
    {
        await _httpClient.PostAsJsonAsync("api/customers", customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        await _httpClient.PutAsJsonAsync($"api/customers/{customer.Id}", customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/customers/{id}");
    }
}