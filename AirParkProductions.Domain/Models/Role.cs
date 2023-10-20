using AirParkProductions.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirParkProductions.Domain.Models
{
    [Table("role")]
    public class Role : BaseEntity
    {
        [Column("nom")]
        public string Nom { get; set; }
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
