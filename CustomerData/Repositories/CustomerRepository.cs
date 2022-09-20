using CustomerData.Contexts;
using CustomerData.Entities;

namespace CustomerData.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerProjectContext _context;

        public CustomerRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public Customer? GetCustomerById(int Id) => _context.Customers?.FirstOrDefault(c => c.Id == Id);
        public List<Customer> GetCustomers() => _context.Customers.ToList();

        public int CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.Id;
        }

        public void DeleteCustomer(int Id)
        {
            var customer = GetCustomerById(Id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

    }
}
