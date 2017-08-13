using System;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using SMS_UWP.Models;
using SMS_UWP.Services;

namespace SMS_UWP.ViewModels
{
    public class GridViewModel : ViewModelBase
    {
        public ObservableCollection<Order> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return S_SampleData.GetGridSampleData();
            }
        }
    }
}
