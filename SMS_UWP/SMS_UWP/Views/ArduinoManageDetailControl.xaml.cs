using System;

using SMS_UWP.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SMS_UWP.Views
{
    public sealed partial class ArduinoManageDetailControl : UserControl
    {
        public Order MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Order; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Order), typeof(ArduinoManageDetailControl), new PropertyMetadata(null));

        public ArduinoManageDetailControl()
        {
            InitializeComponent();
        }
    }
}
