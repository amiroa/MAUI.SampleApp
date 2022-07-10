using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    public class AddEditPrinterViewModel : BaseViewModel
    {
        #region Private & Protected

        private bool _archived;
        private string _id;

        #endregion

        #region Properties

        public PrinterInfo PrinterInfo { get; set; }

        public string Mode { get; set; }

        #endregion

        #region Commands

        public ICommand CreateCommand { get; set; }
        public ICommand OpenListDialogCommand { get; set; }

        public ICommand ValidateCommand { get; set; }

        #endregion

        #region Constructors

        public AddEditPrinterViewModel()
        {

            CreateCommand = new Command(CreateCommandHandler);
            OpenListDialogCommand = new Command(OpenListDialogCommandHandler);

        }

        #endregion

        #region Command Handlers

        private async void CreateCommandHandler()
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
                        CommunicationType = PrinterCommunicationType.Network,
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
                        CommunicationType = PrinterCommunicationType.Network,
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

        private void OpenListDialogCommandHandler()
        {


        }

        #endregion

        #region Private Methods


        #endregion
    }
}
