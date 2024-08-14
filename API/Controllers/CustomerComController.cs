using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerComController : ControllerBase
    {
        private readonly ICustomerComService _customerComService;

        public CustomerComController(ICustomerComService customerComService)
        {
            _customerComService = customerComService;
        }
        [HttpGet]
            public List<CustomerCom> Get()
            {
            return _customerComService.GetAll();
            }
        [HttpGet("{id}")]
        public ActionResult<CustomerCom> Get(int id)
        {
            var customerCom = _customerComService.GetCustomerCom(id);
            if (customerCom == null)
            {
                return NotFound(); // Eğer kayıt bulunamazsa 404 döner
            }
            return Ok(customerCom);
        }
        [HttpPost]
        public void Post(CustomerCom customerCom)
        {
            _customerComService.Add(customerCom);
        }
        [HttpPut]
        public void Put(CustomerCom customerCom)
        {
            _customerComService.update(customerCom);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _customerComService.Delete(id);
        }

        
        
    }
}

