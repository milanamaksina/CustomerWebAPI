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
            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<CustomerUpdateRequest, Customer>();
        }
    }
}
