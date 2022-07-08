namespace OA.Public.Maui.SampleApp.Views;

public static class PagesExtensions
{
    public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
    {
        // main tabs of the app
        builder.Services.AddSingleton<PrintersListView>();
        //builder.Services.AddSingleton<AddEditPrinterPage>();
        builder.Services.AddSingleton<AboutPage>();
        builder.Services.AddSingleton<SettingsPage>();

        return builder;
    }
}