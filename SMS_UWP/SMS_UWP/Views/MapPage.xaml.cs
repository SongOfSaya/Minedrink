using System;

using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SMS_UWP.Views
{
    public sealed partial class MapPage : Page
    {
        private MapViewModel ViewModel
        {
            get { return DataContext as MapViewModel; }
        }

        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync(mapControl);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleanup();
        }
    }
}
