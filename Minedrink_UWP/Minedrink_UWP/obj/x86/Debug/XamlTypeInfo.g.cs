﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Minedrink_UWP
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace Minedrink_UWP.Minedrink_UWP_XamlTypeInfo
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[22];
            _typeNameTable[0] = "Minedrink_UWP.Contorl.NotifyFoot";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[2] = "Minedrink_UWP.Contorl.PageHeader";
            _typeNameTable[3] = "Windows.UI.Xaml.UIElement";
            _typeNameTable[4] = "Minedrink_UWP.Triggers.IsTenFootTrigger";
            _typeNameTable[5] = "Windows.UI.Xaml.StateTriggerBase";
            _typeNameTable[6] = "Boolean";
            _typeNameTable[7] = "Minedrink_UWP.NavMenuListView";
            _typeNameTable[8] = "Windows.UI.Xaml.Controls.ListView";
            _typeNameTable[9] = "Windows.UI.Xaml.Controls.ItemsControl";
            _typeNameTable[10] = "Minedrink_UWP.MainPage";
            _typeNameTable[11] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[12] = "Windows.Foundation.Rect";
            _typeNameTable[13] = "Windows.UI.Xaml.Controls.Frame";
            _typeNameTable[14] = "Windows.UI.Color";
            _typeNameTable[15] = "System.ValueType";
            _typeNameTable[16] = "Object";
            _typeNameTable[17] = "Byte";
            _typeNameTable[18] = "Minedrink_UWP.View.ConfigPage";
            _typeNameTable[19] = "Minedrink_UWP.View.LandingPage";
            _typeNameTable[20] = "Minedrink_UWP.View.MonitorPage";
            _typeNameTable[21] = "Minedrink_UWP.View.OverviewPage";

            _typeTable = new global::System.Type[22];
            _typeTable[0] = typeof(global::Minedrink_UWP.Contorl.NotifyFoot);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[2] = typeof(global::Minedrink_UWP.Contorl.PageHeader);
            _typeTable[3] = typeof(global::Windows.UI.Xaml.UIElement);
            _typeTable[4] = typeof(global::Minedrink_UWP.Triggers.IsTenFootTrigger);
            _typeTable[5] = typeof(global::Windows.UI.Xaml.StateTriggerBase);
            _typeTable[6] = typeof(global::System.Boolean);
            _typeTable[7] = typeof(global::Minedrink_UWP.NavMenuListView);
            _typeTable[8] = typeof(global::Windows.UI.Xaml.Controls.ListView);
            _typeTable[9] = typeof(global::Windows.UI.Xaml.Controls.ItemsControl);
            _typeTable[10] = typeof(global::Minedrink_UWP.MainPage);
            _typeTable[11] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[12] = typeof(global::Windows.Foundation.Rect);
            _typeTable[13] = typeof(global::Windows.UI.Xaml.Controls.Frame);
            _typeTable[14] = typeof(global::Windows.UI.Color);
            _typeTable[15] = typeof(global::System.ValueType);
            _typeTable[16] = typeof(global::System.Object);
            _typeTable[17] = typeof(global::System.Byte);
            _typeTable[18] = typeof(global::Minedrink_UWP.View.ConfigPage);
            _typeTable[19] = typeof(global::Minedrink_UWP.View.LandingPage);
            _typeTable[20] = typeof(global::Minedrink_UWP.View.MonitorPage);
            _typeTable[21] = typeof(global::Minedrink_UWP.View.OverviewPage);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_NotifyFoot() { return new global::Minedrink_UWP.Contorl.NotifyFoot(); }
        private object Activate_2_PageHeader() { return new global::Minedrink_UWP.Contorl.PageHeader(); }
        private object Activate_4_IsTenFootTrigger() { return new global::Minedrink_UWP.Triggers.IsTenFootTrigger(); }
        private object Activate_7_NavMenuListView() { return new global::Minedrink_UWP.NavMenuListView(); }
        private object Activate_10_MainPage() { return new global::Minedrink_UWP.MainPage(); }
        private object Activate_18_ConfigPage() { return new global::Minedrink_UWP.View.ConfigPage(); }
        private object Activate_19_LandingPage() { return new global::Minedrink_UWP.View.LandingPage(); }
        private object Activate_20_MonitorPage() { return new global::Minedrink_UWP.View.MonitorPage(); }
        private object Activate_21_OverviewPage() { return new global::Minedrink_UWP.View.OverviewPage(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  Minedrink_UWP.Contorl.NotifyFoot
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_0_NotifyFoot;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Minedrink_UWP.Contorl.PageHeader
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_2_PageHeader;
                userType.AddMemberName("HeaderContent");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 3:   //  Windows.UI.Xaml.UIElement
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 4:   //  Minedrink_UWP.Triggers.IsTenFootTrigger
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.StateTriggerBase"));
                userType.Activator = Activate_4_IsTenFootTrigger;
                userType.AddMemberName("IsTenFoot");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 5:   //  Windows.UI.Xaml.StateTriggerBase
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 6:   //  Boolean
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 7:   //  Minedrink_UWP.NavMenuListView
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.ListView"));
                userType.Activator = Activate_7_NavMenuListView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  Windows.UI.Xaml.Controls.ListView
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 9:   //  Windows.UI.Xaml.Controls.ItemsControl
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 10:   //  Minedrink_UWP.MainPage
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_10_MainPage;
                userType.AddMemberName("TogglePaneButtonRect");
                userType.AddMemberName("AppFrame");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 11:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 12:   //  Windows.Foundation.Rect
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 13:   //  Windows.UI.Xaml.Controls.Frame
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 14:   //  Windows.UI.Color
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
                userType.AddMemberName("A");
                userType.AddMemberName("B");
                userType.AddMemberName("G");
                userType.AddMemberName("R");
                xamlType = userType;
                break;

            case 15:   //  System.ValueType
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                xamlType = userType;
                break;

            case 16:   //  Object
                xamlType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 17:   //  Byte
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 18:   //  Minedrink_UWP.View.ConfigPage
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_18_ConfigPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 19:   //  Minedrink_UWP.View.LandingPage
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_19_LandingPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 20:   //  Minedrink_UWP.View.MonitorPage
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_20_MonitorPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 21:   //  Minedrink_UWP.View.OverviewPage
                userType = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_21_OverviewPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_PageHeader_HeaderContent(object instance)
        {
            var that = (global::Minedrink_UWP.Contorl.PageHeader)instance;
            return that.HeaderContent;
        }
        private void set_0_PageHeader_HeaderContent(object instance, object Value)
        {
            var that = (global::Minedrink_UWP.Contorl.PageHeader)instance;
            that.HeaderContent = (global::Windows.UI.Xaml.UIElement)Value;
        }
        private object get_1_IsTenFootTrigger_IsTenFoot(object instance)
        {
            var that = (global::Minedrink_UWP.Triggers.IsTenFootTrigger)instance;
            return that.IsTenFoot;
        }
        private void set_1_IsTenFootTrigger_IsTenFoot(object instance, object Value)
        {
            var that = (global::Minedrink_UWP.Triggers.IsTenFootTrigger)instance;
            that.IsTenFoot = (global::System.Boolean)Value;
        }
        private object get_2_MainPage_TogglePaneButtonRect(object instance)
        {
            var that = (global::Minedrink_UWP.MainPage)instance;
            return that.TogglePaneButtonRect;
        }
        private object get_3_MainPage_AppFrame(object instance)
        {
            var that = (global::Minedrink_UWP.MainPage)instance;
            return that.AppFrame;
        }
        private object get_4_Color_A(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.A;
        }
        private void set_4_Color_A(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.A = (global::System.Byte)Value;
        }
        private object get_5_Color_B(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.B;
        }
        private void set_5_Color_B(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.B = (global::System.Byte)Value;
        }
        private object get_6_Color_G(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.G;
        }
        private void set_6_Color_G(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.G = (global::System.Byte)Value;
        }
        private object get_7_Color_R(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.R;
        }
        private void set_7_Color_R(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.R = (global::System.Byte)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember xamlMember = null;
            global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "Minedrink_UWP.Contorl.PageHeader.HeaderContent":
                userType = (global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Minedrink_UWP.Contorl.PageHeader");
                xamlMember = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember(this, "HeaderContent", "Windows.UI.Xaml.UIElement");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_0_PageHeader_HeaderContent;
                xamlMember.Setter = set_0_PageHeader_HeaderContent;
                break;
            case "Minedrink_UWP.Triggers.IsTenFootTrigger.IsTenFoot":
                userType = (global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Minedrink_UWP.Triggers.IsTenFootTrigger");
                xamlMember = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember(this, "IsTenFoot", "Boolean");
                xamlMember.Getter = get_1_IsTenFootTrigger_IsTenFoot;
                xamlMember.Setter = set_1_IsTenFootTrigger_IsTenFoot;
                break;
            case "Minedrink_UWP.MainPage.TogglePaneButtonRect":
                userType = (global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Minedrink_UWP.MainPage");
                xamlMember = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember(this, "TogglePaneButtonRect", "Windows.Foundation.Rect");
                xamlMember.Getter = get_2_MainPage_TogglePaneButtonRect;
                xamlMember.SetIsReadOnly();
                break;
            case "Minedrink_UWP.MainPage.AppFrame":
                userType = (global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Minedrink_UWP.MainPage");
                xamlMember = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember(this, "AppFrame", "Windows.UI.Xaml.Controls.Frame");
                xamlMember.Getter = get_3_MainPage_AppFrame;
                xamlMember.SetIsReadOnly();
                break;
            case "Windows.UI.Color.A":
                userType = (global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember(this, "A", "Byte");
                xamlMember.Getter = get_4_Color_A;
                xamlMember.Setter = set_4_Color_A;
                break;
            case "Windows.UI.Color.B":
                userType = (global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember(this, "B", "Byte");
                xamlMember.Getter = get_5_Color_B;
                xamlMember.Setter = set_5_Color_B;
                break;
            case "Windows.UI.Color.G":
                userType = (global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember(this, "G", "Byte");
                xamlMember.Getter = get_6_Color_G;
                xamlMember.Setter = set_6_Color_G;
                break;
            case "Windows.UI.Color.R":
                userType = (global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlMember(this, "R", "Byte");
                xamlMember.Getter = get_7_Color_R;
                xamlMember.Setter = set_7_Color_R;
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlSystemBaseType
    {
        global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::Minedrink_UWP.Minedrink_UWP_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}

