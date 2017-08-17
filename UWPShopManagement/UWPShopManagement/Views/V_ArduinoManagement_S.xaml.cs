using UWPShopManagement.Models;
using UWPShopManagement.Services;
using UWPShopManagement.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPShopManagement.Views
{
    public sealed partial class V_ArduinoManagement_S : Page
    {
        public VM_ArduinoManagement_S ViewModel { get; } = new VM_ArduinoManagement_S();
        public V_ArduinoManagement_S()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Item = e.Parameter as S_ArduinoLink;
        }
    }
}
