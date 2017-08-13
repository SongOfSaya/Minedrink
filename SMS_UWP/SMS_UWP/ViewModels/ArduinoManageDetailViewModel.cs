using System;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using SMS_UWP.Models;
using SMS_UWP.Services;

using Windows.UI.Xaml;

namespace SMS_UWP.ViewModels
{
    public class ArduinoManageDetailViewModel : ViewModelBase
    {
        public S_NavigationEx NavigationService
        {
            get
            {
                return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<S_NavigationEx>();
            }
        }

        private const string NarrowStateName = "NarrowState";

        private const string WideStateName = "WideState";

        public ICommand StateChangedCommand { get; private set; }

        private Order _item;

        public Order Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public ArduinoManageDetailViewModel()
        {
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
            if (args.OldState.Name == NarrowStateName && args.NewState.Name == WideStateName)
            {
                NavigationService.GoBack();
            }
        }
    }
}
