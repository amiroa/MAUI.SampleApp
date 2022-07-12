namespace OA.Public.Maui.SampleApp.Views;

public static class PagesExtensions
{
    public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<AddEditPrinterPage>();

        builder.Services.AddSingleton<PrinterInfoAddEditPage>();
        builder.Services.AddSingleton<PrintersListPage>();
        builder.Services.AddSingleton<AboutPage>();
        builder.Services.AddSingleton<SettingsPage>();

        return builder;
    }
}