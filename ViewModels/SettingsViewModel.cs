using System.Globalization;

namespace OA.Public.Maui.SampleApp.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        #region Private & Protected

        private bool isDarkModeEnabled;
        private bool isWifiOnlyEnabled;

        #endregion

        #region Properties

        public bool IsDarkModeEnabled
        {
            get => isDarkModeEnabled;
            set
            {
                if (SetProperty(ref isDarkModeEnabled, value))
                {
                    ChangeUserAppTheme(value);
                }
            }
        }

        public bool IsWifiOnlyEnabled
        {
            get => isWifiOnlyEnabled;
            set
            {
                if (SetProperty(ref isWifiOnlyEnabled, value))
                {
                    Settings.IsWifiOnlyEnabled = value;
                }
            }
        }

        public static string AppVersion { get => AppInfo.VersionString; }

        #endregion

        public SettingsViewModel()
        {
            isDarkModeEnabled = Settings.Theme == AppTheme.Dark;
            isWifiOnlyEnabled = Settings.IsWifiOnlyEnabled;

            Title = "Settings";
        }

        private void ChangeUserAppTheme(bool activateDarkMode)
        {
            Settings.Theme = activateDarkMode
                ? AppTheme.Dark
                : AppTheme.Light;

            TheTheme.SetTheme();
        }

    }
}