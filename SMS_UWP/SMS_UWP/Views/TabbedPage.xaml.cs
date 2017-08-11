using System;

using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SMS_UWP.Views
{
    public sealed partial class TabbedPage : Page
    {
        private TabbedViewModel ViewModel
        {
            get { return DataContext as TabbedViewModel; }
        }

        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
