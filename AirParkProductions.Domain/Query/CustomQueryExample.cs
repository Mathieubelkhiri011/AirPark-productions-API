using System.ComponentModel.DataAnnotations.Schema;

namespace AirParkProductions.Domain.Query
{
    [NotMapped]
    public class CustomQueryExample
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }
}
