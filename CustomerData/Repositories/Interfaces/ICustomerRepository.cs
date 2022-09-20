using CustomerData.Entities;

namespace CustomerData.Repositories
{
    public interface ICustomerRepository
    {
        int CreateCustomer(Customer entity);
        List<Customer> GetCustomers();
        void DeleteCustomer(int Id);
        void UpdateCustomer(Customer entity);
        Customer? GetCustomerById(int Id);
    }
}
