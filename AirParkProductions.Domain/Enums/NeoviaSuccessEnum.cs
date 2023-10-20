namespace AirParkProductions.Domain.Enums
{
    public enum AirParkProductionsSuccessEnum
    {
        AirParkProductions_201_ENTITY_CREATE,
        AirParkProductions_200_ENTITY_UPDATE,
        AirParkProductions_204_ENTITY_DELETE,
    }

    public static class AirParkProductionsSuccessEnumExtension
    {
        public static string ToString(this AirParkProductionsSuccessEnum AirParkProductionsSuccessEnum)
        {
            return AirParkProductionsSuccessEnum switch
            {
                AirParkProductionsSuccessEnum.AirParkProductions_201_ENTITY_CREATE => "Entité {0} ajoutée : {1}",
                AirParkProductionsSuccessEnum.AirParkProductions_200_ENTITY_UPDATE => "Entité {0} modifiée : {1}",
                AirParkProductionsSuccessEnum.AirParkProductions_204_ENTITY_DELETE => "Entité {0} supprimée : {1}",
                _ => "",
            };
        }

        public static string Format(this AirParkProductionsSuccessEnum AirParkProductionsSuccessEnum, params object[] values)
        {
            return string.Format(AirParkProductionsSuccessEnum.ToString(), values);
        }
    }
}
