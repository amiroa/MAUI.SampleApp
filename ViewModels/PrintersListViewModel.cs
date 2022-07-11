using MvvmHelpers;
using MvvmHelpers.Commands;
using OA.Public.Maui.SampleApp.Services.Database;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    public class PrintersListViewModel : BaseViewModel
    {      
        public ObservableCollection<PrinterInfo> PrinterInfoList { get; set; }
        
        public AsyncCommand RefreshCommand { get; }                
        public AsyncCommand AddCommand { get; }        
        public AsyncCommand<PrinterInfo> RemoveCommand { get; }
        public AsyncCommand<PrinterInfo> EditCommand { get; }


        public PrintersListViewModel()
        {            
            Title = "Printers";

            PrinterInfoList = new ObservableCollection<PrinterInfo>();
            
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<PrinterInfo>(Remove);
            EditCommand = new AsyncCommand<PrinterInfo>(Edit);
        }

        async Task Add()
        {
            await DatabaseService.Add(new PrinterInfo()
            {
                Id = 2,
                Name = "Kitchen",
                DisplayName = "Kitchen Printer",
                Description = "This is the Kitchen printer",
                AccessKey = "88b5828b87024c8783b7a95c2081dd",
                AccessCode = "ofo112233",
                CommunicationType = PrinterCommunicationType.Network.ToString(),
                NetworkIPAddress = "192.168.192.168",
                NetworkPort = "9100",
                IsPrinterMonitorActive = false,
                CreatedOn = DateTime.Now,
                IsActive = false
            });
            await Refresh();
        }

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

        async Task Edit(PrinterInfo printerInfo)
        {
            //Edit record
            await Refresh();
        }

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
