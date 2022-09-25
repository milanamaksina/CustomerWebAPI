using AutoMapper;
using CustomerData.Entities;
using CustomerWebAPI.Models;
using CustomerWebAPI.Models.Requests;
using CustomerWebAPI.Models.Responses;

namespace CustomerWebAPI.Mapper
{
    public class MapperConfiguration: Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerCreateRequest, Customer>().ReverseMap();
            CreateMap<CustomerUpdateRequest, Customer>();
            CreateMap<Address, AddressResponse>();
            CreateMap<AddressCreateRequest, Address>();
            CreateMap<AddressUpdateRequest, Address>();
        }
    }
}
