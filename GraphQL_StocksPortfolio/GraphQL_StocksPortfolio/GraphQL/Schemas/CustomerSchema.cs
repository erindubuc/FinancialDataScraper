using GraphQL;
using GraphQL.Types;
using GraphQL_StocksPortfolio.GraphQL.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_StocksPortfolio.GraphQL.Schemas
{
    public class CustomerSchema : Schema
    {
        public CustomerSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CustomerQuery>();
        }
    }
}
