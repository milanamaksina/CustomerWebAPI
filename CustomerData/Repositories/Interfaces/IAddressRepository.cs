using CustomerData.Entities;

namespace CustomerData.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        int CreateAddress(Address entity);
        List<Address> GetAddresses();
        void DeleteAddress(int Id);
        void UpdateAddress(Address entity, int id);
        Address? GetAddressById(int Id);

    }
}
