using ReplaceJsonFormatter.IServices;
using ReplaceJsonFormatter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using System.Collections;

namespace ReplaceJsonFormatter.Services
{
    public class FakeCustomersService : ICustomersService
    {
        private ICollection<Customer> customers;

        public FakeCustomersService()
        {
            var faker = new Faker<Customer>()
              .StrictMode(true)
              .RuleFor(p => p.Id, f => f.IndexFaker)
              .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
              .RuleFor(p => p.FirstName, (f, p) => f.Name.FirstName())
              .RuleFor(p => p.LastName, (f, p) => f.Name.LastName())
              .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
              .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
              .RuleFor(u => u.CreatedOn, f=>f.Date.Past());

            customers = faker.Generate(10000);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }
    }
}
