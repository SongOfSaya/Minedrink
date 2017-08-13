using System;

using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

using SMS_UWP.Services;
using SMS_UWP.Views;

namespace SMS_UWP.ViewModels
{
    public class ViewModelLocator
    {
        private S_NavigationEx _navigationService = new S_NavigationEx();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => _navigationService);
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<VM_AduMGMT, V_AduMGMT_P>();
            Register<ArduinoManageDetailViewModel, ArduinoManageDetailPage>();
            Register<TabbedViewModel, TabbedPage>();
            Register<MediaPlayerViewModel, MediaPlayerPage>();
            Register<WebViewViewModel, WebViewPage>();
            Register<ChartViewModel, ChartPage>();
            Register<GridViewModel, GridPage>();
            Register<MapViewModel, MapPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public MapViewModel MapViewModel => ServiceLocator.Current.GetInstance<MapViewModel>();

        public GridViewModel GridViewModel => ServiceLocator.Current.GetInstance<GridViewModel>();

        public ChartViewModel ChartViewModel => ServiceLocator.Current.GetInstance<ChartViewModel>();

        public WebViewViewModel WebViewViewModel => ServiceLocator.Current.GetInstance<WebViewViewModel>();

        public MediaPlayerViewModel MediaPlayerViewModel => ServiceLocator.Current.GetInstance<MediaPlayerViewModel>();

        public TabbedViewModel TabbedViewModel => ServiceLocator.Current.GetInstance<TabbedViewModel>();

        public ArduinoManageDetailViewModel ArduinoManageDetailViewModel => ServiceLocator.Current.GetInstance<ArduinoManageDetailViewModel>();

        public VM_AduMGMT ArduinoManageViewModel => ServiceLocator.Current.GetInstance<VM_AduMGMT>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            _navigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
