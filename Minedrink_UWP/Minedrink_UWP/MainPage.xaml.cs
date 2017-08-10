using System;
using System.Collections.Generic;
using System.Linq;
using Minedrink_UWP.View;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Windows.Networking;
using Minedrink_UWP.Model;
using Windows.Networking.Connectivity;
using Windows.Networking.Sockets;
using System.IO;
using Windows.Storage.Streams;
using System.Threading.Tasks;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Minedrink_UWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Rect TogglePaneButtonRect
        {
            get;
            private set;
        }
        private bool isPaddingAdd = false;
        private List<NavMenuItem> navlist = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    Symbol = Symbol.Globe,
                    Label = "总览",
                    DestPage = typeof(OverviewPage),
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.Admin,
                    Label = "配置",
                    DestPage = typeof(ConfigPage),
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.PhoneBook,
                    Label = "监控",
                    DestPage = typeof(MonitorPage),
                }
            });
        public static MainPage Current = null;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += (sender, args) =>
            {
                Current = this;
                this.CheckTogglePaneButtonSizeChanged();
                var titleBar = Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar;
                titleBar.IsVisibleChanged += TitleBar_IsVisibleChanged;
            };
            
            this.RootSplitView.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, (s, a) => 
            {
                //确保当SplitView的显示模式改变时，更新TogglePaneButton的尺寸
                this.CheckTogglePaneButtonSizeChanged();
            });
            SystemNavigationManager.GetForCurrentView().BackRequested += SyatemNavigationMaganger_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            NavMenuList.ItemsSource = navlist;
        }

        private void SyatemNavigationMaganger_BackRequested(object sender, BackRequestedEventArgs e)
        {
            bool handle = e.Handled;
            this.BackRequested(ref handle);
            e.Handled = handle;
        }
        /// <summary>
        /// 处理返回按键
        /// </summary>
        /// <param name="handle"></param>
        private void BackRequested(ref bool handle)
        {

            if (this.AppFrame == null)
            {
                return;
            }
            if (this.AppFrame.CanGoBack && !handle)
            {
                handle = true;
                this.AppFrame.GoBack();
            }
        }

        /// <summary>
        /// 当窗口标题栏可见性改变时调用，例如Loading完成或进入平板模式，
        /// 确保标题栏和App内容间的top padding正确
        /// Invoked when window title bar visibility changes, such as after loading or in tablet mode
        /// Ensures correct padding at window top, between title bar and app content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TitleBar_IsVisibleChanged(Windows.ApplicationModel.Core.CoreApplicationViewTitleBar sender, object args)
        {
            if (!this.isPaddingAdd && sender.IsVisible)
            {
                //在标题和内容间增加额外的Padding
                double extraPadding = (Double)App.Current.Resources["DesktopWindowTopPadding"];
                this.isPaddingAdd = true;

                Thickness margin = NavMenuList.Margin;
                NavMenuList.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
                margin = AppFrame.Margin;
                //AppFrame.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
                margin = TogglePaneButton.Margin;
                TogglePaneButton.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
            }
        }
        /// <summary>
        /// Check for the conditions where the navigation pane does not occupy the space under the floating
        /// hamburger button and trigger the event.
        /// </summary>
        private void CheckTogglePaneButtonSizeChanged()
        {
            if (RootSplitView.DisplayMode == SplitViewDisplayMode.Inline ||
                RootSplitView.DisplayMode == SplitViewDisplayMode.Overlay)
            {
                var transform = this.TogglePaneButton.TransformToVisual(this);
                var rect = transform.TransformBounds(new Rect(0, 0, this.TogglePaneButton.ActualWidth, this.TogglePaneButton.ActualHeight));
                this.TogglePaneButtonRect = rect;
            }
            else
            {
                this.TogglePaneButtonRect = new Rect();
            }

            var handler = this.TogglePaneButtonRectChanged;
            if (handler != null)
            {
                // handler(this, this.TogglePaneButtonRect);
                handler.DynamicInvoke(this, this.TogglePaneButtonRect);
            }
        }

        //private void MainPage_Loaded(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public Frame AppFrame { get { return this.frame; } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPage_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            FocusNavigationDirection direction = FocusNavigationDirection.None;
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Left:
                case Windows.System.VirtualKey.GamepadDPadLeft:
                case Windows.System.VirtualKey.GamepadLeftThumbstickLeft:
                case Windows.System.VirtualKey.NavigationLeft:
                    direction = FocusNavigationDirection.Left;
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.GamepadDPadRight:
                case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                case Windows.System.VirtualKey.NavigationRight:
                    direction = FocusNavigationDirection.Right;
                    break;
                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.GamepadDPadUp:
                case Windows.System.VirtualKey.GamepadLeftThumbstickUp:
                case Windows.System.VirtualKey.NavigationUp:
                    direction = FocusNavigationDirection.Up;
                    break;

                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.GamepadDPadDown:
                case Windows.System.VirtualKey.GamepadLeftThumbstickDown:
                case Windows.System.VirtualKey.NavigationDown:
                    direction = FocusNavigationDirection.Down;
                    break;
            }
            if (direction != FocusNavigationDirection.None)
            {
                var contorl = FocusManager.FindNextFocusableElement(direction) as Control;
                if (contorl != null)
                {
                    contorl.Focus(FocusState.Keyboard);
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// Hides divider when nav pane is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RootSplitView_PaneClosed(SplitView sender, object args)
        {
            NavPaneDivider.Visibility = Visibility.Collapsed;

            // Prevent focus from moving to elements when they're not visible on screen
            FeedbackNavPaneButton.IsTabStop = false;
            SettingsNavPaneButton.IsTabStop = false;
        }
        /// <summary>
        ///通过使用每个项目的关联标签在每个容器上设置AutomationProperties.Name来启用每个导航菜单项上的辅助功能。
        /// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
        /// using the associated Label of each item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavMenuList_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (!args.InRecycleQueue && args.Item != null && args.Item is NavMenuItem)
            {
                args.ItemContainer.SetValue(AutomationProperties.NameProperty, ((NavMenuItem)args.Item).Label);

            }
            else
            {
                args.ItemContainer.ClearValue(AutomationProperties.NameProperty);
            }
        }
        /// <summary>
        /// 选中导航按钮项后调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavMenuList_ItemInvoked(object sender, ListViewItem e)
        {
            foreach (var i in navlist)
            {
                i.IsSelected = false;
            }

            var item = (NavMenuItem)((NavMenuListView)sender).ItemFromContainer(e);
            if (item != null)
            {
                item.IsSelected = true;
                if (item.DestPage != null && item.DestPage != this.AppFrame.CurrentSourcePageType)
                {
                    this.AppFrame.Navigate(item.DestPage, item.Arguments);
                }
            }
        }
        public void NavMenuList_Init()
        {
            navlist.First().IsSelected = true;
        }
        /// <summary>
        /// Ensures the nav menu reflects reality when navigation is triggered outside of
        /// the nav menu buttons.确保导航菜单在导航按钮之外触发正确
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            //处理返回逻辑
            if (e.NavigationMode == NavigationMode.Back)
            {
                var item = (from p in this.navlist where p.DestPage == e.SourcePageType select p).SingleOrDefault();
                if (item == null && this.AppFrame.BackStackDepth > 0)
                {
                    // 在页面进入到子页面的情况下，我们将返回到BackStack中最近的一级导航菜单项
                    // In cases where a page drills into sub-pages then we'll highlight the most recent
                    // navigation menu item that appears in the BackStack
                    foreach (var entry in this.AppFrame.BackStack.Reverse())
                    {
                        item = (from p in this.navlist where p.DestPage == entry.SourcePageType select p).SingleOrDefault();
                        if (item != null)
                        {
                            break;
                        }
                    }
                }

                foreach (var i in navlist)
                {
                    i.IsSelected = false;
                }
                if (item != null)
                {
                    item.IsSelected = true;
                }
                var container = (ListViewItem)NavMenuList.ContainerFromItem(item);

                //当更新项目的选择状态时，它阻止它进行键盘焦点。 如果用户正在通过键盘调用后退按钮，导致所选择的导航菜单项目改变，则焦点将保留在后退按钮上。
                //While updating the selection state of the item prevent it from taking keyboard focus.
                //If a user is invoking the back button via the keyboard causing the selected nav menu item to change then focus will remain on the back button.
                if (container != null)
                {
                    container.IsTabStop = false;
                }
                NavMenuList.SetSelectedItem(container);
                if (container != null)
                {
                    container.IsTabStop = true;
                }
            }
        }

        private void TogglePaneButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.CheckTogglePaneButtonSizeChanged();
        }

        private void TogglePaneButton_Checked(object sender, RoutedEventArgs e)
        {
            NavPaneDivider.Visibility = Visibility.Visible;
            this.CheckTogglePaneButtonSizeChanged();

            FeedbackNavPaneButton.IsTabStop = true;
            SettingsNavPaneButton.IsTabStop = true;
        }
        //private async void StartListener()
        //{
        //    //覆盖这里的监听器是安全的，因为它将被删除，一旦它的所有引用都消失了。
        //    //然而，在许多情况下，这是一个危险的模式，半随机地覆盖数据（每次用户点击按钮），
        //    //所以我们在这里阻止它。
        //    if (CoreApplication.Properties.ContainsKey("listener"))
        //    {
        //        Debug.WriteLine("监听器已存在");
        //        return;
        //    }
        //    CoreApplication.Properties.Remove("serverAddress");
        //    CoreApplication.Properties.Remove("adapter");

        //    //LocalHostItem selectedLocalHost = null;
        //    //selectedLocalHost = new LocalHostItem(NetworkInformation.GetHostNames().First());
        //    //Debug.WriteLine("建立地址:" + selectedLocalHost);
        //    //用户选择了一个地址。 为演示目的，我们确保连接将使用相同的地址。
        //    //CoreApplication.Properties.Add("serverAddress", selectedLocalHost.LocalHost.CanonicalName);
        //    StreamSocketListener listener = new StreamSocketListener();
        //    listener.ConnectionReceived += Listener_ConnectionReceived;
        //    //如果需要，调整监听器的控制选项，然后再进行绑定操作。这些选项将被自动应用到连接的StreamSockets，
        //    //这些连接是由传入的连接引起的（即作为ConnectionReceived事件处理程序的参数传递的）。
        //    //参考StreamSocketListenerControl类'MSDN 有关控制选项的完整列表的文档。
        //    listener.Control.KeepAlive = false;
        //    //保存Socket,以便随后使用
        //    CoreApplication.Properties.Add("listener", listener);
        //    //开始监听操作
        //    try
        //    {
        //        await listener.BindServiceNameAsync("8080");
        //        Debug.WriteLine("Listening......");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private async void Listener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        //{
        //    //DataReader reader = new DataReader(args.Socket.InputStream);
        //    //try
        //    //{
        //    //    while (true)
        //    //    {
        //    //        // Read first 4 bytes (length of the subsequent string).
        //    //        uint sizeFieldCount = await reader.LoadAsync(sizeof(uint));
        //    //        if (sizeFieldCount != sizeof(uint))
        //    //        {
        //    //            // The underlying socket was closed before we were able to read the whole data.
        //    //            return;
        //    //        }

        //    //        // Read the string.
        //    //        uint stringLength = reader.ReadUInt32();
        //    //        uint actualStringLength = await reader.LoadAsync(stringLength);
        //    //        if (stringLength != actualStringLength)
        //    //        {
        //    //            // The underlying socket was closed before we were able to read the whole data.
        //    //            return;
        //    //        }


        //    //    }
        //    //}
        //    //catch (Exception exception)
        //    //{

        //    //}

        //    //从远程客户端读取信息
        //    Stream inStream = args.Socket.InputStream.AsStreamForRead();
        //    StreamReader reader = new StreamReader(inStream);
            

        //    //将信息送回
        //    Stream outStream = args.Socket.OutputStream.AsStreamForWrite();
        //    StreamWriter writer = new StreamWriter(outStream);

        //    while (true)
        //    {
        //        string inStr = await reader.ReadLineAsync();
        //        string outStr = null;
        //        Debug.WriteLine("IN:" + inStr);
        //        if (inStr.StartsWith("#"))
        //        {
        //            string codeStr = inStr.Substring(0, 8);
        //            CommCode code = CommHandle.StringConvertToEnum(codeStr);
                    
        //            switch (code)
        //            {
        //                case CommCode.TCPCONN:
        //                    outStr = TCPCOMMHandle();
        //                    break;
        //                case CommCode.AS:
        //                    break;
        //                case CommCode.ERROR:
        //                    Debug.WriteLine("错误的指令:" + codeStr);
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        //TODO:断开连接后会引发System.NullReferenceException
        //        if (outStr != null)
        //        {
        //            await writer.WriteLineAsync(inStr);
        //            await writer.FlushAsync();
        //        }
        //        //await Task.Delay(100);
        //    }
        //}

        /// <summary>
        /// An event to notify listeners when the hamburger button may occlude other content in the app.
        /// The custom "PageHeader" user control is using this.
        /// </summary>
        public event TypedEventHandler<MainPage, Rect> TogglePaneButtonRectChanged;

        /// <summary>
        /// Public method to allow pages to open SplitView's pane.
        /// Used for custom app shortcuts like navigating left from page's left-most item
        /// </summary>
        public void OpenNavePane()
        {
            TogglePaneButton.IsChecked = true;
            NavPaneDivider.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // Save application state and stop any background activity
            deferral.Complete();
        }
        private string TCPCOMMHandle()
        {
            string result = "#TCPOK**";

            return result;
        }
    }
    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    };
    //private void UpdateStatus(string strMessage, NotifyType type)
    //{
    //    switch (type)
    //    {
    //        case NotifyType.StatusMessage:
    //            StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
    //            break;
    //        case NotifyType.ErrorMessage:
    //            StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
    //            break;
    //    }

    //    StatusBlock.Text = strMessage;

    //    // Collapse the StatusBlock if it has no text to conserve real estate.
    //    StatusBorder.Visibility = (StatusBlock.Text != String.Empty) ? Visibility.Visible : Visibility.Collapsed;
    //    if (StatusBlock.Text != String.Empty)
    //    {
    //        StatusBorder.Visibility = Visibility.Visible;
    //        StatusPanel.Visibility = Visibility.Visible;
    //    }
    //    else
    //    {
    //        StatusBorder.Visibility = Visibility.Collapsed;
    //        StatusPanel.Visibility = Visibility.Collapsed;
    //    }
    //}
    
}
