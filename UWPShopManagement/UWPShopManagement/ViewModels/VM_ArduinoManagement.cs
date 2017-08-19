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
        private ContentDialog _addArduinoDialog;

        private ListView _arduinoListView;
        /// <summary>
        /// Arduino列表
        /// </summary>
        public ListView ArduinoListView
        {
            get { return _arduinoListView; }
            set { Set(ref _arduinoListView, value); }
        }
        private ListView _sensorsListView;
        /// <summary>
        /// 传感器列表
        /// </summary>
        public ListView SensorListView
        {
            get { return _sensorsListView; }
            set { Set(ref _sensorsListView, value); }
        }


        private S_ArduinoLink _selected;
        //被选中的Arduino
        public S_ArduinoLink Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }
        
        private M_WeightSensor _selectedSensor;
        //被选中的传感器
        public M_WeightSensor SelectedSensor
        {
            get { return _selectedSensor; }
            set { Set(ref _selectedSensor, value); }
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

        private ObservableCollection<S_ArduinoLink> arduinoLinkItems;
        /// <summary>
        /// 与Arduino管理的Arduino列表绑定
        /// </summary>
        public ObservableCollection<S_ArduinoLink> ArduinoLinkItems
        {
            get { return arduinoLinkItems; }
            set { Set(ref arduinoLinkItems, value); }
        }
        private ObservableCollection<M_WeightSensor> sensorsItems;
        /// <summary>
        /// 与单个Arduino下的SensorsListView绑定
        /// </summary>
        public ObservableCollection<M_WeightSensor> SensorItems
        {
            get { return sensorsItems; }
            set { Set(ref sensorsItems, value); }
        }
        //AddArduino对话框确认
        public ICommand DialogSubmitCommand { get; private set; }
        //AddArduino对话框取消
        public ICommand DialogCancelCommand { get; private set; }
        /// <summary>
        /// 点击Arduino列表中的项
        /// </summary>
        public ICommand ItemClickCommand { get; private set; }
        /// <summary>
        /// 响应式布局状态改变
        /// </summary>
        public ICommand StateChangedCommand { get; private set; }
        /// <summary>
        /// 新增按钮
        /// </summary>
        public ICommand AddAduBtnCommand { get; private set; }
        /// <summary>
        /// 刷新按钮
        /// </summary>
        public ICommand RefreshBtnCommand { get; private set; }
        /// <summary>
        /// 点击SensorsListView中的一项
        /// </summary>
        public ICommand SensorItemClickCommand { get; private set; }
        

        #endregion
        public VM_ArduinoManagement()
        {
            ArduinoLinkItems = new ObservableCollection<S_ArduinoLink>();
            SensorItems = new ObservableCollection<M_WeightSensor>();
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddAduBtnCommand = new RelayCommand(OnAddArduinoAsync);
            DialogCancelCommand = new RelayCommand(OnAddDialogCancel);
            DialogSubmitCommand = new RelayCommand<ContentDialogButtonClickEventArgs>(OnAddDialogSubmit);
            RefreshBtnCommand = new RelayCommand(OnRefreshBtnCommand);
            SensorItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnSensorItemClick);
            //this.PropertyChanged += VM_ArduinoManagement_PropertyChanged;
        }

        private void OnSensorItemClick(ItemClickEventArgs obj)
        {
            if (obj?.ClickedItem is M_WeightSensor item)
            {
                SelectedSensor = item;
            }
        }

        private void OnRefreshBtnCommand()
        {
            Selected.Arduino.ID++;
            
        }

        private async void OnAddDialogSubmit(ContentDialogButtonClickEventArgs args)
        {
            Debug.WriteLine("成功拦截到事件;IP:" + IPTextBox + " Port:" + PortTextBox);
            args.Cancel = true;
            //TODO:验证输入有效性
            if (ArduinoLinkItems.Any(p => p.Arduino.IP == IPTextBox))
            {
                ConnectInfo = "已存在使用此IP地址的Arduino";
                return;
            }
            
            ConnectInfo = "正在连接中...";
            S_ArduinoLink arduinoLink = new S_ArduinoLink();
            bool isConnect = await arduinoLink.Connection(IPTextBox, PortTextBox);
            if (isConnect)
            {
                ConnectInfo = "连接成功，正在初始化...";
                
                await Task.Delay(1000);
                _addArduinoDialog.Hide();
                arduinoLink.Arduino.IsConnect = true;
                ArduinoLinkItems.Add(arduinoLink);
#if DEBUG
                Debug.WriteLine("添加成功");
#endif
                
            }
            else
            {
                ConnectInfo = "连接失败请重试";
            }
        }

        private void OnAddDialogCancel()
        {
        }
        /// <summary>
        /// 点击新增按钮,出现新增Arduous对话框
        /// </summary>
        private async void OnAddArduinoAsync()
        {
            _addArduinoDialog = new V_AddArduinoDialog();
            ContentDialogResult result = await _addArduinoDialog.ShowAsync();
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
            SensorItems = data.First().Arduino.SensorCollection;
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
                    SensorItems = Selected.Arduino.SensorCollection;
                    //Selected.Arduino;
                }
            }
        }
        private void ReFresh()
        {
            
            Selected = ArduinoLinkItems.Last();
            SensorItems = ArduinoLinkItems.Last().Arduino.SensorCollection;
        }

            //get
            //{
            //    return _incrementCommand
            //        ?? (_incrementCommand = new RelayCommand(
            //        () =>
            //        {
            //            WelcomeTitle = string.Format("Counter clicked {0} times", ++_counter);
            //        }));
            //}
            //_runClock = true;

            //Task.Run(async () =>
            //{
            //    while (_runClock)
            //    {
            //        try
            //        {
            //            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            //            {
            //                Clock = DateTime.Now.ToString("HH:mm:ss");
            //            });

            //            await Task.Delay(1000);
            //        }
            //        catch (Exception)
            //        {
            //        }
            //    }
            //});
            //}
        }
}
