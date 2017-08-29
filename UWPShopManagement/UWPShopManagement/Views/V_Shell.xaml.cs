using UWPShopManagement.Helpers;
using UWPShopManagement.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPShopManagement.Views
{
    public sealed partial class V_Shell : Page
    {
        public VM_Shell ViewModel { get; } = new VM_Shell();

        public V_Shell()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame);
            VM_ArduinoManagement vM_ArduinoManagement = Singleton<VM_ArduinoManagement>.Instance;
        }
    }
}
