using CustomerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerData.Contexts
{
    public class CustomerProjectContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public CustomerProjectContext(DbContextOptions<CustomerProjectContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable(nameof(Address));
                entity.HasKey(c => c.AddressId);

                entity
                .HasOne(a => a.Customer)
                .WithMany(c => c.Addresses);
            });
        }
    }
}
