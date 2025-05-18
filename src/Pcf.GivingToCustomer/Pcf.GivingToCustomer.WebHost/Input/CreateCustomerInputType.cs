using GraphQL.Types;
using System.Xml.Linq;

namespace Pcf.GivingToCustomer.WebHost.Input
{
    public class CreateCustomerInputType : InputObjectGraphType
    {
        public CreateCustomerInputType()
        {
            Name = "CreateCustomerInput";

            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<ListGraphType<NonNullGraphType<GuidGraphType>>>(name: "preferenceIds");
        }
    }
}
