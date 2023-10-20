namespace AirParkProductions.Domain.Enums
{
    public enum AirParkProductionsErrorEnum
    {
        AirParkProductions_401_UNAUTHORIZED,
        AirParkProductions_404_NOT_FOUND,
        AirParkProductions_500_INTERNAL_SERVER_ERROR,
    }

    public static class AirParkProductionsErrorEnumExtension
    {
        public static string ToString(this AirParkProductionsErrorEnum AirParkProductionsErrorEnum)
        {
            return AirParkProductionsErrorEnum switch
            {
                AirParkProductionsErrorEnum.AirParkProductions_401_UNAUTHORIZED => "Non autorisé",
                AirParkProductionsErrorEnum.AirParkProductions_404_NOT_FOUND => "Non trouvé",
                AirParkProductionsErrorEnum.AirParkProductions_500_INTERNAL_SERVER_ERROR => "Erreur côté serveur",
                _ => "",
            };
        }
    }
}
