using GraphQL.Types;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.WebHost.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Name = "Customer";

            Field<NonNullGraphType<IdGraphType>>("id")
                .Resolve(context => context.Source.Id);

            Field<NonNullGraphType<StringGraphType>>("firstName")
                .Resolve(context => context.Source.FirstName);

            Field<NonNullGraphType<StringGraphType>>("lastName")
                .Resolve(context => context.Source.LastName);

            Field<StringGraphType>("fullName")
                .Resolve(context => $"{context.Source.FirstName} {context.Source.LastName}");

            Field<NonNullGraphType<StringGraphType>>("email")
                .Resolve(context => context.Source.Email);

            Field<ListGraphType<CustomerPreferenceType>>("preferences")
                .Resolve(context => context.Source.Preferences);

            Field<ListGraphType<PromoCodeCustomerType>>("promoCodes")
                .Resolve(context => context.Source.PromoCodes);
        }
    }
}
