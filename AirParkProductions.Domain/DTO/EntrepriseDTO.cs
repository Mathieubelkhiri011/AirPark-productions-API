using AirParkProductions.Domain.Models;

namespace AirParkProductions.Domain.DTO
{
    public class EntrepriseDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Siret { get; set; }
        public ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
