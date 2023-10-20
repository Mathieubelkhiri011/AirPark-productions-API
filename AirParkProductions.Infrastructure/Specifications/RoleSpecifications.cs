using AirParkProductions.Domain.Models;
using AirParkProductions.Infrastructure.Base;
using System.Linq.Expressions;

namespace AirParkProductions.Infrastructure.Specifications
{
    public class RoleSpecifications : BaseSpecifications<Role>
    {
        public RoleSpecifications()
        {
        }

        public RoleSpecifications(Expression<Func<Role, bool>> filterCondition) : base(filterCondition)
        {
        }
    }
}
