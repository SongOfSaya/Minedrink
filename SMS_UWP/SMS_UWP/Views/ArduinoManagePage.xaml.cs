using System;

using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SMS_UWP.Views
{
    public sealed partial class ArduinoManagePage : Page
    {
        private ArduinoManageViewModel ViewModel
        {
            get { return DataContext as ArduinoManageViewModel; }
        }

        public ArduinoManagePage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadDataAsync(WindowStates.CurrentState);
        }
    }
}
