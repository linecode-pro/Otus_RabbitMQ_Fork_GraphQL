using GraphQL.Types;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.WebHost.Types
{
    public class CustomerPreferenceType : ObjectGraphType<CustomerPreference>
    {
        public CustomerPreferenceType()
        {
            Field(x => x.CustomerId);
            Field(x => x.PreferenceId);
            Field<PreferenceType>(nameof(CustomerPreference.Preference));
        }
    }
}
