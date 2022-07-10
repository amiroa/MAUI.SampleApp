using CommunityToolkit.Maui.Behaviors;

namespace OA.Public.Maui.SampleApp.Views
{
    public partial class AddEditPrinterPage : ContentPage
    {
        public AddEditPrinterPage(AddEditPrinterViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            vm.Mode = "Add";

            if (vm.Mode == "Edit")
            {
                Title = "Edit Printer";
            }
            else
            {
                Title = "Add Printer";
            }
        }

        //protected override void OnNavigatedTo(NavigatedToEventArgs args)
        //{
        //    base.OnNavigatedTo(args);
        //}
    }
}