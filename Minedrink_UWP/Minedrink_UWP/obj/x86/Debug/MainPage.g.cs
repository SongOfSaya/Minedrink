﻿#pragma checksum "C:\Users\liute\Source\Repos\Minedrink\Minedrink_UWP\Minedrink_UWP\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C80997458440191C683731DB4C9683F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Minedrink_UWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_FontIcon_Glyph(global::Windows.UI.Xaml.Controls.FontIcon obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Glyph = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                global::Windows.UI.Xaml.Controls.ToolTipService.SetToolTip(obj, value);
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private class MainPage_obj3_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::Minedrink_UWP.NavMenuItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.FontIcon obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;

            public MainPage_obj3_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4: // MainPage.xaml line 47
                        this.obj4 = (global::Windows.UI.Xaml.Controls.FontIcon)target;
                        break;
                    case 5: // MainPage.xaml line 50
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
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
                this.Update_((global::Minedrink_UWP.NavMenuItem) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IMainPage_Bindings

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
                    this.dataRoot = (global::Minedrink_UWP.NavMenuItem)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Minedrink_UWP.NavMenuItem obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_SymbolAsChar(obj.SymbolAsChar, phase);
                        this.Update_Label(obj.Label, phase);
                    }
                }
            }
            private void Update_SymbolAsChar(global::System.Char obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 47
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_FontIcon_Glyph(this.obj4, obj.ToString(), null);
                }
            }
            private void Update_Label(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 47
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj4, obj, null);
                    // MainPage.xaml line 50
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private class MainPage_obj6_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::Minedrink_UWP.NavMenuItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Shapes.Rectangle obj7;
            private global::Windows.UI.Xaml.Controls.FontIcon obj8;
            private global::Windows.UI.Xaml.Controls.TextBlock obj9;

            private MainPage_obj6_BindingsTracking bindingsTracking;

            public MainPage_obj6_Bindings()
            {
                this.bindingsTracking = new MainPage_obj6_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7: // MainPage.xaml line 20
                        this.obj7 = (global::Windows.UI.Xaml.Shapes.Rectangle)target;
                        (this.obj7).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.UIElement.VisibilityProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                            if (this.initialized)
                            {
                                // Update Two Way binding
                                this.dataRoot.SelectedVis = this.obj7.Visibility;
                            }
                        });
                        break;
                    case 8: // MainPage.xaml line 31
                        this.obj8 = (global::Windows.UI.Xaml.Controls.FontIcon)target;
                        break;
                    case 9: // MainPage.xaml line 33
                        this.obj9 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
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
                this.Update_((global::Minedrink_UWP.NavMenuItem) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                this.bindingsTracking.ReleaseAllListeners();
            }

            // IMainPage_Bindings

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
                    this.dataRoot = (global::Minedrink_UWP.NavMenuItem)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Minedrink_UWP.NavMenuItem obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_SelectedVis(obj.SelectedVis, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_SymbolAsChar(obj.SymbolAsChar, phase);
                        this.Update_Label(obj.Label, phase);
                    }
                }
            }
            private void Update_SelectedVis(global::Windows.UI.Xaml.Visibility obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // MainPage.xaml line 20
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj7, obj);
                }
            }
            private void Update_SymbolAsChar(global::System.Char obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 31
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_FontIcon_Glyph(this.obj8, obj.ToString(), null);
                }
            }
            private void Update_Label(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 31
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj8, obj, null);
                    // MainPage.xaml line 33
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj9, obj, null);
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
            private class MainPage_obj6_BindingsTracking
            {
                private global::System.WeakReference<MainPage_obj6_Bindings> weakRefToBindingObj; 

                public MainPage_obj6_BindingsTracking(MainPage_obj6_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<MainPage_obj6_Bindings>(obj);
                }

                public MainPage_obj6_Bindings TryGetBindingObject()
                {
                    MainPage_obj6_Bindings bindingObject = null;
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
                    UpdateChildListeners_(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    MainPage_obj6_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Minedrink_UWP.NavMenuItem obj = sender as global::Minedrink_UWP.NavMenuItem;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_SelectedVis(obj.SelectedVis, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "SelectedVis":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_SelectedVis(obj.SelectedVis, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::Minedrink_UWP.NavMenuItem obj)
                {
                    MainPage_obj6_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
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
            case 1: // MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).KeyDown += this.MainPage_KeyDown;
                }
                break;
            case 2: // MainPage.xaml line 39
                {
                    this.NavMenuItem10ftTemplate = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 10: // MainPage.xaml line 57
                {
                    this.LayoutRoot = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 11: // MainPage.xaml line 120
                {
                    this.TogglePaneButton = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target);
                    ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.TogglePaneButton).Unchecked += this.TogglePaneButton_Unchecked;
                    ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.TogglePaneButton).Checked += this.TogglePaneButton_Checked;
                }
                break;
            case 12: // MainPage.xaml line 130
                {
                    this.RootSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                    ((global::Windows.UI.Xaml.Controls.SplitView)this.RootSplitView).PaneClosed += this.RootSplitView_PaneClosed;
                }
                break;
            case 13: // MainPage.xaml line 151
                {
                    this.NavMenuList = (global::Minedrink_UWP.NavMenuListView)(target);
                    ((global::Minedrink_UWP.NavMenuListView)this.NavMenuList).ContainerContentChanging += this.NavMenuList_ContainerContentChanging;
                    ((global::Minedrink_UWP.NavMenuListView)this.NavMenuList).ItemInvoked += this.NavMenuList_ItemInvoked;
                }
                break;
            case 14: // MainPage.xaml line 160
                {
                    this.NavPaneDivider = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 15: // MainPage.xaml line 166
                {
                    this.FeedbackNavPaneButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 16: // MainPage.xaml line 174
                {
                    this.SettingsNavPaneButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 17: // MainPage.xaml line 187
                {
                    this.frame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)this.frame).Navigating += this.frame_Navigating;
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
            case 3: // MainPage.xaml line 40
                {                    
                    global::Windows.UI.Xaml.Controls.Grid element3 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    MainPage_obj3_Bindings bindings = new MainPage_obj3_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element3.DataContext);
                    element3.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element3, bindings);
                }
                break;
            case 6: // MainPage.xaml line 15
                {                    
                    global::Windows.UI.Xaml.Controls.Grid element6 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    MainPage_obj6_Bindings bindings = new MainPage_obj6_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element6.DataContext);
                    element6.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element6, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

