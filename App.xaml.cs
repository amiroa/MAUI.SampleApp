using Application = Microsoft.Maui.Controls.Application;

namespace OA.Public.Maui.SampleApp;

public partial class App : Application
{
    public static IServiceProvider Services;
    public static IAlertService AlertSvc;

    public App(IServiceProvider provider)
	{
		InitializeComponent();

        Services = provider;
        AlertSvc = Services.GetService<IAlertService>();

        TheTheme.SetTheme();

        if (Config.Desktop)
            MainPage = new DesktopShell();
        else
            MainPage = new MobileShell();

        Routing.RegisterRoute(nameof(AddEditPrinterPage), typeof(AddEditPrinterPage));        
        Routing.RegisterRoute(nameof(PrintersListPage), typeof(PrintersListPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));

    }
}
