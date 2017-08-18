using UWPShopManagement.Helpers;
using UWPShopManagement.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPShopManagement.Views
{
    public sealed partial class V_Main : Page
    {
        public VM_Main ViewModel { get; } = Singleton<VM_Main>.Instance;
        public V_Main()
        {
            InitializeComponent();
        }
        public void ExperimentMethon()
        {
           
        }
    }
}
