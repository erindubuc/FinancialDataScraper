using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_StocksPortfolio.GraphQL.Schema
{
    public class CustomerSchema : Schema
    {
        public CustomerSchema(IDependencyResolver resolver) : base (resolver)
        {
            Queryable = resolver.Resolve<CustomerQuery>();
        }
    }
}
