namespace OA.Public.Maui.SampleApp.Views;

public partial class DesktopShell
{
    public DesktopShell()
    {
        InitializeComponent();

        BindingContext = new ShellViewModel();
    }
}
