using UWPShopManagement.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UWPShopManagement.Services;
using UWPShopManagement.ViewModels;
using UWPShopManagement.Helpers;

namespace UWPShopManagement.Views
{
    public sealed partial class V_ArduinoManagement_C : UserControl
    {
        public VM_ArduinoManagement ViewModel { get; } = Singleton<VM_ArduinoManagement>.Instance;
        public S_ArduinoLink MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as S_ArduinoLink; }
            set { SetValue(MasterMenuItemProperty, value); }
        }
        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem",typeof(S_ArduinoLink),typeof(V_ArduinoManagement_C),new PropertyMetadata(null));

        public V_ArduinoManagement_C()
        {
            InitializeComponent();
        }
        public void Refresh(M_WeightSensor sense)
        {
            SensorsListView.ItemsSource = sense;
        }
    }
}
