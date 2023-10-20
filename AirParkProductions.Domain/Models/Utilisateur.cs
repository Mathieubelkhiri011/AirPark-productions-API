using AirParkProductions.Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirParkProductions.Domain.Models
{
    [Table("utilisateur")]
    public class Utilisateur : BaseEntity
    {
        [Column("prenom")]
        public string Prenom { get; set; }

        [Column("nom")]
        public string Nom { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("actif")]
        [DefaultValue(true)]
        public bool Actif { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("entreprise_id")]
        public int EntrepriseId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Entreprise Entreprise { get; set; }
        public virtual ICollection<Dossier> Dossiers { get; set; }
    }
}
