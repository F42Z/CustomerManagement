using CustomerManagement.UI.Models;

namespace CustomerManagement.UI.Interfaces;

public interface ICustomer
{
    public Task<IEnumerable<Customer>> GetCustomersAsync();
    
    public Task<Customer> GetCustomerAsync(int id);

    public Task CreateCustomerAsync(Customer customer);

    public Task UpdateCustomerAsync(Customer customer);

    public Task DeleteCustomerAsync(int id);
}