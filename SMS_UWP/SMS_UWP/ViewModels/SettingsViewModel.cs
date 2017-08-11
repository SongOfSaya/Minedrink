using System;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using SMS_UWP.Services;

using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;

namespace SMS_UWP.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
        private ElementTheme _elementTheme = ElementTheme.Default;
        
        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { Set(ref _elementTheme, value); }
        }
        private string _btnContent;
        public string BtnContent
        {
            get { return _btnContent; }
            set { Set(ref _btnContent, value); }
        }
        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { Set(ref _versionDescription, value); }
        }

        public ICommand SwitchThemeCommand { get; private set; }
        public ICommand BtnClickCommand { get; private set; }

        public SettingsViewModel()
        {
            BtnClickCommand = new RelayCommand<string>(OnBtnClick);
            SwitchThemeCommand = new RelayCommand<ElementTheme>(
                async (param) =>
                {
                    await ThemeSelectorService.SetThemeAsync(param);
                });
            
        }

        public void Initialize()
        {
            ElementTheme = ThemeSelectorService.Theme;

            VersionDescription = GetVersionDescription();
            BtnContent = "????????";
        }
        public void OnBtnClick(string btn)
        {
            if (btn != null)
            {
                Debug.WriteLine("content:" + btn);
                
                BtnContent = btn;
            }
            VersionDescription = "AAAAAAAAAAAAAAA";
            Debug.WriteLine("Btn被点击了:" +  BtnContent);
        }

        private string GetVersionDescription()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
