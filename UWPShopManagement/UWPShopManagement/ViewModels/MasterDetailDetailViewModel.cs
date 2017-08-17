using System;
using System.Windows.Input;

using UWPShopManagement.Helpers;
using UWPShopManagement.Models;
using UWPShopManagement.Services;

using Windows.UI.Xaml;

namespace UWPShopManagement.ViewModels
{
    public class MasterDetailDetailViewModel : Observable
    {
        const string NarrowStateName = "NarrowState";
        const string WideStateName = "WideState";

        public ICommand StateChangedCommand { get; private set; }

        private Order _item;
        public Order Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public MasterDetailDetailViewModel()
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
