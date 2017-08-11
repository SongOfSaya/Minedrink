using System;

using SMS_UWP.Models;
using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SMS_UWP.Views
{
    public sealed partial class ArduinoManageDetailPage : Page
    {
        private ArduinoManageDetailViewModel ViewModel
        {
            get { return DataContext as ArduinoManageDetailViewModel; }
        }

        public ArduinoManageDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Item = e.Parameter as Order;
        }
    }
}
