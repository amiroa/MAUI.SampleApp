using MvvmHelpers;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    public class PrintersListViewModel : BaseViewModel
    {
        public PrintersListViewModel()
        {
            this.PrinterInfoList = new ObservableCollection<PrinterInfo>()
            {
                new PrinterInfo() { Id = 1, Name = "Main", DisplayName = "Main Printer", Description = "This is the Main printer", 
                    AccessKey = "88b5828b87024c8783b7a95c2081dd", AccessCode = "ofo112233", 
                    CommunicationType = PrinterCommunicationType.Network, NetworkIPAddress = "192.168.192.168", NetworkPort = "9100", IsPrinterMonitorAcvtive = false,
                    CreatedOn = DateTime.Now, IsActive = true
                },
                new PrinterInfo() { Id = 2, Name = "Kitchen", DisplayName = "Kitchen Printer", Description = "This is the Kitchen printer",
                    AccessKey = "88b5828b87024c8783b7a95c2081dd", AccessCode = "ofo112233",
                    CommunicationType = PrinterCommunicationType.Network, NetworkIPAddress = "192.168.192.168", NetworkPort = "9100", IsPrinterMonitorAcvtive = false,
                    CreatedOn = DateTime.Now, IsActive = false
                }
            };
        }

        public ObservableCollection<PrinterInfo> PrinterInfoList { get; set; }
    }
}
