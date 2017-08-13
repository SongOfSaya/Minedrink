using System;

using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SMS_UWP.Views
{
    public sealed partial class WebViewPage : Page
    {
        private WebViewViewModel ViewModel
        {
            get { return DataContext as WebViewViewModel; }
        }

        public WebViewPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
