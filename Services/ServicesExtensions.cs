namespace OA.Public.Maui.SampleApp.Services;

public static class ServicesExtensions
{
    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAlertService, AlertService>();

#if WINDOWS
#elif ANDROID
#elif MACCATALYST
#elif IOS
#endif

        return builder;
    }

}