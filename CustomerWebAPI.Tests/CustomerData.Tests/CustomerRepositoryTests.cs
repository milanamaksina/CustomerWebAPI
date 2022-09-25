using CustomerData.Contexts;
using CustomerData.Entities;
using CustomerData.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerWebAPI.Tests.CustomerData.Tests
{
    public class CustomerRepositoryTests
    {
        private readonly DbContextOptions<CustomerProjectContext> _dbContextOptions;

        public CustomerRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<CustomerProjectContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
        }

        [Fact]
        public void ShouldBeAbleToGetCustomerById()
        {
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new CustomerRepository(context);
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Harry",
                LastName = "Potter",
                Phone = "+16123045652",
                Email = "potter@gmail.com",
                TotalPurchasesAmount = 0,
                Addresses = new() { new Address() { AddressId = 1, CustomerId = 1, AddressLine = "Pearl Street", AddressLine2 = "",
                    //AddressType = "Shipping",
                    PostalCode = "123321", City = "Toronto", State = "", Country = "Canada" } },
                Notes = "note1"
            };
            context.Customers.Add(customer);
            context.SaveChanges();

            var result = sut.GetCustomerById(customer.Id);

            Assert.NotNull(result);
            Assert.Equal(customer.FirstName, result.FirstName);
        }


        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new CustomerRepository(context);
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Harry",
                LastName = "Potter",
                Phone = "+16123045652",
                Email = "potter@gmail.com",
                TotalPurchasesAmount = 0,
                Addresses = new() { new Address() { AddressId = 1, CustomerId = 1, AddressLine = "Pearl Street", AddressLine2 = "", 
                    //AddressType = "Shipping", 
                    PostalCode = "123321", City = "Toronto", State = "", Country = "Canada" } },
                Notes = "note1"
            };

            sut.CreateCustomer(customer);
            var result = sut.GetCustomerById(customer.Id);

            Assert.NotNull(result);
            Assert.Equal(customer.FirstName, result.FirstName);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new CustomerRepository(context);
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Harry",
                LastName = "Potter",
                Phone = "+16123045652",
                Email = "potter@gmail.com",
                TotalPurchasesAmount = 0,
                Addresses = new() { new Address() {
                    AddressId = 1, 
                    CustomerId = 1, 
                    AddressLine = "Pearl Street", 
                    AddressLine2 = "", 
                    //AddressType = "Shipping", 
                    PostalCode = "123321", City = "Toronto", State = "", Country = "Canada" } }, 
                Notes = "note1"
            };
            context.Customers.Add(customer);
            context.SaveChanges();

            sut.DeleteCustomer(1);
            var result = sut.GetCustomerById(1);

            Assert.Null(result);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var newName = "Petya";
            var newLastName = "Petrov";

            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new CustomerRepository(context);
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Harry",
                LastName = "Potter",
                Phone = "+16123045652",
                Email = "potter@gmail.com",
                TotalPurchasesAmount = 0,
                Addresses = new() { new Address() { AddressId = 1, CustomerId = 1, AddressLine = "Pearl Street", AddressLine2 = "", 
                    //AddressType = "Shipping",
                    PostalCode = "123321", City = "Toronto", State = "", Country = "Canada" } },
                Notes = "note1"
            };
            context.Customers.Add(customer);
            context.SaveChanges();
            customer.FirstName = newName;
            customer.LastName = newLastName;

            sut.UpdateCustomer(customer);
            var result = sut.GetCustomerById(1);

            Assert.NotNull(result);
            Assert.Equal(customer.FirstName, result.FirstName);
            Assert.Equal(customer.LastName, result.LastName);
        }

        [Fact]
        public void ShouldBeAbleToGetAllCustomers()
        {
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new CustomerRepository(context);
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Harry",
                LastName = "Potter",
                Phone = "+16123045652",
                Email = "potter@gmail.com",
                TotalPurchasesAmount = 0,
                Addresses = new() { new Address() { AddressId = 1, CustomerId = 1, AddressLine = "Pearl", AddressLine2 = "",
                    //AddressType = "Shipping",
                    PostalCode = "1", City = "Toronto", State = "", Country = "Canada" } },
                Notes = "note1"
            };
            context.Customers.Add(customer);
            context.SaveChanges();

            List<Customer> customers = sut.GetCustomers();

            Assert.NotNull(customers);
            Assert.NotNull(customers.Find(x => x.Id == 1));
            Assert.True(customers.Count == 1);
            Assert.Equal(customer.FirstName, customers[0].FirstName);
        }

    }
}
