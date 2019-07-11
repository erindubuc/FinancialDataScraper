using GraphQL.Types;
using GraphQL_StocksPortfolio.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_StocksPortfolio.GraphQL.GraphTypes
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(cust => cust.Id);
            Field(cust => cust.Name);
            Field(cust => cust.City);
            Field(cust => cust.Address);
            Field(cust => cust.State);
            Field(cust => cust.Zipcode);
        }
    }
}
