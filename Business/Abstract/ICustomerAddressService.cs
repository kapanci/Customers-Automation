using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerAddressService
    {
        void add(CustomerAddress customerAddress);
        List<CustomerAddress> GetAll();
        void delete(int id);
        void update(CustomerAddress customerAddress);
        CustomerAddress GetCustomerAddress(int id);

    }
}
