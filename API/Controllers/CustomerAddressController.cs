using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
       private readonly ICustomerAddressService _customerAddressService;

        public CustomerAddressController(ICustomerAddressService customerAddressService)
        {
            _customerAddressService = customerAddressService;
        }
        
        [HttpGet]
        public List<CustomerAddress> Get()
        {
            return _customerAddressService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<CustomerAddress> Get(int id)
        {
            var customerAddress = _customerAddressService.GetCustomerAddress(id);
            if (customerAddress == null)
            {
                return NotFound(); // Eğer kayıt bulunamazsa 404 döner
            }
            return Ok(customerAddress);
        }
        [HttpPost]
        public void post(CustomerAddress customerAddress)
        {
            _customerAddressService.add(customerAddress);
        }
        
        [HttpPut]
        public void Put(CustomerAddress customerAddress)
        {
            _customerAddressService.update(customerAddress);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _customerAddressService.delete(id);
        }

    }
}


