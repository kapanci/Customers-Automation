using Business.Abstract;
using DataAccsesLayer.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public List<Customer> Get()
        {
            return _customerService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound(); 
            }
            return Ok(customer);
        }
        [HttpPost]
        public void Post(Customer customer)
        {
            _customerService.Add(customer); 
        }
       
        [HttpPut]
        public void Put(Customer customer)
        {
            _customerService.Update(customer);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }

    }
}

