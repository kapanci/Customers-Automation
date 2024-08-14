﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        void Add(Customer customer);
        List<Customer> GetAll();
        Customer GetCustomer(int id);

        void Delete(int id);
        void Update(Customer customer);
        
        
    }
}
