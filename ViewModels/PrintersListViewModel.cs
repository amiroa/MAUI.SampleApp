using OA.Public.Maui.SampleApp.Services.Database;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    public partial class PrintersListViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private bool isBusy;

        public ObservableCollection<PrinterInfo> PrinterInfoList { get; set; }
        
        public PrintersListViewModel()
        {            
            Title = "Printers";

            PrinterInfoList = new ObservableCollection<PrinterInfo>();            
        }

        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.GoToAsync($"{nameof(AddEditPrinterPage)}");
            //await Refresh();
        }

        [RelayCommand]
        async Task Remove(PrinterInfo printerInfo)
        {
            App.AlertSvc.ShowConfirmation("Warning", "Are you sure you want to delete the selcted Printer?", (async (result) =>
            {
                if (result)
                {
                    await DatabaseService.Remove(printerInfo);
                    await Refresh();
                }
            }));
        }

        [RelayCommand]
        async Task Edit(PrinterInfo printerInfo)
        {
            //Edit record
            await Shell.Current.GoToAsync($"{nameof(AddEditPrinterPage)}?PrinterId={printerInfo.Id}");
            //await Refresh();
        }

        [RelayCommand]
        public async Task Refresh()
        {
            IsBusy = true;

            //Reload list
            PrinterInfoList.Clear();
            var printers = await DatabaseService.GetAll<PrinterInfo>();
            printers.ForEach(p => PrinterInfoList.Add(p));

            IsBusy = false;
        }

    }
}
