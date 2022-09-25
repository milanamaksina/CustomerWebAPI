using CustomerData.Repositories;
using CustomerData.Repositories.Interfaces;

namespace CustomerWebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}
