namespace OA.Public.Maui.SampleApp.ViewModels;

public static class ViewModelExtensions
{
    public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<AddEditPrinterViewModel>();

        builder.Services.AddSingleton<PrinterInfoViewModel>();
        builder.Services.AddSingleton<PrinterInfoAddEditViewModel>();
        builder.Services.AddSingleton<PrintersListViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();

        return builder;
    }
}