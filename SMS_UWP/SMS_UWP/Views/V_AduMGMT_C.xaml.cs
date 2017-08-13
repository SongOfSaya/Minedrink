using System;

using SMS_UWP.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SMS_UWP.Services;

namespace SMS_UWP.Views
{
    public sealed partial class V_AduMGMT_C : UserControl
    {
        //public Order MasterMenyItem { get; set; }
        public S_ArduinoLink MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as S_ArduinoLink; }
            set { SetValue(MasterMenuItemProperty, value); }
        }
        //public S_ArduinoLink ArduinoLink
        //{
        //    get { return GetValue(MasterMenuItemProperty) as S_ArduinoLink; }
        //    set { SetValue(MasterMenuItemProperty, value); }
        //}
        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(S_ArduinoLink), typeof(V_AduMGMT_C), new PropertyMetadata(null));
        //public static readonly DependencyProperty SelectedArduinoLink = DependencyProperty.Register("SelectedArduinoLink", typeof(S_ArduinoLink), typeof(ArduinoManageDetailControl), new PropertyMetadata(null));
        public V_AduMGMT_C()
        {
            InitializeComponent();
        }
    }
}
