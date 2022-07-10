using MvvmHelpers.Commands;
using OA.Public.Maui.SampleApp.Services.Database;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class PrinterInfoAddEditViewModel : BaseViewModel
    {
        public int Id { get; set; }
        private int printerInfoId;


        private PrinterInfoViewModel printerInfo;
        public PrinterInfoViewModel PrinterInfo
        {
            get => printerInfo;
            set => SetProperty(ref printerInfo, value);
        }

        public ICommand SaveCommand => new AsyncCommand<PrinterInfo>(SaveCommandExecute);
        public ICommand CancelCommand => new AsyncCommand(CancelCommandExecute);

        public PrinterInfoAddEditViewModel()
        {

        }

        internal async Task InitializeAsync()
        {
            if (PrinterInfo != null)
                return;

            printerInfoId = Id;
            if(Id > 0)
                await FetchAsync();
        }

        private async Task FetchAsync()
        {
            var printerInfo = await DatabaseService.Get<PrinterInfo>(printerInfoId);

            if (printerInfo == null)
            {
                await Shell.Current.DisplayAlert(
                          "Error!",
                          "Something went wrong. Please try again later!",
                          "Close");

                return;
            }

            var printerInfoVM = new PrinterInfoViewModel(printerInfo);
            await printerInfoVM.InitializeAsync();

            PrinterInfo = printerInfoVM;
        }


        private async Task SaveCommandExecute(PrinterInfo episode)
        {

        }

        private Task CancelCommandExecute()
        {
            return null;
        }
    }
}
