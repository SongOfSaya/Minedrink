using System;

using SMS_UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SMS_UWP.Views
{
    public sealed partial class GridPage : Page
    {
        private GridViewModel ViewModel
        {
            get { return DataContext as GridViewModel; }
        }

        // TODO WTS: Change the grid as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public GridPage()
        {
            InitializeComponent();
        }
    }
}
