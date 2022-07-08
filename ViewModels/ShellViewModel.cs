namespace OA.Public.Maui.SampleApp.ViewModels;

public class ShellViewModel
{
    public AppSection Main { get; set; }
    public AppSection PrintersList { get; set; }
    public AppSection Settings { get; set; }
    public AppSection About { get; set; }

    public ShellViewModel()
    {
        Main = new AppSection() { Title = "Printers", TargetType = typeof(MainPage) };
        //PrintersList = new AppSection() { Title = "Printers" , Icon = "printer.png", IconDark= "printer.png", TargetType = typeof(PrintersListView) };
        //Settings = new AppSection() { Title = AppResource.Settings, Icon = "settings.png", IconDark="settings.png", TargetType = typeof(SettingsPage) };
        //About = new AppSection() { Title = AppResource.About, Icon = "about.png", IconDark = "about.png", TargetType = typeof(AboutPage) };
    }
}
