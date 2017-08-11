using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using SMS_UWP.Models;
using SMS_UWP.Services;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;

namespace SMS_UWP.ViewModels
{
    public class ArduinoManageViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService
        {
            get
            {
                return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
            }
        }

        private const string NarrowStateName = "NarrowState";
        private const string WideStateName = "WideState";

        private VisualState _currentState;

        private Order _selected;

        public Order Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ICommand ItemClickCommand { get; private set; }

        public ICommand StateChangedCommand { get; private set; }
        public ICommand BtnClickCommand { get; private set; }

        public ObservableCollection<Order> SampleItems { get; private set; } = new ObservableCollection<Order>();

        public ArduinoManageViewModel()
        {
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            BtnClickCommand = new RelayCommand(OnBtnClick);
        }


        public async Task LoadDataAsync(VisualState currentState)
        {
            _currentState = currentState;
            SampleItems.Clear();

            var data = await SampleDataService.GetSampleModelDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            Selected = SampleItems.First();
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
            _currentState = args.NewState;
           
        }

        private void OnItemClick(ItemClickEventArgs args)
        {
            Order item = args?.ClickedItem as Order;
            if (item != null)
            {
                if (_currentState.Name == NarrowStateName)
                {
                    NavigationService.Navigate(typeof(ArduinoManageDetailViewModel).FullName, item);
                }
                else
                {
                    Selected = item;
                    
                }
            }
        }
        private void OnBtnClick()
        {
            Debug.WriteLine("Btn被点击了");
        }
    }
}
