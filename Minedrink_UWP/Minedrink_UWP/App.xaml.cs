using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Minedrink_UWP.View;

namespace Minedrink_UWP
{
    /// <summary>
    /// 提供特定于应用程序的行为，以补充默认的应用程序类。
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// 初始化单一实例应用程序对象。这是执行的创作代码的第一行，
        /// 已执行，逻辑上等同于 main() 或 WinMain()。
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }
        /// <summary>
        /// 在应用程序由最终用户使用时调用
        /// 将在启动应用以打开特点文件时调用
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">有关启动请求和调用的详细信息Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // This just gets in the way.
                //this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            // 改变窗口最小值 Change minimum window size
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 200));

            // Darken the window title bar using a color value to match app theme
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            if (titleBar != null)
            {
                Color titleBarColor = (Color)App.Current.Resources["SystemChromeMediumColor"];
                titleBar.BackgroundColor = titleBarColor;
                titleBar.ButtonBackgroundColor = titleBarColor;
                
            }

            if (SystemInformationHelpers.IsTenFootExperience)
            {
                // Apply guidance from https://msdn.microsoft.com/windows/uwp/input-and-devices/designing-for-tv
                ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);

                this.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("ms-appx:///Styles/TenFootStylesheet.xaml")
                });
            }

            MainPage mainPage = Window.Current.Content as MainPage;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (mainPage == null)
            {
                // Create a AppShell to act as the navigation context and navigate to the first page
                mainPage = new MainPage();

                // Set the default language
                mainPage.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                mainPage.AppFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Load state from previously suspended application
                }
            }

            // Place our app shell in the current Window
            Window.Current.Content = mainPage;

            if (mainPage.AppFrame.Content == null)
            {
                // When the navigation stack isn't restored, navigate to the first page
                // suppressing the initial entrance animation.
                mainPage.NavMenuList_Init();
                mainPage.AppFrame.Navigate(typeof(ConfigPage), e.Arguments, new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// 在应用程序由最终用户正常启动时进行调用。
        /// 将在启动应用程序以打开特定文件等情况下使用。
        /// </summary>
        /// <param name="e">有关启动请求和过程的详细信息。</param>
        //protected override void OnLaunched(LaunchActivatedEventArgs e)
        //{
        //    Frame rootFrame = Window.Current.Content as Frame;

        //    // 不要在窗口已包含内容时重复应用程序初始化，
        //    // 只需确保窗口处于活动状态
        //    if (rootFrame == null)
        //    {
        //        // 创建要充当导航上下文的框架，并导航到第一页
        //        rootFrame = new Frame();

        //        rootFrame.NavigationFailed += OnNavigationFailed;

        //        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        //        {
        //            //从之前挂起的应用程序加载状态
        //        }

        //        // 将框架放在当前窗口中
        //        Window.Current.Content = rootFrame;
        //    }

        //    if (e.PrelaunchActivated == false)
        //    {
        //        if (rootFrame.Content == null)
        //        {
        //            // 当导航堆栈尚未还原时，导航到第一页，
        //            // 并通过将所需信息作为导航参数传入来配置
        //            // 参数
        //            rootFrame.Navigate(typeof(MainPage), e.Arguments);
        //        }
        //        // 确保当前窗口处于活动状态
        //        Window.Current.Activate();
        //    }
        //}

        /// <summary>
        /// 导航到特定页失败时调用
        /// </summary>
        ///<param name="sender">导航失败的框架</param>
        ///<param name="e">有关导航失败的详细信息</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// 在将要挂起应用程序执行时调用。  在不知道应用程序
        /// 无需知道应用程序会被终止还是会恢复，
        /// 并让内存内容保持不变。
        /// </summary>
        /// <param name="sender">挂起的请求的源。</param>
        /// <param name="e">有关挂起请求的详细信息。</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // 保存应用程序状态并停止任何后台活动
            deferral.Complete();
        }
    }
}
