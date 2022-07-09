namespace OA.Public.Maui.SampleApp.Views;

public partial class PrintersListPage : ContentPage
{
    public PrintersListPage(PrintersListViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}