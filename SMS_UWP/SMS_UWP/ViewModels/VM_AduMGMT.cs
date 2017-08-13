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
using SMS_UWP.Views;

namespace SMS_UWP.ViewModels
{
    public class VM_AduMGMT : ViewModelBase
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

        private VisualState _currentState;

        private Order _selected;
        private int _testNum = 0;
        //Master中的当前选项
        public Order Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }
        private bool _dialogIsOpen;
        public bool DialogIsOpen
        {
            get { return _dialogIsOpen; }
            set { Set(ref _dialogIsOpen, value); }
        }
        private string _ipTextBox;
        //输入的IP地址
        public string IPTextBox
        {
            get { return _ipTextBox; }
            set { Set(ref _ipTextBox, value); }
        }
        private string _portTextBox;
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
        public ICommand ItemClickCommand { get; private set; }

        public ICommand StateChangedCommand { get; private set; }
        public ICommand AddAduBtnClickCommand { get; private set; }
        public ICommand DialogSubmitCommand { get; private set; }
        public ICommand TestCommand { get; private set; }
        public ICommand TestEvenCommand { get; private set; }
        public ObservableCollection<Order> ArduinoItems { get; private set; } = new ObservableCollection<Order>();

        public VM_AduMGMT()
        {
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddAduBtnClickCommand = new RelayCommand(OnAddBtnClick);
            DialogSubmitCommand = new RelayCommand<M_AduHostName>(OnDialogSubmit);
            TestCommand = new RelayCommand(OnTest);
            TestEvenCommand = new RelayCommand<ContentDialogButtonClickEventArgs>(OnTestEventCommandAsync);
        }



        public async Task LoadDataAsync(VisualState currentState)
        {
            _currentState = currentState;
            ArduinoItems.Clear();
            var data = await S_SampleData.GetSampleModelDataAsync();

            foreach (var item in data)
            {
                ArduinoItems.Add(item);
            }

            Selected = ArduinoItems.First();
        }
        private async void OnTestEventCommandAsync(ContentDialogButtonClickEventArgs obj)
        {
            Debug.WriteLine("成功拦截到事件;IP:" + IPTextBox + " Port:" + PortTextBox);

            obj.Cancel = true;
            //TODO:验证输入有效
            ConnectInfo = "正在连接中...";
            S_ArduinoLink arduinoLink = new S_ArduinoLink();

            bool isConnect = await arduinoLink.Connection(IPTextBox, PortTextBox);
            if (isConnect)
            {
                ConnectInfo = "连接成功";
            }
            else
            {
                obj.Cancel = true;
                ConnectInfo = "连接失败请重试";
            }

        }
        private void OnTest()
        {
            _testNum++;
            Debug.WriteLine("TestCommand成功:" + _testNum);
        }
        private void OnDialogSubmit(M_AduHostName aduHostName)
        {

            Debug.WriteLine("输出如下");
            Debug.WriteLine(aduHostName.IP);
            Debug.WriteLine(aduHostName.Port);
            // Ensure the user name and password fields aren't empty. If a required field
            // is empty, set args.Cancel = true to keep the dialog open.
            //if (string.IsNullOrEmpty(userNameTextBox.Text))
            //{
            //    args.Cancel = true;
            //    errorTextBlock.Text = "User name is required.";
            //}
            //else if (string.IsNullOrEmpty(passwordTextBox.Password))
            //{
            //    args.Cancel = true;
            //    errorTextBlock.Text = "Password is required.";
            //}

            //// If you're performing async operations in the button click handler,
            //// get a deferral before you await the operation. Then, complete the
            //// deferral when the async operation is complete.

            //ContentDialogButtonClickDeferral deferral = args.GetDeferral();
            ////if (await SomeAsyncSignInOperation())
            ////{
            //this.Result = SignInResult.SignInOK;
            ////}
            ////else
            ////{
            ////    this.Result = SignInResult.SignInFail;
            ////}
            //deferral.Complete();
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
        private async void OnAddBtnClick()
        {
            V_AddAduDialog_C dialog = new V_AddAduDialog_C();
            ContentDialogResult result = await dialog.ShowAsync();
        }
    }
}
