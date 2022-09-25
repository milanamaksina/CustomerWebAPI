using CustomerData.Entities;
using CustomerData.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet()]
        public ActionResult GetAdresses()
        {
            var addresses = _addressRepository.GetAddresses();
            if (addresses == null)
                return NotFound();
            else
                return Ok(addresses);
        }

        [HttpGet("{id}")]
        public ActionResult GetAddressById(int id)
        {
            var address = _addressRepository.GetAddressById(id);

            if (address != null)
                return Ok(address);
            else
                return NotFound(id);
        }

        [HttpPost()]
        public ActionResult CreateAddress(Address address)
        {
            var newAddress = _addressRepository.CreateAddress(address);

            if (newAddress != null)
                return Ok(newAddress);
            else
                return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult EditAddress(int id, Address address)
        {
            try
            {
                _addressRepository.UpdateAddress(address);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_addressRepository.GetAddressById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var address = _addressRepository.GetAddressById(id);

            if (address == null)
            {
                return NotFound();
            }
            _addressRepository.DeleteAddress(id);
            return Ok(id);
        }
    }
}
