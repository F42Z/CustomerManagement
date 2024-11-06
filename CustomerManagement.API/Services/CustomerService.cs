using CustomerManagement.API.Data;
using CustomerManagement.API.Interfaces;
using CustomerManagement.API.Models;

namespace CustomerManagement.API.Services
{
    public class CustomerService : ICustomer
    {
        private readonly CustomerContext _context;

        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers() => _context.GetCustomers();

        public Customer GetCustomer(int id)
        {
            var customer = _context.GetCustomer(id);
            if (customer == null)
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            return customer;
        }

        public void AddCustomer(Customer customer) => _context.AddCustomer(customer);

        public void UpdateCustomer(Customer customer) => _context.UpdateCustomer(customer);

        public void DeleteCustomer(int id) => _context.DeleteCustomer(id);
    }
}