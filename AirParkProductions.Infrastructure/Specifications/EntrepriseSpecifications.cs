using AirParkProductions.Domain.Models;
using AirParkProductions.Infrastructure.Base;
using System.Linq.Expressions;

namespace AirParkProductions.Infrastructure.Specifications
{
    public class EntrepriseSpecifications : BaseSpecifications<Entreprise>
    {
        public EntrepriseSpecifications()
        {
        }

        public EntrepriseSpecifications(Expression<Func<Entreprise, bool>> filterCondition) : base(filterCondition)
        {
        }
    }
}
