using OA.Public.Maui.SampleApp.Services.Database;
using System.ComponentModel.DataAnnotations;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    [QueryProperty(nameof(PrinterId), nameof(PrinterId))]
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

        public string PrinterId { get; set; }

        #endregion


        public AddEditPrinterViewModel()
        {           
            ResetObjects();
        }

        public async Task LoadForm()
        {
            id = !string.IsNullOrEmpty(PrinterId) ? Convert.ToInt32(PrinterId) : null;
            PrinterId = string.Empty;
            if (id != null)
            {
                Mode = "Edit";
                PrinterInfo = await DatabaseService.Get<PrinterInfo>(id);
                if (PrinterInfo != null)
                {                    
                    Name = PrinterInfo.Name;
                    AccessKey = PrinterInfo.AccessKey;
                    AccessCode = PrinterInfo.AccessCode;
                    IsActive = PrinterInfo.IsActive;
                    DisplayName = PrinterInfo.DisplayName;
                    Description = PrinterInfo.Description;
                    CommunicationType = PrinterInfo.CommunicationType.ToString();
                    SerialComPort = PrinterInfo.SerialComPort.ToString();
                    SerialBaudRate = PrinterInfo.SerialBaudRate;
                    NetworkIPAddress = PrinterInfo.NetworkIPAddress;
                    NetworkPort = PrinterInfo.NetworkPort;
                    IsPrinterMonitorActive = PrinterInfo.IsPrinterMonitorActive;
                }
            } else
            {
                ResetObjects();
            }
        }

        [RelayCommand]
        private async void Create()
        {
            try
            {
                ValidateAllProperties();

                if (HasErrors)
                {
                    var formErrors = GetErrors();
                    App.AlertSvc.ShowAlert("Oops!", $"Please provide all the required values in the form. {formErrors.FirstOrDefault()?.ErrorMessage}");
                    return;
                }

                PrinterInfo.Name = name;
                PrinterInfo.AccessKey = accessKey;
                PrinterInfo.AccessCode = accessCode;
                PrinterInfo.IsActive = isActive;
                PrinterInfo.DisplayName = displayName;
                PrinterInfo.Description = description;
                PrinterInfo.CommunicationType = communicationType;
                PrinterInfo.IsPrinterMonitorActive = isPrinterMonitorActive;
                if (communicationType == PrinterCommunicationType.Network.ToString())
                {
                    if (string.IsNullOrEmpty(networkIPAddress) || string.IsNullOrEmpty(networkPort))
                    {
                        App.AlertSvc.ShowAlert("Oops!", "Please provide network communication details.");
                        return;
                    }

                    PrinterInfo.NetworkIPAddress = networkIPAddress;
                    PrinterInfo.NetworkPort = networkPort;
                    PrinterInfo.SerialComPort = string.Empty;
                    PrinterInfo.SerialBaudRate = 115200;
                }
                else //Serial
                {
                    if (string.IsNullOrEmpty(serialComPort) || serialBaudRate <= 0)
                    {
                        App.AlertSvc.ShowAlert("Oops!", "Please provide serial communication details.");
                        return;
                    }
                    PrinterInfo.SerialComPort = serialComPort;
                    PrinterInfo.SerialBaudRate = serialBaudRate;
                    PrinterInfo.NetworkIPAddress = string.Empty;
                    PrinterInfo.NetworkPort = "9100";
                }

                if (id != null)//(Mode == "Edit")
                {
                    await DatabaseService.Update(PrinterInfo);
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


        public void ResetObjects()
        {
            Mode = "Add";

            Name = string.Empty;
            AccessKey = string.Empty;
            AccessCode = string.Empty;
            IsActive = true;
            DisplayName = string.Empty;
            Description = string.Empty;
            CommunicationType = PrinterCommunicationType.Network.ToString();
            NetworkIPAddress = string.Empty;
            NetworkPort = "9100"; //default port
            SerialBaudRate = 115200; //default baud rate
            SerialComPort = string.Empty;
            IsPrinterMonitorActive = false;

            PrinterInfo = new PrinterInfo();
            PrinterInfo.IsActive = isActive;
            PrinterInfo.CommunicationType = communicationType;
        }
    }
}
