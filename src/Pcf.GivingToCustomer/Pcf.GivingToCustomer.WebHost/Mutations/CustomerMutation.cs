using GraphQL;
using GraphQL.Types;
using Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.WebHost.Input;
using Pcf.GivingToCustomer.WebHost.Mappers;
using Pcf.GivingToCustomer.WebHost.Models;
using Pcf.GivingToCustomer.WebHost.Queries;
using Pcf.GivingToCustomer.WebHost.Types;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Pcf.GivingToCustomer.WebHost.Mutations
{
    public class CustomerMutation : ObjectGraphType
    {
        public CustomerMutation(
            IRepository<Customer> customerRepository,
            IRepository<Preference> preferenceRepository)
        {
            Name = "CustomerMutation";

            Field<CustomerType>("createCustomer")
                .Argument<NonNullGraphType<CreateCustomerInputType>>("input")
                .ResolveAsync(async context =>
                {
                    var input = context.GetArgument<CreateOrEditCustomerRequest>("input");

                    var preferences = await preferenceRepository
                        .GetRangeByIdsAsync(input.PreferenceIds);

                    var customer = CustomerMapper.MapFromModel(input, preferences);

                    await customerRepository.AddAsync(customer);

                    return customer;
                });

            Field<CustomerType>("updateCustomer")
                .Argument<NonNullGraphType<GuidGraphType>>("id")
                .Argument<NonNullGraphType<CreateCustomerInputType>>("input")
                .ResolveAsync(async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var input = context.GetArgument<CreateOrEditCustomerRequest>("input");

                    var customer = await customerRepository.GetByIdAsync(id);
                    if (customer == null) return null;

                    var preferences = await preferenceRepository
                        .GetRangeByIdsAsync(input.PreferenceIds);

                    CustomerMapper.MapFromModel(input, preferences, customer);

                    await customerRepository.UpdateAsync(customer);

                    return customer;
                });

            Field<GuidGraphType>("deleteCustomer")
                .Argument<NonNullGraphType<GuidGraphType>>("id")
                .ResolveAsync(async context =>
                {
                    var id = context.GetArgument<Guid>("id");

                    var customer = await customerRepository.GetByIdAsync(id);
                    if (customer == null) return Guid.Empty;

                    await customerRepository.DeleteAsync(customer);

                    return customer.Id;
                });
        }
    }
}
