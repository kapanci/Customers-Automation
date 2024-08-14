using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsesLayer.Abstract
{
    public interface ICustomerAddressDal
    {
        public List<CustomerAddress> GetAll();
        public CustomerAddress Get(int id);

        public void Add(CustomerAddress address);
        
        public void Update(CustomerAddress address);
        public void Delete(CustomerAddress address);
        
    }
}
