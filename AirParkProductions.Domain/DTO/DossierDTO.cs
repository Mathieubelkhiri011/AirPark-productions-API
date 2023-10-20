namespace AirParkProductions.Domain.DTO
{
    public class DossierDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int UtilisateurId { get; set; }
        public int EntrepriseId { get; set; }
    }
}
