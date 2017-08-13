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
            SimpleIoc.Default.Register<VM_Shell>();
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
        //变量名称必须与类名严格统一,DataContext依靠变量名赋值
        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public MapViewModel MapViewModel => ServiceLocator.Current.GetInstance<MapViewModel>();

        public GridViewModel GridViewModel => ServiceLocator.Current.GetInstance<GridViewModel>();

        public ChartViewModel ChartViewModel => ServiceLocator.Current.GetInstance<ChartViewModel>();

        public WebViewViewModel WebViewViewModel => ServiceLocator.Current.GetInstance<WebViewViewModel>();

        public MediaPlayerViewModel MediaPlayerViewModel => ServiceLocator.Current.GetInstance<MediaPlayerViewModel>();

        public TabbedViewModel TabbedViewModel => ServiceLocator.Current.GetInstance<TabbedViewModel>();

        public ArduinoManageDetailViewModel ArduinoManageDetailViewModel => ServiceLocator.Current.GetInstance<ArduinoManageDetailViewModel>();

        public VM_AduMGMT VM_AduMGMT => ServiceLocator.Current.GetInstance<VM_AduMGMT>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public VM_Shell VM_Shell => ServiceLocator.Current.GetInstance<VM_Shell>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            _navigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
