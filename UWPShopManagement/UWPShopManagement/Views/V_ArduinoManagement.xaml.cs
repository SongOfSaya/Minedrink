using System.Threading.Tasks;
using UWPShopManagement.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPShopManagement.Views
{
    public sealed partial class V_ArduinoManagement : Page
    {
        public VM_ArduinoManagement ViewModel { get; } = new VM_ArduinoManagement();
        public V_ArduinoManagement()
        {
            InitializeComponent();
        }
        //�˺����ڲ��˺�ʱ����,�Ƽ������첽
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadDataAsync(WindowStates.CurrentState);
        }
    }
}
