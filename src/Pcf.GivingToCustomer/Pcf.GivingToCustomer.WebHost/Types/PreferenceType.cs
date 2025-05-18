using GraphQL.Types;
using Pcf.GivingToCustomer.Core.Domain;
using System.Xml.Linq;

namespace Pcf.GivingToCustomer.WebHost.Types
{
    public class PreferenceType : ObjectGraphType<Preference>
    {
        public PreferenceType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
