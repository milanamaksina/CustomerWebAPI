using CustomerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerData.Contexts
{
    public class CustomerProjectContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public CustomerProjectContext(DbContextOptions<CustomerProjectContext> options): base(options)
        {
        }

    }
}
