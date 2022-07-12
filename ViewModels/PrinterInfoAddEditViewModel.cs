using CommunityToolkit.Mvvm.Input;
using OA.Public.Maui.SampleApp.Services.Database;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    public partial class PrinterInfoAddEditViewModel : ObservableValidator
    {
        public int Id { get; set; }
        private int printerInfoId;


        private PrinterInfoViewModel printerInfo;
        public PrinterInfoViewModel PrinterInfo
        {
            get => printerInfo;
            set => SetProperty(ref printerInfo, value);
        }

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

        [RelayCommand]
        private async Task Save(PrinterInfo episode)
        {

        }

        [RelayCommand]
        private void Cancel()
        {

        }
    }
}
