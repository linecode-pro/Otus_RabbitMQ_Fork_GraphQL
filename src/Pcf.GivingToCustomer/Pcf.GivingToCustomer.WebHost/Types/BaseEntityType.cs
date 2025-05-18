using GraphQL.Types;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.WebHost.Types
{
    public class BaseEntityType : ObjectGraphType<BaseEntity>
    {
        public BaseEntityType()
        {
            Field(x => x.Id);
        }
    }
}
