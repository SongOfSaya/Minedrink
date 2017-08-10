using Minedrink_UWP.Contorl;
using Minedrink_UWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Animation;
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
        public ObservableCollection<Arduino> Arduinos { get; private set; }
        public static ConfigPage Current = null;
        public ConfigPage()
        {
            this.InitializeComponent();
            this.Loaded += ConfigPage_Loaded;
            Current = this;
            ArduinoListView.Items.Add("代码添加项");

            Arduinos = Arduino.GetArduinos(2);
            if (Arduinos.Count >0)
            {
                ArduinoListView.ItemsSource = Arduinos;
            }
        }
        
        private void ConfigPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (selectedArduino == null && Arduinos.Count > 0)
            {
                selectedArduino = Arduinos[0];
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
            EnableContentTransitions();
            
        }

        private void EnableContentTransitions()
        {
            ////切换动画
            //Debug.WriteLine("播放切换动画");
            //DetailContentPresenter.ContentTransitions.Clear();
            //DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
        }

        /// <summary>
        /// 新增一个arduino
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            AddArduinoDialog dialog = new AddArduinoDialog();
            await dialog.ShowAsync();
            //ContentDialogExample dialog = new ContentDialogExample();
            //await dialog.ShowAsync();

            //if (dialog.Result == SignInResult.SignInOK)
            //{
            //    DialogResult.Text = "Dialog result successful.";
            //}
            //else if (dialog.Result == SignInResult.SignInCancel)
            //{
            //    DialogResult.Text = "Dialog result canceled.";
            //}
            //else if (dialog.Result == SignInResult.Nothing)
            //{
            //    DialogResult.Text = "Dialog dismissed.";
            //}
        }

        private void OpenItemBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ArduinoNotifyBar.IsOpen)
            {
                ArduinoNotifyBar.IsOpen = false;
            }
            else
            {
                ArduinoNotifyBar.IsOpen = true;
            }
        }
    }
}
