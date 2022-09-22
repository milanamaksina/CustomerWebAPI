using CustomerData.Entities;
using CustomerData.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebAPI.Controllers
{
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: AddressControlle
        public IActionResult GetAdresses()
        {
            var addresses = _addressRepository.GetAddresses();
            if (addresses == null)
                return NotFound();
            else
                return Ok(addresses);
        }

        // GET: AddressController/Details/5
        public IActionResult GetAddressById(int id)
        {
            var address = _addressRepository.GetAddressById(id);

            if (address != null)
                return Ok(address);
            else
                return NotFound(id);
        }

        // POST: AddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddress(Address address)
        {
            var newAddress = _addressRepository.CreateAddress(address);

            if (newAddress != null)
                return Ok(newAddress);
            else
                return NoContent();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: AddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
