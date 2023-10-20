using AirParkProductions.Domain.Enums;

namespace AirParkProductions.Domain.Exceptions
{
    public class AirParkProductionsException : Exception
    {
        public int? StatusCode { get; set; }
        public AirParkProductionsException(string? message)
            : base(message)
        {
        }

        public AirParkProductionsException(int statusCode, string? message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public AirParkProductionsException(int statusCode, string? message, Exception? innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public static AirParkProductionsException Format(AirParkProductionsErrorEnum AirParkProductionsErrorEnum, params object[] values)
        {
            return new AirParkProductionsException(string.Format(AirParkProductionsErrorEnum.ToString(), values));
        }

        public static AirParkProductionsException Format(int statusCode, AirParkProductionsErrorEnum AirParkProductionsErrorEnum, params object[] values)
        {
            return new AirParkProductionsException(statusCode, string.Format(AirParkProductionsErrorEnum.ToString(), values));
        }

        public static AirParkProductionsException Format(Exception ex, int statusCode, AirParkProductionsErrorEnum AirParkProductionsErrorEnum, params object[] values)
        {
            return new AirParkProductionsException(statusCode, string.Format(AirParkProductionsErrorEnum.ToString(), values), ex);
        }
    }
}
