using System;

using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SMS_UWP.Views
{
    public sealed partial class V_AduMGMT_P : Page
    {
        private VM_AduMGMT ViewModel
        {
            get { return DataContext as VM_AduMGMT; }
        }

        public V_AduMGMT_P()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadDataAsync(WindowStates.CurrentState);
        }
        
    }
}
