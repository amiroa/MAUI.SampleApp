namespace OA.Public.Maui.SampleApp.Views;

public partial class PrintersListView : Grid
{
    public PrintersListView(PrintersListViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}