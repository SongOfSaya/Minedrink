using System.Threading.Tasks;
using UWPShopManagement.Helpers;
using UWPShopManagement.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPShopManagement.Views
{
    public sealed partial class V_ArduinoManagement : Page
    {
        public VM_ArduinoManagement ViewModel { get; } = Singleton<VM_ArduinoManagement>.Instance;
        public V_ArduinoManagement()
        {
            InitializeComponent();
        }
        //�˺����ڲ��˺�ʱ����,�Ƽ������첽
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadDataAsync(WindowStates.CurrentState);
        }

        private void RefreshAduBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //MasterListView
        }
    }
}
