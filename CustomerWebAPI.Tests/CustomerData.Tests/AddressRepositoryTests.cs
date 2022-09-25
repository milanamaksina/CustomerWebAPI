using CustomerData.Contexts;
using CustomerData.Entities;
using CustomerData.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerWebAPI.Tests.CustomerData.Tests
{
    public class AddressRepositoryTests
    {
        private readonly DbContextOptions<CustomerProjectContext> _dbContextOptions;

        public AddressRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<CustomerProjectContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
        }

        [Fact]
        public void ShouldBeAbleToGetAddressById()
        {
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new AddressRepository(context);
            var address = new Address
            {
                AddressId = 1,
                AddressLine = "Pearl",
                AddressLine2 = "",
                //AddressType = "Shipping",
                City = "Toronto",
                PostalCode = "1",
                State = "",
                Country = "Canada"
            };
            context.Addresses.Add(address);
            context.SaveChanges();

            var result = sut.GetAddressById(address.AddressId);

            Assert.NotNull(result);
            Assert.Equal(address.AddressLine, result.AddressLine);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new AddressRepository(context);
            var address = new Address
            {
                AddressId = 1,
                AddressLine = "Pearl",
                AddressLine2 = "",
               // AddressType = "Shipping",
                City = "Toronto",
                PostalCode = "1",
                State = "",
                Country = "Canada"
            };

            sut.CreateAddress(address);
            var result = sut.GetAddressById(address.AddressId);

            Assert.NotNull(result);
            Assert.Equal(address.AddressLine, result.AddressLine);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new AddressRepository(context);
            var address = new Address
            {
                AddressId = 1,
                AddressLine = "Pearl",
                AddressLine2 = "",
                //AddressType = "Shipping",
                City = "Toronto",
                PostalCode = "1",
                State = "",
                Country = "Canada"
            };
            context.Addresses.Add(address);
            context.SaveChanges();

            sut.DeleteAddress(address.AddressId);
            var result = sut.GetAddressById(address.AddressId);

            Assert.Null(result);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var newAddressLine = "Moon avenu";
            var newPostalCode = "2";
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new AddressRepository(context);
            var address = new Address
            {
                AddressId = 1,
                AddressLine = "Pearl",
                AddressLine2 = "",
               // AddressType = "Shipping",
                City = "Toronto",
                PostalCode = "1",
                State = "",
                Country = "Canada"
            };
            context.Addresses.Add(address);
            context.SaveChanges();
            address.AddressLine = newAddressLine;
            address.PostalCode = newPostalCode;

            sut.UpdateAddress(address);
            var result = sut.GetAddressById(address.AddressId);

            Assert.NotNull(result);
            Assert.Equal(result.AddressLine, newAddressLine);
            Assert.Equal(result.PostalCode, newPostalCode);
        }

        [Fact]
        public void ShouldBeAbleToGetAllAddresses()
        {
            var context = new CustomerProjectContext(_dbContextOptions);
            var sut = new AddressRepository(context);
            var address = new Address
            {
                AddressId = 1,
                AddressLine = "Pearl",
                AddressLine2 = "",
               // AddressType = "Shipping",
                City = "Toronto",
                PostalCode = "1",
                State = "",
                Country = "Canada"
            };
            context.Addresses.Add(address);
            context.SaveChanges();

            List <Address> addresses = sut.GetAddresses();

            Assert.NotNull(addresses);
            Assert.NotNull(addresses.Find(x => x.AddressId == 1));
            Assert.True(addresses.Count == 1);
        }
    }
}
