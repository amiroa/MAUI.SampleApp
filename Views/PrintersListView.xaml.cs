namespace OA.Public.Maui.SampleApp.Views;

public partial class PrintersListView : ContentPage
{
    public PrintersListView(PrintersListViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}