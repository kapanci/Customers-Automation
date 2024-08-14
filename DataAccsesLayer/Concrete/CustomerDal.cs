using DataAccsesLayer.Abstract;
using DataAccsess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsesLayer.Concrete
{
    public class CustomerDal : ICustomerDal
    {
        private readonly AppDbContext _context;

        public CustomerDal(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.customers.Add(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return _context.customers.ToList();
        }

        public void Update(Customer customer)
        {
            var existingCustomer = _context.customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                // Var olan müşteri bilgilerini güncelle
                existingCustomer.Name = customer.Name;
                existingCustomer.Surname = customer.Surname;
                existingCustomer.TCNo = customer.TCNo;

                // Değişiklikleri kaydet
                _context.SaveChanges();
            }
        }

        public void Delete(Customer customer)
        {
            var existingCustomer = _context.customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                _context.customers.Remove(existingCustomer);
                _context.SaveChanges();
            }
        }

        public Customer Get(int id)
        {
            return _context.customers.FirstOrDefault(c => c.Id == id);
        }
    }
}


