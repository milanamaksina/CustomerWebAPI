using AutoMapper;
using CustomerData.Entities;
using CustomerWebAPI.Models;
using CustomerWebAPI.Models.Requests;
using CustomerWebAPI.Models.Responses;

namespace CustomerWebAPI.MapperStorage
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<CustomerUpdateRequest, Customer>();
            CreateMap<Address, AddressResponse>();
            CreateMap<Address, AddressResponse>();
            CreateMap<AddressCreateRequest, Address>();
            CreateMap<AddressUpdateRequest, Address>();

        }
    }
}
