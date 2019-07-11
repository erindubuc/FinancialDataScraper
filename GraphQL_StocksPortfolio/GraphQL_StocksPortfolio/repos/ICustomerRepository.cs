using GraphQL_StocksPortfolio.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_StocksPortfolio.repos
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetCustomerById(int id);
    }
}
