using AutoMapper;
using CustomerData.Entities;
using CustomerData.Enums;
using CustomerData.Repositories.Interfaces;
using CustomerWebAPI.Controllers;
using CustomerWebAPI.MapperStorage;
using CustomerWebAPI.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CustomerWebAPI.Tests.CustomerAPI.Tests
{
    public class AddressControllerTests
    {
        private AddressController _sut;
        private Mock<IAddressRepository> _addressRepositoryMock;
        private IMapper _mapper;

        public AddressControllerTests()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperConfig>()));
            _sut = new AddressController(_addressRepositoryMock.Object, _mapper);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var address = new AddressCreateRequest
            {
                AddressLine = "Pearl",
                AddressLine2 = "",
                AddressType = AddressType.Shipping,
                City = "Toronto",
                PostalCode = "1",
                State = "",
                Country = "Canada"
            };
            var expectedId = 1;
            _addressRepositoryMock
                .Setup(c => c.CreateAddress(It.Is<Address>(c => c.AddressLine == address.AddressLine)))
                .Returns(1);

            var actual = _sut.CreateAddress(address);
            var actualResult = actual as ObjectResult;

            Assert.Equal(expectedId, actualResult.Value);
            Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
            _addressRepositoryMock.Verify(t => t.CreateAddress(
                It.Is<Address>(
                    c => c.AddressLine == address.AddressLine &&
                    c.AddressLine2 == address.AddressLine2 &&
                    c.AddressType == address.AddressType &&
                    c.City == address.City &&
                    c.PostalCode == address.PostalCode &&
                    c.State == address.State &&
                    c.Country == address.Country 
                    )), Times.Once());
        }

    }
}
