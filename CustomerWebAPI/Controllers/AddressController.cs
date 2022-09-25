using AutoMapper;
using CustomerData.Entities;
using CustomerData.Repositories.Interfaces;
using CustomerWebAPI.Models.Requests;
using CustomerWebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;   
        }

        [HttpGet()]
        public ActionResult GetAdresses()
        {
            var addresses = _addressRepository.GetAddresses();
          
            if (addresses == null)
                return NotFound();
            else
                return Ok(_mapper.Map<AddressResponse>(addresses));
        }

        [HttpGet("{id}")]
        public ActionResult GetAddressById(int id)
        {
            var address = _addressRepository.GetAddressById(id);

            if (address != null)
                return Ok(_mapper.Map<AddressResponse>(address));
            else
                return NotFound(id);
        }

        [HttpPost()]
        public ActionResult CreateAddress(AddressCreateRequest address)
        {
            var newAddressId = _addressRepository.CreateAddress(_mapper.Map<Address>(address));

            if (newAddressId != null)
                return Ok(newAddressId);
            else
                return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult EditAddress(int id, AddressUpdateRequest address)
        {
            try
            {
                _addressRepository.UpdateAddress(_mapper.Map<Address>(address));
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
