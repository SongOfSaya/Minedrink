using Minedrink_UWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Minedrink_UWP.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ConfigPage : Page
    {
        private Arduino selectedArduino;
        private ObservableCollection<Arduino> arduinos;
        public ConfigPage()
        {
            this.InitializeComponent();
            this.Loaded += ConfigPage_Loaded;
            ArduinoListView.Items.Add("代码添加项");

            arduinos = Arduino.GetArduinos(10);
            if (arduinos.Count >0)
            {
                ArduinoListView.ItemsSource = arduinos;
            }
        }
        
        private void ConfigPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (selectedArduino == null && arduinos.Count > 0)
            {
                selectedArduino = arduinos[0];
                ArduinoListView.SelectedIndex = 0;
            }
            if (true)
            {
                ArduinoListView.SelectionMode = ListViewSelectionMode.Extended;
                ArduinoListView.SelectedItem = selectedArduino;
            }
            else
            {
                new InvalidOperationException();
            }
            
        }

        private void ArduinoListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ArduinoListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        /// <summary>
        /// 新增一个arduino
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Arduino newone = Arduino.GetNewArduino();
            arduinos.Add(newone);

            if (ArduinoListView.SelectedIndex == -1)
            {
                ArduinoListView.SelectedIndex = 0;
                selectedArduino = ArduinoListView.SelectedItem as Arduino;
                DetailContentPresenter.Visibility = Visibility.Visible;
            }
        }
    }
}
