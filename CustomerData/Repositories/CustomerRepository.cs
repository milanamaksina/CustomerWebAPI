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
            var newCustomer = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            newCustomer.FirstName=customer.FirstName;
            newCustomer.LastName=customer.LastName;
            newCustomer.Phone=customer.Phone;
            newCustomer.Email = customer.Email;
            newCustomer.TotalPurchasesAmount = customer.TotalPurchasesAmount;
            newCustomer.Addresses = customer.Addresses;
            newCustomer.Notes = customer.Notes;

            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomers()
        {
           var customers = _context.Customers.ToList();

           foreach (var customer in customers)
           {
              _context.Customers.Remove(customer);
              _context.SaveChanges();
           }

            //_context.Customers.RemoveRange();
        }

    }
}
