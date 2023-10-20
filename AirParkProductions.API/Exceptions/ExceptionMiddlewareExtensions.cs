namespace AirParkProductions.API.Exceptions
{
    /// <summary>
    /// Injecteur du middleware
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Permet d'injecter le middleware des exceptions
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
