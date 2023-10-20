using AirParkProductions.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirParkProductions.Domain.Models
{
    [Table("entreprise")]
    public class Entreprise : BaseEntity
    {
        [Column("nom")]
        public string Nom { get; set; }
        [Column("siret")]
        public string Siret { get; set; }

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
        public virtual ICollection<Dossier> Dossiers { get; set; }
    }
}
