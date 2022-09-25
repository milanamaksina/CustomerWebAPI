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
        public void UpdateCustomer(Customer newModelCustomer, int id)
        {
            var customer = GetCustomerById(id);
            //customer.FirstName=newModelCustomer.FirstName;
            //customer.LastName=newModelCustomer.LastName;
            //customer.Phone=newModelCustomer.Phone;
            //customer.Email = newModelCustomer.Email;
            //customer.TotalPurchasesAmount = newModelCustomer.TotalPurchasesAmount;
            //customer.Addresses = newModelCustomer.Addresses;
            //customer.Notes = newModelCustomer.Notes;

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
