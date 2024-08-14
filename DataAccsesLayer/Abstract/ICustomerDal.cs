using DataAccsesLayer.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsesLayer.Abstract
{
    public interface ICustomerDal
    {
        public List<Customer> GetAll();
        public Customer Get(int id);

        public void Add(Customer customer);
        
        public void Update(Customer customer);
        public void Delete(Customer customer);

    }
}
