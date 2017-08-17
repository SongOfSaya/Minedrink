using UWPShopManagement.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPShopManagement.Views
{
    public sealed partial class V_Setting : Page
    {
        public VM_Setting ViewModel { get; } = new VM_Setting();
        // TODO WTS: Setup your privacy web in your Resource File, currently set to https://YourPrivacyUrlGoesHere

        public V_Setting()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Initialize();
        }
    }
}
