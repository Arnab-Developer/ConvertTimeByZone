namespace ConvertTimeByZone.Web;

internal static class MiddlewareExtensions
{
    public static IApplicationBuilder UseLocalization(this IApplicationBuilder app)
    {
        string[] supportedCultures = { "en-US", "en-GB" };
        RequestLocalizationOptions localizationOptions = new();

        localizationOptions
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        IApplicationBuilder applicationBuilder = app.UseRequestLocalization(localizationOptions);
        return applicationBuilder;
    }
}