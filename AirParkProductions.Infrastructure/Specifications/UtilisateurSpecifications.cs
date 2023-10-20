using AirParkProductions.Domain.Models;
using AirParkProductions.Infrastructure.Base;
using System.Linq.Expressions;

namespace AirParkProductions.Infrastructure.Specifications
{
    public class UtilisateurSpecifications : BaseSpecifications<Utilisateur>
    {
        public UtilisateurSpecifications()
        {
        }

        public UtilisateurSpecifications(Expression<Func<Utilisateur, bool>> filterCondition) : base(filterCondition)
        {
        }
    }
}
