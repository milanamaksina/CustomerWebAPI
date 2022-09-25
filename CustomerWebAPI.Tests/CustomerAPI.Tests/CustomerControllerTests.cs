using AutoMapper;
using CustomerData.Entities;
using CustomerData.Repositories;
using CustomerWebAPI.Controllers;
using CustomerWebAPI.MapperStorage;
using CustomerWebAPI.Models;
using CustomerWebAPI.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CustomerWebAPI.Tests.CustomerAPI.Tests
{
    public class CustomerControllerTests
    {
        private CustomerController _sut;
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private IMapper _mapper;

        public CustomerControllerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();  
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperConfig>()));
            _sut = new CustomerController(_customerRepositoryMock.Object, _mapper);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customer = new CustomerCreateRequest
            {
                FirstName = "Harry",
                LastName = "Potter",
                Phone = "+16123045652",
                Email = "potter@gmail.com",
                TotalPurchasesAmount = 0,
                Notes = "note1"
            };
            var expectedId = 1;
            _customerRepositoryMock
                .Setup(c => c.CreateCustomer(It.Is<Customer>(c => c.FirstName == customer.FirstName)))
                .Returns(1);

            var actual = _sut.CreateCustomer(customer);
            var actualResult = actual as ObjectResult;

            Assert.Equal(expectedId, actualResult.Value);
            Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
            _customerRepositoryMock.Verify(t=>t.CreateCustomer(
                It.Is<Customer>(
                    c=>c.FirstName == customer.FirstName &&
                    c.LastName == customer.LastName && 
                    c.Phone == customer.Phone &&
                    c.Email == customer.Email &&
                    c.TotalPurchasesAmount == customer.TotalPurchasesAmount &&
                    c.Notes == customer.Notes
                    )), Times.Once());
        }

        [Fact]
        public void ShouldBeAbleToGetCustomerById()
        {
            var customer = new Customer
            {
                FirstName = "Harry",
                LastName = "Potter",
                Phone = "+16123045652",
                Email = "potter@gmail.com",
                TotalPurchasesAmount = 0,
                Notes = "note1"
            };
            _customerRepositoryMock
               .Setup(c => c.CreateCustomer(It.Is<Customer>(c => c.FirstName == customer.FirstName)))
               .Returns(1);
            var expectedCustomer = _customerRepositoryMock.Setup(c => c.GetCustomerById(1)).Returns(customer) as Customer;
            

            var actual = _sut.GetCustomerById(4) as ObjectResult;
            var actualResult = actual.Value as Customer;

            Assert.Equal(expectedCustomer, actualResult);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Harry",
                LastName = "Potter",
                Phone = "+16123045652",
                Email = "potter@gmail.com",
                TotalPurchasesAmount = 0,
                Notes = "note1"
            };
            _customerRepositoryMock
               .Setup(c => c.CreateCustomer(It.Is<Customer>(c => c.FirstName == customer.FirstName)))
               .Returns(1);

            _sut.Delete(1);
            var actualCustomer = _customerRepositoryMock.Setup(c => c.GetCustomerById(1)).Returns(customer) as Customer;

            Assert.Null(actualCustomer);
        }
    }
}
