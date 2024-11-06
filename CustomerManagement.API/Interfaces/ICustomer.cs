using CustomerManagement.API.Models;

namespace CustomerManagement.API.Interfaces;

public interface ICustomer
{
    List<Customer> GetCustomers();
    Customer GetCustomer(int id);
    void AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int id);
}