using UWPShopManagement.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPShopManagement.Views
{
    public sealed partial class V_ArduinoManagement_C : UserControl
    {
        public Order MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Order; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem",typeof(Order),typeof(V_ArduinoManagement_C),new PropertyMetadata(null));

        public V_ArduinoManagement_C()
        {
            InitializeComponent();
        }
    }
}
