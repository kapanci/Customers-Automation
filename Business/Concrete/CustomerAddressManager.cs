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
    public class CustomerAddressManager : ICustomerAddressService
    {
        private readonly ICustomerAddressDal _customerAddress;
        public CustomerAddressManager(ICustomerAddressDal customerAddressDal)
        {
            _customerAddress = customerAddressDal;
        }

        public void add(CustomerAddress customerAddress)
        {
            _customerAddress.Add(customerAddress);
        }

        public void delete(int id)
        {
            _customerAddress.Delete(_customerAddress.Get(id));
        }

        public List<CustomerAddress> GetAll()
        {
            return _customerAddress.GetAll();
        }

        public CustomerAddress GetCustomerAddress(int id)
        {
            return _customerAddress.Get(id);
        }

        public void update(CustomerAddress customerAddress)
        {
            _customerAddress.Update(customerAddress);
        }
    }
}
