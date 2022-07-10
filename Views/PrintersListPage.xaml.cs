namespace OA.Public.Maui.SampleApp.Views;

public partial class PrintersListPage : ContentPage
{
    PrintersListViewModel _viewModel;

    public PrintersListPage(PrintersListViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;

    }

    protected override async void OnAppearing()
    {
        await _viewModel.Refresh();

        base.OnAppearing();
    }
}