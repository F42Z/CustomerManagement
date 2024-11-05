using CustomerManagement.UI.Interfaces;
using CustomerManagement.UI.Models;

namespace CustomerManagement.UI.Services;

public class CustomerService : ICustomer
{
    private readonly HttpClient _httpClient;
    private const string? ApiCustomers = "api/customers";
    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var customers = await _httpClient.GetFromJsonAsync<List<Customer>>($"{ApiCustomers}");
        return customers.ToList();
    }

    public async Task<Customer> GetCustomerAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Customer>($"{ApiCustomers}/{id}");
    }

    public async Task CreateCustomerAsync(Customer customer)
    {
        await _httpClient.PostAsJsonAsync(ApiCustomers, customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        await _httpClient.PutAsJsonAsync($"{ApiCustomers}/{customer.Id}", customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _httpClient.DeleteAsync($"{ApiCustomers}/{id}");
    }
}