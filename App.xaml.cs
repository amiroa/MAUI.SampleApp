using Application = Microsoft.Maui.Controls.Application;

namespace OA.Public.Maui.SampleApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        TheTheme.SetTheme();

        if (Config.Desktop)
            MainPage = new DesktopShell();
        else
            MainPage = new MobileShell();

        Routing.RegisterRoute(nameof(PrintersListView), typeof(PrintersListView));
        Routing.RegisterRoute(nameof(AddEditPrinterPage), typeof(AddEditPrinterPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));

    }
}
