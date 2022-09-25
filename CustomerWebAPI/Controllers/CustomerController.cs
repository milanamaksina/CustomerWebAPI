using AutoMapper;
using CustomerData.Entities;
using CustomerData.Repositories;
using CustomerWebAPI.Models;
using CustomerWebAPI.Models.Requests;
using CustomerWebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            if (customers == null)
                return NotFound();
            else
                return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer != null)
                return Ok(_mapper.Map<CustomerResponse>(customer));
            else
                return NotFound(id);
        }

        [HttpPost()]
        public ActionResult CreateCustomer(CustomerCreateRequest customer)
        {
            var newCustomerId = _customerRepository.CreateCustomer(_mapper.Map<Customer>(customer));

            if (newCustomerId != null)
                return Ok(newCustomerId);
            else 
                return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult EditCustomer(int id, CustomerUpdateRequest customer)
        {
            try
            {
                _customerRepository.UpdateCustomer(_mapper.Map<Customer>(customer), id);
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
        public ActionResult Delete(int id)
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
