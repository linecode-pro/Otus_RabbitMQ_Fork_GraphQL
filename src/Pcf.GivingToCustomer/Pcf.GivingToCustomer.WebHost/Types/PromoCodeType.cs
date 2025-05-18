using GraphQL.Types;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.WebHost.Types
{
    public class PromoCodeType : ObjectGraphType<PromoCode>
    {
        public PromoCodeType()
        {
            Field(x => x.Id);
            Field(x => x.Code);
            Field(x => x.ServiceInfo);
            Field(x => x.BeginDate);
            Field(x => x.EndDate);
            Field(x => x.PartnerId);
            Field(x => x.PreferenceId);
            Field<PreferenceType>(nameof(PromoCode.Preference));
            Field<ListGraphType<PromoCodeCustomerType>>(nameof(PromoCode.Customers));
        }
    }
}
