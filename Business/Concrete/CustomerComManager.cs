using Business.Abstract;
using DataAccsesLayer.Abstract;
using DataAccsesLayer.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerComManager : ICustomerComService
    {
        private readonly ICustomerComDal _customerComDal;
        public CustomerComManager(ICustomerComDal customerCom)
        {
            _customerComDal = customerCom;
        }

        public void Add(CustomerCom customerCom)
        {
            _customerComDal.Add(customerCom);
        }
        public List<CustomerCom> GetAll()
        {
            return _customerComDal.GetAll();
        }

        public void update(CustomerCom customerCom)
        {
            _customerComDal.Update(customerCom);
        }

        public CustomerCom GetCustomerCom(int id)
        {
            return (_customerComDal.Get(id));
        }

        public void Delete(int id)
        {
            var Com = _customerComDal.Get(id);
            _customerComDal.Delete(Com);

        }
    }
}
