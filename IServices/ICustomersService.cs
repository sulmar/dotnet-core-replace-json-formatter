using ReplaceJsonFormatter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplaceJsonFormatter.IServices
{
    public interface ICustomersService
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
        void Add(Customer customer);
        void Remove(int id);
    }
}
