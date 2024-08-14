using DataAccsesLayer.Abstract;
using DataAccsess.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsesLayer.Concrete
{
    public class CustomerComDal : ICustomerComDal
    {
        private readonly AppDbContext _contextCom;

        public CustomerComDal(AppDbContext context)
        {
            _contextCom = context;
        }

        public void Add(CustomerCom customerCom)
        {
            _contextCom.customerComs.Add(customerCom);
            _contextCom.SaveChanges(); 
        }

        public void Delete(CustomerCom customerCom)
        {
            _contextCom.customerComs.Remove(customerCom);
            _contextCom.SaveChanges();
        }

        public CustomerCom Get(int id)
        {
            return _contextCom.customerComs.FirstOrDefault(c => c.Id == id);
        }

        public List<CustomerCom> GetAll()
        {
            return _contextCom.customerComs.ToList();  
        }

        public void Update(CustomerCom customerCom)
        {
            var existingCustomer = _contextCom.customerComs.FirstOrDefault(c => c.Id == customerCom.Id);
            if (existingCustomer != null)
            {
                // Var olan müşteri bilgilerini güncelle
                existingCustomer.Type = customerCom.Type;
                existingCustomer.Data = customerCom.Data;

                // Değişiklikleri kaydet
                _contextCom.SaveChanges();
            }
        }
    }
}
