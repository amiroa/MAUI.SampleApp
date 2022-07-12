using System.ComponentModel;
using static SQLite.SQLite3;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    public partial class AddEditPrinterViewModel : ObservableObject
    {
        private bool _archived;
        private string _id;


        [ObservableProperty]
        private string communicationType;

        public PrinterInfo PrinterInfo { get; set; }

        public string Mode { get; set; }

        public IEnumerable<string> SerialComPorts { get => Enum.GetValues(typeof(SerialComPort)).Cast<SerialComPort>().Select(v => v.ToString()).ToList(); }

        public IEnumerable<string> PrinterCommunicationTypes { get => Enum.GetValues(typeof(PrinterCommunicationType)).Cast<PrinterCommunicationType>().Select(v => v.ToString()).ToList(); }



        public AddEditPrinterViewModel()
        {
            PrinterInfo = new PrinterInfo();
        }



        //[RelayCommand]
        //private void CommunicationTypeChanged(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    int selectedIndex = picker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        communicationType = (string)picker.ItemsSource[selectedIndex];
        //    }
            
        //}

        [RelayCommand]
        private async void Create()
        {
            try
            {
                if (Mode == "Edit")
                {
                    var model = new PrinterInfo()
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
                    };
                    var wasUpdated = true; // await _taskRepository.Update(model);
                    //if(wasUpdated)
                    //{
                    //    await _navigationService.GoBackAsync();
                    //}
                    //else
                    //{
                    //    var param = new DialogParameters()
                    //    {
                    //        { "message", Constants.Errors.GeneralError }
                    //    };
                    //    _dialogService.ShowDialog(nameof(ErrorDialog), param);
                    //}
                }
                else
                {
                    var model = new PrinterInfo()
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
                    };
                    var wasAdded = true; // await _taskRepository.Add(model);
                    //if (wasAdded)
                    //{
                    //    await _navigationService.GoBackAsync();
                    //}
                    //else
                    //{
                    //    var param = new DialogParameters()
                    //    {
                    //        { "message", Constants.Errors.GeneralError }
                    //    };
                    //    _dialogService.ShowDialog(nameof(ErrorDialog), param);
                    //}
                }
            }
            catch (Exception ex)
            {
                //var param = new DialogParameters()
                //{
                //    { "message", Constants.Errors.GeneralError }
                //};
                //_dialogService.ShowDialog(nameof(ErrorDialog), param);
                Debug.Write(ex.Message);
            }
        }

    }
}
