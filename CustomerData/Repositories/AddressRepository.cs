using CustomerData.Contexts;
using CustomerData.Entities;
using CustomerData.Repositories.Interfaces;

namespace CustomerData.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CustomerProjectContext _context;

        public Address? GetAddressById(int Id) => _context.Addresses?.FirstOrDefault(a => a.AddressId == Id);
        public List<Address> GetAddresses() => _context.Addresses.ToList();

        public AddressRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public int CreateAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address.AddressId;
        }

        public void DeleteAddress(int Id)
        {
            var address = GetAddressById(Id);
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }
    }
}
