namespace OA.Public.Maui.SampleApp.ViewModels;

public class PrinterInfoViewModel : ObservableObject
{
    public PrinterInfo PrinterInfo { get; set; }

    public string Title { get => string.IsNullOrEmpty(PrinterInfo?.DisplayName) ? PrinterInfo?.Name : PrinterInfo?.DisplayName; }

    public string Description { get => PrinterInfo?.Description; }

    public string Mode { get; set; }

    
    //public ICommand NavigateToDetailCommand => new AsyncCommand(NavigateToDetailCommandExecute);

    public PrinterInfoViewModel(PrinterInfo printerInfo)
    {
        PrinterInfo = printerInfo;

        Mode = "Add";
        if (printerInfo != null)
        {
            Mode = "Edit";
        }
    }

    internal Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    private Task NavigateToDetailCommandExecute()
    {
        return null;
        //return Shell.Current.GoToAsync($"{nameof(ShowDetailPage)}?Id={Show.Id}");
    }
}
