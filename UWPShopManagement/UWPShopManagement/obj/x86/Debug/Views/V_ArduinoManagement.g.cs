﻿#pragma checksum "C:\Users\liute\Source\Repos\Minedrink\UWPShopManagement\UWPShopManagement\Views\V_ArduinoManagement.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2977CC42F59D5304CA477B8544912803"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWPShopManagement.Views
{
    partial class V_ArduinoManagement : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private static class XamlBindingSetters
        {
            public static void Set_UWPShopManagement_Views_V_ArduinoManagement_C_MasterMenuItem(global::UWPShopManagement.Views.V_ArduinoManagement_C obj, global::UWPShopManagement.Services.S_ArduinoLink value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::UWPShopManagement.Services.S_ArduinoLink) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::UWPShopManagement.Services.S_ArduinoLink), targetNullValue);
                }
                obj.MasterMenuItem = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(global::Windows.UI.Xaml.Controls.Primitives.Selector obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private class V_ArduinoManagement_obj2_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IV_ArduinoManagement_Bindings
        {
            private global::UWPShopManagement.Services.S_ArduinoLink dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj3;
            private global::Windows.UI.Xaml.Controls.TextBlock obj4;

            public V_ArduinoManagement_obj2_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // Views\V_ArduinoManagement.xaml line 26
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 4: // Views\V_ArduinoManagement.xaml line 30
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.Grid)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::UWPShopManagement.Services.S_ArduinoLink) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IV_ArduinoManagement_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::UWPShopManagement.Services.S_ArduinoLink)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::UWPShopManagement.Services.S_ArduinoLink obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Arduino(obj.Arduino, phase);
                    }
                }
            }
            private void Update_Arduino(global::UWPShopManagement.Models.M_ArduinoMarkA obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Arduino_ID(obj.ID, phase);
                        this.Update_Arduino_Name(obj.Name, phase);
                    }
                }
            }
            private void Update_Arduino_ID(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\V_ArduinoManagement.xaml line 26
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj3, obj.ToString(), null);
                }
            }
            private void Update_Arduino_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\V_ArduinoManagement.xaml line 30
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj4, obj, null);
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private class V_ArduinoManagement_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IV_ArduinoManagement_Bindings
        {
            private global::UWPShopManagement.Views.V_ArduinoManagement dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::UWPShopManagement.Views.V_ArduinoManagement_C obj12;
            private global::Windows.UI.Xaml.Controls.ListView obj16;
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj17;
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj21;

            private V_ArduinoManagement_obj1_BindingsTracking bindingsTracking;

            public V_ArduinoManagement_obj1_Bindings()
            {
                this.bindingsTracking = new V_ArduinoManagement_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 12: // Views\V_ArduinoManagement.xaml line 108
                        this.obj12 = (global::UWPShopManagement.Views.V_ArduinoManagement_C)target;
                        break;
                    case 16: // Views\V_ArduinoManagement.xaml line 79
                        this.obj16 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 17: // Views\V_ArduinoManagement.xaml line 90
                        this.obj17 = (global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction)target;
                        break;
                    case 21: // Views\V_ArduinoManagement.xaml line 118
                        this.obj21 = (global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction)target;
                        break;
                    default:
                        break;
                }
            }

            // IV_ArduinoManagement_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::UWPShopManagement.Views.V_ArduinoManagement)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::UWPShopManagement.Views.V_ArduinoManagement obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::UWPShopManagement.ViewModels.VM_ArduinoManagement obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Selected(obj.Selected, phase);
                        this.Update_ViewModel_ArduinoLinkItems(obj.ArduinoLinkItems, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_ItemClickCommand(obj.ItemClickCommand, phase);
                        this.Update_ViewModel_StateChangedCommand(obj.StateChangedCommand, phase);
                    }
                }
            }
            private void Update_ViewModel_Selected(global::UWPShopManagement.Services.S_ArduinoLink obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\V_ArduinoManagement.xaml line 108
                    XamlBindingSetters.Set_UWPShopManagement_Views_V_ArduinoManagement_C_MasterMenuItem(this.obj12, obj, null);
                    // Views\V_ArduinoManagement.xaml line 79
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj16, obj, null);
                }
            }
            private void Update_ViewModel_ArduinoLinkItems(global::System.Collections.ObjectModel.ObservableCollection<global::UWPShopManagement.Services.S_ArduinoLink> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel_ArduinoLinkItems(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\V_ArduinoManagement.xaml line 79
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj16, obj, null);
                }
            }
            private void Update_ViewModel_ItemClickCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\V_ArduinoManagement.xaml line 90
                    XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj17, obj, null);
                }
            }
            private void Update_ViewModel_StateChangedCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\V_ArduinoManagement.xaml line 118
                    XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj21, obj, null);
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
            private class V_ArduinoManagement_obj1_BindingsTracking
            {
                private global::System.WeakReference<V_ArduinoManagement_obj1_Bindings> weakRefToBindingObj; 

                public V_ArduinoManagement_obj1_BindingsTracking(V_ArduinoManagement_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<V_ArduinoManagement_obj1_Bindings>(obj);
                }

                public V_ArduinoManagement_obj1_Bindings TryGetBindingObject()
                {
                    V_ArduinoManagement_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                    UpdateChildListeners_ViewModel_ArduinoLinkItems(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    V_ArduinoManagement_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::UWPShopManagement.ViewModels.VM_ArduinoManagement obj = sender as global::UWPShopManagement.ViewModels.VM_ArduinoManagement;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_Selected(obj.Selected, DATA_CHANGED);
                                bindings.Update_ViewModel_ArduinoLinkItems(obj.ArduinoLinkItems, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Selected":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Selected(obj.Selected, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "ArduinoLinkItems":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_ArduinoLinkItems(obj.ArduinoLinkItems, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::UWPShopManagement.ViewModels.VM_ArduinoManagement cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::UWPShopManagement.ViewModels.VM_ArduinoManagement obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
                public void PropertyChanged_ViewModel_ArduinoLinkItems(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    V_ArduinoManagement_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::UWPShopManagement.Services.S_ArduinoLink> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::UWPShopManagement.Services.S_ArduinoLink>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_ViewModel_ArduinoLinkItems(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    V_ArduinoManagement_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::UWPShopManagement.Services.S_ArduinoLink> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::UWPShopManagement.Services.S_ArduinoLink>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::UWPShopManagement.Services.S_ArduinoLink> cache_ViewModel_ArduinoLinkItems = null;
                public void UpdateChildListeners_ViewModel_ArduinoLinkItems(global::System.Collections.ObjectModel.ObservableCollection<global::UWPShopManagement.Services.S_ArduinoLink> obj)
                {
                    if (obj != cache_ViewModel_ArduinoLinkItems)
                    {
                        if (cache_ViewModel_ArduinoLinkItems != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel_ArduinoLinkItems).PropertyChanged -= PropertyChanged_ViewModel_ArduinoLinkItems;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_ViewModel_ArduinoLinkItems).CollectionChanged -= CollectionChanged_ViewModel_ArduinoLinkItems;
                            cache_ViewModel_ArduinoLinkItems = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel_ArduinoLinkItems = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel_ArduinoLinkItems;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_ViewModel_ArduinoLinkItems;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 5: // Views\V_ArduinoManagement.xaml line 38
                {
                    this.ContentArea = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // Views\V_ArduinoManagement.xaml line 43
                {
                    this.TitleRow = (global::Windows.UI.Xaml.Controls.RowDefinition)(target);
                }
                break;
            case 7: // Views\V_ArduinoManagement.xaml line 48
                {
                    this.MasterColumn = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 8: // Views\V_ArduinoManagement.xaml line 49
                {
                    this.DetailColumn = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 9: // Views\V_ArduinoManagement.xaml line 52
                {
                    this.TitlePage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // Views\V_ArduinoManagement.xaml line 59
                {
                    this.MasterArea = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 11: // Views\V_ArduinoManagement.xaml line 102
                {
                    this.DetailContentPresenter = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 12: // Views\V_ArduinoManagement.xaml line 108
                {
                    this.DetailControl = (global::UWPShopManagement.Views.V_ArduinoManagement_C)(target);
                }
                break;
            case 13: // Views\V_ArduinoManagement.xaml line 64
                {
                    this.MasterRow = (global::Windows.UI.Xaml.Controls.RowDefinition)(target);
                }
                break;
            case 14: // Views\V_ArduinoManagement.xaml line 65
                {
                    this.MasterBtnRow = (global::Windows.UI.Xaml.Controls.RowDefinition)(target);
                }
                break;
            case 15: // Views\V_ArduinoManagement.xaml line 69
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Views\V_ArduinoManagement.xaml line 79
                {
                    this.MasterListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 18: // Views\V_ArduinoManagement.xaml line 75
                {
                    this.AddArduinoBtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 19: // Views\V_ArduinoManagement.xaml line 76
                {
                    this.RefreshAduBtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 20: // Views\V_ArduinoManagement.xaml line 115
                {
                    this.WindowStates = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 22: // Views\V_ArduinoManagement.xaml line 121
                {
                    this.WideState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 23: // Views\V_ArduinoManagement.xaml line 130
                {
                    this.NarrowState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\V_ArduinoManagement.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    V_ArduinoManagement_obj1_Bindings bindings = new V_ArduinoManagement_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 2: // Views\V_ArduinoManagement.xaml line 20
                {                    
                    global::Windows.UI.Xaml.Controls.Grid element2 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    V_ArduinoManagement_obj2_Bindings bindings = new V_ArduinoManagement_obj2_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element2.DataContext);
                    element2.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element2, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

