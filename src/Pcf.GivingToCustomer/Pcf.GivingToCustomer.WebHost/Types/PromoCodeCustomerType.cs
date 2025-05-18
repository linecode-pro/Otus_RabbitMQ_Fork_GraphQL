using GraphQL.Types;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.WebHost.Types
{
    public class PromoCodeCustomerType : ObjectGraphType<PromoCodeCustomer>
    {
        public PromoCodeCustomerType()
        {
            Field(x => x.PromoCodeId);
            Field(x => x.CustomerId);
        }
    }
}
