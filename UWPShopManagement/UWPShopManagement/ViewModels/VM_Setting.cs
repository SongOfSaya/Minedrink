using System;
using System.Windows.Input;

using UWPShopManagement.Helpers;
using UWPShopManagement.Services;

using Windows.ApplicationModel;

namespace UWPShopManagement.ViewModels
{
    public class VM_Setting : Observable
    {
        // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
        private bool _isLightThemeEnabled;
        public bool IsLightThemeEnabled
        {
            get { return _isLightThemeEnabled; }
            set { Set(ref _isLightThemeEnabled, value); }
        }

        private string _appDescription;
        public string AppDescription
        {
            get { return _appDescription; }
            set { Set(ref _appDescription, value); }
        }

        public ICommand SwitchThemeCommand { get; private set; }

        public VM_Setting()
        {
            SwitchThemeCommand = new RelayCommand(async () => { await ThemeSelectorService.SwitchThemeAsync(); });
        }

        public void Initialize()
        {
            IsLightThemeEnabled = ThemeSelectorService.IsLightThemeEnabled;
            AppDescription = GetAppDescription();
        }

        private string GetAppDescription()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
