using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_StocksPortfolio.entities;

namespace GraphQL_StocksPortfolio.repos
{
    public class CustomerRepository
    {
        private List<Customer> _customers = new List<Customer> {
            new Customer
            {
                Id = 1,
                Name = "Larry",
                Address = "1234 Anywhere street",
                City = "Your town",
                State = "IL",
                Zipcode = "60123"
            },
            new Customer
            {
                Id = 2,
                Name = "Joe",
                Address = "1234 Another street",
                City = "Your other town",
                State = "IL",
                Zipcode = "60124"
            },
            new Customer
            {
                Id = 3,
                Name = "Steve",
                Address = "12 Nowhere street",
                City = "Twilight zone",
                State = "IL",
                Zipcode = "60124"
            }
        };

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
