using GraphQL.Types;
using GraphQL_StocksPortfolio.GraphQL.GraphTypes;
using GraphQL_StocksPortfolio.repos.interfaces;


namespace GraphQL_StocksPortfolio.GraphQL.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerQuery(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            Field<ListGraphType<CustomerType>>("customers", resolve: context => _customerRepository.GetAll());

            Field<CustomerType>("customer", arguments: new QueryArguments(
                new QueryArgument<IntGraphType>
                { Name = "id"}),
                resolve: 
                context => _customerRepository.GetCustomerById(context.GetArgument<int>("id")));
        }
    }
}
