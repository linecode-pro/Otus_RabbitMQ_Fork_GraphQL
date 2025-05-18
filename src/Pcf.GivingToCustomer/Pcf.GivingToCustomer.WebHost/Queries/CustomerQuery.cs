using GraphQL;
using GraphQL.Types;
using Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.WebHost.Types;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Pcf.GivingToCustomer.WebHost.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery(IRepository<Customer> customerRepository)
        {
            Name = "CustomerQuery";

            Field<ListGraphType<CustomerType>>("customers")
                .ResolveAsync(async context => await customerRepository.GetAllAsync());

            Field<CustomerType>("customer")
                .Argument<NonNullGraphType<GuidGraphType>>("id")
                .ResolveAsync(async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return await customerRepository.GetByIdAsync(id);
                });
        }
    }

    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Guid> PreferenceIds { get; set; }
    }
}
