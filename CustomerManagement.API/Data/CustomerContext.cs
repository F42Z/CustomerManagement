using CustomerManagement.API.Models;

namespace CustomerManagement.API.Data
{
    public class CustomerContext
    {
        private static List<Customer> _customers { get; set; } = new List<Customer>();
        private static int _nextId = 1;
        public List<Customer> GetCustomers() => _customers;

        public Customer GetCustomer(int id) => _customers.FirstOrDefault(c => c.Id == id);

        public void AddCustomer(Customer customer)
        {
            customer.Id = _nextId++;
            _customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var index = _customers.FindIndex(c => c.Id == customer.Id);
            if (index != -1)
            {
                _customers[index] = customer;
            }
        }

        public void DeleteCustomer(int id)
        {
            var customer = GetCustomer(id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }
}