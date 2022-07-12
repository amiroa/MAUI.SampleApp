using CommunityToolkit.Maui.Behaviors;

namespace OA.Public.Maui.SampleApp.Views
{
    public partial class AddEditPrinterPage : ContentPage
    {
        AddEditPrinterViewModel _vm;
        public AddEditPrinterPage(AddEditPrinterViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
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

        private void selectedPrinterCommunicationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (_vm != null && selectedIndex != -1)
            {
                _vm.CommunicationType = (string)picker.ItemsSource[selectedIndex];
                //App.AlertSvc.ShowAlert("Test", _vm.PrinterInfo.CommunicationType.ToString());
                //App.AlertSvc.ShowAlert("Test", (string)picker.ItemsSource[selectedIndex]);
                //_vm.PrinterInfo.CommunicationType = (string)picker.ItemsSource[selectedIndex];
            }
        }

        //protected override void OnNavigatedTo(NavigatedToEventArgs args)
        //{
        //    base.OnNavigatedTo(args);
        //}
    }
}