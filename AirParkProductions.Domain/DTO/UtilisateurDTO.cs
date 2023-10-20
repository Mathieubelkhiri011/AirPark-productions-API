namespace AirParkProductions.Domain.DTO
{
    public class UtilisateurDTO
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public bool Actif { get; set; }
        public int RoleId { get; set; }
        public int EntrepriseId { get; set; }
    }
}
