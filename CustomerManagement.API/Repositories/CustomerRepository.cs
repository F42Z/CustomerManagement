using CustomerManagement.API.Models;

namespace CustomerManagement.API.Repositories;

public class CustomerRepository
{
    private static List<Customer> customers = new List<Customer>();
    private static int nextId = 1;

    public IEnumerable<Customer> GetAll() => customers;
    public Customer Get(int id) => customers.FirstOrDefault(c => c.Id == id)!;

    public void Add(Customer customer)
    {
        customer.Id = nextId++;
        customers.Add(customer);
    }

    public void Update(Customer customer)
    {
        var existing = Get(customer.Id);
        if (existing != null)
        {
            existing.Name = customer.Name;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;
        }
    }

    public void Delete(int id)
    {
        var customer = Get(id);
        if (customer != null) customers.Remove(customer);
    }
}