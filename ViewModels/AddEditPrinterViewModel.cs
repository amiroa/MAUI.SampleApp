using OA.Public.Maui.SampleApp.Services.Database;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SQLite.SQLite3;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    public partial class AddEditPrinterViewModel : ObservableValidator
    {
        #region properties
        [ObservableProperty]
        private int? id;

        [ObservableProperty]
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        private string name;

        [ObservableProperty]
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        private string accessKey;

        [ObservableProperty]
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        private string accessCode;

        [ObservableProperty]
        private bool isActive;

        [ObservableProperty]
        [MaxLength(512)]
        private string displayName;

        [ObservableProperty]
        [MaxLength(2048)]
        private string description;

        [ObservableProperty]
        [Required]
        private string communicationType;

        [ObservableProperty]
        [MaxLength(10)]
        private string serialComPort;

        [ObservableProperty]
        private int serialBaudRate;

        [ObservableProperty]
        [MaxLength(15)]
        private string networkIPAddress;

        [ObservableProperty]
        [MaxLength(8)]
        private string networkPort;

        [ObservableProperty]
        private bool isPrinterMonitorActive;


        public PrinterInfo PrinterInfo { get; set; }

        public string Mode { get; set; }

        public IEnumerable<string> SerialComPorts { get => Enum.GetValues(typeof(SerialComPort)).Cast<SerialComPort>().Select(v => v.ToString()).ToList(); }

        public IEnumerable<string> PrinterCommunicationTypes { get => Enum.GetValues(typeof(PrinterCommunicationType)).Cast<PrinterCommunicationType>().Select(v => v.ToString()).ToList(); }
        #endregion


        public AddEditPrinterViewModel()
        {
            if (id == null)
                ResetObjects();
        }

        [RelayCommand]
        private async void Create()
        {
            try
            {
                ValidateAllProperties();

                if (HasErrors)
                {
                    App.AlertSvc.ShowAlert("Oops!", "Please provide all the required values in the form.");
                    return;
                }

                PrinterInfo.Name = name;
                PrinterInfo.AccessKey = accessKey;
                PrinterInfo.AccessCode = accessCode;
                PrinterInfo.IsActive = isActive;
                PrinterInfo.DisplayName = displayName;
                PrinterInfo.Description = description;
                PrinterInfo.CommunicationType = communicationType;
                if(communicationType == PrinterCommunicationType.Network.ToString())
                {
                    if(string.IsNullOrEmpty(networkIPAddress) || string.IsNullOrEmpty(networkPort))
                    {
                        App.AlertSvc.ShowAlert("Oops!", "Please provide network communication details.");
                        return;
                    }

                    PrinterInfo.NetworkIPAddress = networkIPAddress;
                    PrinterInfo.NetworkPort = networkPort;
                }
                else //Serial
                {
                    if (string.IsNullOrEmpty(networkIPAddress) || string.IsNullOrEmpty(networkPort))
                    {
                        App.AlertSvc.ShowAlert("Oops!", "Please provide serial communication details.");
                        return;
                    }
                    PrinterInfo.SerialComPort = serialComPort;
                    PrinterInfo.SerialBaudRate = serialBaudRate;
                }

                PrinterInfo.IsPrinterMonitorActive = IsPrinterMonitorActive;

                if (id != null)//(Mode == "Edit")
                {
                    await DatabaseService.Add(PrinterInfo);
                    App.AlertSvc.ShowAlert("Edit Printer", "Printer details updated succsessfully.");
                }
                else
                {
                    await DatabaseService.Add(PrinterInfo);
                    App.AlertSvc.ShowAlert("Add Printer", "Printer added succsessfully.");
                }

                ResetObjects();
                await Shell.Current.GoToAsync($"{nameof(PrintersListPage)}");
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                App.AlertSvc.ShowAlert("Oops!", "Something went wrong! Please try again later.");
            }
        }


        private void ResetObjects()
        {
            name = string.Empty;
            accessKey = string.Empty;
            accessCode = string.Empty;
            isActive = true;
            displayName = string.Empty;
            description = string.Empty;
            communicationType = PrinterCommunicationType.Network.ToString();
            networkIPAddress = string.Empty;
            networkPort = string.Empty;
            serialBaudRate = 0;
            serialComPort = string.Empty;
            isPrinterMonitorActive = false;

            PrinterInfo = new PrinterInfo();
            PrinterInfo.CommunicationType = communicationType;
            PrinterInfo.IsActive = isActive;
        }
    }
}
