using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerComService
    {
        
        List<CustomerCom> GetAll();
        CustomerCom GetCustomerCom(int id);
        void Add(CustomerCom customerCom);
        void update(CustomerCom customerCom);

        public void Delete(int id);
        

        
    }
}
