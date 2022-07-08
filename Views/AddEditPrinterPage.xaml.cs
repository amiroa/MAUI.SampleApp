using CommunityToolkit.Maui.Behaviors;

namespace OA.Public.Maui.SampleApp.Views
{
    public partial class AddEditPrinterPage : ContentPage
    {
        public AddEditPrinterPage(AddEditPrinterViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
        }
    }
}