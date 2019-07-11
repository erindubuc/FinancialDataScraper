using GraphQL_StocksPortfolio.entities;
using System;
using System.Collections.Generic;


namespace GraphQL_StocksPortfolio.repos.interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetCustomerById(int id);
    }
}
