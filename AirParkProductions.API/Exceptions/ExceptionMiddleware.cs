using AirParkProductions.Domain.Exceptions;
using System.Text.Json;

namespace AirParkProductions.API.Exceptions
{
    /// <summary>
    /// Middleware permettant de catch les exceptions et de les retourner 
    /// 
    /// Décommenter appInsights pour l'activer
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly TelemetryClient _appInsights;

        /// <summary>
        /// Constructeur du middleware
        /// </summary>
        /// <param name="next"></param>
        /// <param name="appInsights"></param>
        public ExceptionMiddleware(
            RequestDelegate next
        //TelemetryClient appInsights
        )
        {
            //_appInsights = appInsights;
            _next = next;
        }

        /// <summary>
        /// Chaque appel API passe par cette méthode avant d'être envoyé
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AirParkProductionsException ex)
            {
                //_appInsights.TrackException(ex);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Permet de transformer l'exception retournée en message d'erreur 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static async Task HandleExceptionAsync(HttpContext context, AirParkProductionsException exception)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = exception.StatusCode ?? StatusCodes.Status500InternalServerError;
            ErrorDetails responseModel = new()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message ?? "Internal Server Error",
                InnerException = exception?.InnerException?.Message,
                Source = exception?.Source,
                StackTrace = exception?.StackTrace
            };

            string result = JsonSerializer.Serialize(responseModel, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            await response.WriteAsync(result);
        }
    }
}