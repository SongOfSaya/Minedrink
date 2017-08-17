using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using UWPShopManagement.Helpers;
using UWPShopManagement.Models;
using UWPShopManagement.Services;
using UWPShopManagement.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPShopManagement.ViewModels
{
    public class VM_ArduinoManagement : Observable
    {
        #region Properties 
        const string NarrowStateName = "NarrowState";
        const string WideStateName = "WideState";

        private VisualState _currentState;



        private S_ArduinoLink _selected;
        public S_ArduinoLink Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }
        //输入的IP地址
        private string _ipTextBox = "192.168.2.109";
        public string IPTextBox
        {
            get { return _ipTextBox; }
            set { Set(ref _ipTextBox, value); }
        }
        private string _portTextBox = "1000";
        //用户输入的端口号
        public string PortTextBox
        {
            get { return _portTextBox; }
            set { Set(ref _portTextBox, value); }
        }
        private string _connectInfo;
        //连接状态的提示信息
        public string ConnectInfo
        {
            get { return _connectInfo; }
            set { Set(ref _connectInfo, value); }
        }
        //AddArduino对话框确认
        public ICommand DialogSubmitCommand { get; private set; }
        //AddArduino对话框取消
        public ICommand DialogCancelCommand { get; private set; }
        public ICommand ItemClickCommand { get; private set; }
        public ICommand StateChangedCommand { get; private set; }
        public ICommand AddAduBtnCommand { get; private set; }

        public ObservableCollection<Order> ArduinoItems { get; private set; } = new ObservableCollection<Order>();
        public ObservableCollection<S_ArduinoLink> ArduinoLinkItems { get; private set; } = new ObservableCollection<S_ArduinoLink>();
        #endregion
        public VM_ArduinoManagement()
        {
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddAduBtnCommand = new RelayCommand(OnAddArduino);
            DialogCancelCommand = new RelayCommand(OnAddDialogConcel);
            DialogSubmitCommand = new RelayCommand(OnAddDialogSubmit);
        }

        private void OnAddDialogSubmit()
        {
            throw new NotImplementedException();
        }

        private void OnAddDialogConcel()
        {
            throw new NotImplementedException();
        }

        private void OnAddArduino()
        {
            V_AddArduinoDialog dialog = new V_AddArduinoDialog();
            //ContentDialogResult result = await dialog.ShowAsync();
        }

        public void LoadDataAsync(VisualState currentState)
        {
            _currentState = currentState;
            ArduinoLinkItems.Clear();
            var data = S_SampleData.GetAllArduinoLinkAsync();
            foreach (var item in data)
            {
                ArduinoLinkItems.Add(item);
            }
            Selected = data.First();
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
            _currentState = args.NewState;
        }

        private void OnItemClick(ItemClickEventArgs args)
        {
            if (args?.ClickedItem is S_ArduinoLink item)
            {
                if (_currentState.Name == NarrowStateName)
                {
                    NavigationService.Navigate<Views.V_ArduinoManagement_S>(item);
                }
                else
                {
                    Selected = item;
                }
            }
        }
    }
}
