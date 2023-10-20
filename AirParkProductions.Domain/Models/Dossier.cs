using AirParkProductions.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirParkProductions.Domain.Models
{
    [Table("dossier")]
    public class Dossier : BaseEntity
    {
        [Column("nom")]
        public string Nom { get; set; }

        [Column("utilisateur_id")]
        public int UtilisateurId { get; set; }

        [Column("entreprise_id")]
        public int EntrepriseId { get; set; }

        public virtual Utilisateur Utilisateur { get; set; }
        public virtual Entreprise Entreprise { get; set; }
    }
}
