using OA.Public.Maui.SampleApp.ViewModels;

namespace OA.Public.Maui.SampleApp.Views
{
    public partial class PrinterInfoAddEditPage : ContentPage
    {
        private PrinterInfoAddEditViewModel viewModel => BindingContext as PrinterInfoAddEditViewModel;

        public PrinterInfoAddEditPage(PrinterInfoAddEditViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.InitializeAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
