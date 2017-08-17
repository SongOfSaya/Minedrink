using UWPShopManagement.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPShopManagement.Views
{
    public sealed partial class V_Main : Page
    {
        public VM_Main ViewModel { get; } = new VM_Main();
        public V_Main()
        {
            InitializeComponent();
        }
    }
}
