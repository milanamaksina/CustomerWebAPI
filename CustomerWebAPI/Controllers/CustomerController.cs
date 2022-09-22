using CustomerData.Entities;
using CustomerData.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            if (customers == null)
                return NotFound();
            else
                return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer != null)
                return Ok(customer);
            else
                return NotFound(id);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            var newCustomer = _customerRepository.CreateCustomer(customer);

            if (newCustomer != null)
                return Ok(newCustomer);
            else 
                return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            try
            {
                _customerRepository.UpdateCustomer(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_customerRepository.GetCustomerById(id) == null)
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
        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }
            _customerRepository.DeleteCustomer(id);
            return Ok(id);
        }
    }
}
