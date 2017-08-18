using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        public ICommand RefreshBtnCommand { get; private set; }

        public ObservableCollection<S_ArduinoLink> ArduinoLinkItems { get; private set; } = new ObservableCollection<S_ArduinoLink>();
        #endregion
        public VM_ArduinoManagement()
        {
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddAduBtnCommand = new RelayCommand(OnAddArduinoAsync);
            DialogCancelCommand = new RelayCommand(OnAddDialogCancel);
            DialogSubmitCommand = new RelayCommand<ContentDialogButtonClickEventArgs>(OnAddDialogSubmit);
            RefreshBtnCommand = new RelayCommand(OnRefreshBtnCommand);
        }

        private async void OnRefreshBtnCommand()
        {
            await Task.CompletedTask;
            ArduinoLinkItems.Add(new S_ArduinoLink() { ID = 119 });
#if DEBUG
            Debug.WriteLine("当前ArduinoLink数量:" + ArduinoLinkItems.Count);
#endif
        }

        private async void OnAddDialogSubmit(ContentDialogButtonClickEventArgs args)
        {
            Debug.WriteLine("成功拦截到事件;IP:" + IPTextBox + " Port:" + PortTextBox);
            //TODO:验证输入有效性
            ConnectInfo = "正在连接中...";
            S_ArduinoLink arduinoLink = new S_ArduinoLink();
            bool isConnect = await arduinoLink.Connection(IPTextBox, PortTextBox);
            if (isConnect)
            {
                ConnectInfo = "连接成功";
                ArduinoLinkItems.Add(arduinoLink);
#if DEBUG
                Debug.WriteLine("添加成功");
#endif
            }
            else
            {
                args.Cancel = true;
                ConnectInfo = "连接失败请重试";
            }
        }

        private void OnAddDialogCancel()
        {
        }

        private async void OnAddArduinoAsync()
        {
            V_AddArduinoDialog dialog = new V_AddArduinoDialog();
            ContentDialogResult result = await dialog.ShowAsync();
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
