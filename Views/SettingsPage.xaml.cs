namespace OA.Public.Maui.SampleApp.Views;

public partial class SettingsPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}