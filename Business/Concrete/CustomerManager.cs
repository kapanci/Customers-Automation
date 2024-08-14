using Business.Abstract;
using DataAccsesLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(int id)
        {
            // Müşteriyi id'ye göre bul
            var customer = _customerDal.Get(id);
            if (customer != null)
            {
                // Müşteriyi sil
                _customerDal.Delete(customer);
            }
        }
        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _customerDal.Get(id);
            
            return customer;
        }

        public void Update(Customer customer)
        {
            // Müşteriyi id'ye göre bul
            var existingCustomer = _customerDal.Get(customer.Id);
            if (existingCustomer != null)
            {
                _customerDal.Update(customer);
            }
            
        }
        private bool CheckUnusualName(string name)
        {
            var vowels = "aeiouAEIOU";
            return vowels.Any(v => name.Count(c => c == v) >= 3);
        }
    }
}
