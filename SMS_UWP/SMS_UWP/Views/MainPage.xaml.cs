using System;

using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SMS_UWP.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
