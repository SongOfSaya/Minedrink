using System;

using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SMS_UWP.Views
{
    public sealed partial class ChartPage : Page
    {
        private ChartViewModel ViewModel
        {
            get { return DataContext as ChartViewModel; }
        }

        // TODO: UWPTemplates: Change the chart as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        public ChartPage()
        {
            InitializeComponent();
        }
    }
}
