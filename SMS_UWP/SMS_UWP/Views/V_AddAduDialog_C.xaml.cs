using SMS_UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SMS_UWP.Views
{
    public sealed partial class V_AddAduDialog_C : ContentDialog
    {
        private VM_AduMGMT ViewModel
        {
            get { return DataContext as VM_AduMGMT; }
        }
        public V_AddAduDialog_C()
        {
            this.InitializeComponent();
        }
    }
}
