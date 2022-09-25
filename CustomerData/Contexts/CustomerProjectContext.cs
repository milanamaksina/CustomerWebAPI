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

                entity.Property(r => r.AddressLine).HasMaxLength(100);
                entity.Property(r => r.AddressLine2).HasMaxLength(100);
                entity.Property(r => r.City).HasMaxLength(50);
                entity.Property(r => r.PostalCode).HasMaxLength(6);
                entity.Property(r => r.State).HasMaxLength(20);
                //entity.Property(r => r.AddressType).Has;

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable(nameof(Customer));
                entity.HasKey(c => c.Id);
                entity.Property(r => r.FirstName).HasMaxLength(50);
                entity.Property(r => r.LastName).HasMaxLength(50);
                entity.Property(r => r.Phone).HasMaxLength(15);
                entity.Property(r => r.Notes).HasMaxLength(255);
                entity.Property(r => r.Email).HasMaxLength(255);
                entity.Property(c => c.TotalPurchasesAmount)
                .HasPrecision(7, 2);
            });
        }
    }
}
