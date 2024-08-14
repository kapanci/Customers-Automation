using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsesLayer.Abstract
{
    public interface ICustomerComDal
    {
        List<CustomerCom> GetAll();
        public CustomerCom Get(int id);

        void Add(CustomerCom customerCom);
        
        public void Update(CustomerCom customerCom);
        public void Delete(CustomerCom customerCom);
        
    }
}
