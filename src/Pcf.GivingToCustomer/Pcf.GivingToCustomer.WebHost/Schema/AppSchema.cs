using Microsoft.Extensions.DependencyInjection;
using Pcf.GivingToCustomer.WebHost.Mutations;
using Pcf.GivingToCustomer.WebHost.Queries;
using System;

namespace Pcf.GivingToCustomer.WebHost.Schema
{

    public class AppSchema : GraphQL.Types.Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<CustomerQuery>();
            Mutation = provider.GetRequiredService<CustomerMutation>();
        }
    }
}
