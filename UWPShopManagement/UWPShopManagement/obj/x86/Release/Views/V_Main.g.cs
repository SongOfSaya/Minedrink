﻿#pragma checksum "C:\Users\liute\Source\Repos\Minedrink\UWPShopManagement\UWPShopManagement\Views\V_Main.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5E39B50123951C1EBBE3B327E0EF8EA8"
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
    partial class V_Main : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\V_Main.xaml line 8
                {
                    this.ContentArea = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2: // Views\V_Main.xaml line 13
                {
                    this.TitleRow = (global::Windows.UI.Xaml.Controls.RowDefinition)(target);
                }
                break;
            case 3: // Views\V_Main.xaml line 17
                {
                    this.TitlePage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Views\V_Main.xaml line 27
                {
                    this.TestBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.TestBtn).Click += this.Button_Click;
                }
                break;
            case 5: // Views\V_Main.xaml line 31
                {
                    this.TestTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Views\V_Main.xaml line 37
                {
                    this.WindowStates = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 7: // Views\V_Main.xaml line 38
                {
                    this.WideState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 8: // Views\V_Main.xaml line 43
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
            return returnValue;
        }
    }
}

