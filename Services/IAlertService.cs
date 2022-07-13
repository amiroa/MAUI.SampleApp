using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Public.Maui.SampleApp.Services
{
    public interface IAlertService
    {
        Task ShowAlertAsync(string title, string message, string cancel = "OK");
        Task<bool> ShowConfirmationAsync(string title, string message, string accept = "Yes", string cancel = "No");

        void ShowAlert(string title, string message, string cancel = "OK");
        void ShowConfirmation(string title, string message, Action<bool> callback, string accept = "Yes", string cancel = "No");
    }
}
