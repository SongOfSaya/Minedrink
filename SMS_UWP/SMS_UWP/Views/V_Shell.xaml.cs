using System;

using SMS_UWP.Services;
using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SMS_UWP.Views
{
    public sealed partial class V_Shell : Page
    {
        private VM_Shell ViewModel
        {
            get { return DataContext as VM_Shell; }
        }

        public V_Shell()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame);
        }
    }
}
