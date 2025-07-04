﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Universal_Planner
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlTypeInfoProvider();
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
                _provider = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlTypeInfoProvider();
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

namespace Universal_Planner.Universal_Planner_XamlTypeInfo
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
            _typeNameTable = new string[18];
            _typeNameTable[0] = "Universal_Planner.Pages.planner";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[3] = "Universal_Planner.Pages.PomodoroPage";
            _typeNameTable[4] = "String";
            _typeNameTable[5] = "Universal_Planner.Pages.SettingsPage";
            _typeNameTable[6] = "Universal_Planner.Pages.SettingsPageGeneral";
            _typeNameTable[7] = "Universal_Planner.Componets.Pages.SettingsPagePomodoro";
            _typeNameTable[8] = "Universal_Planner.Componets.Pages.Statistics";
            _typeNameTable[9] = "Universal_Planner.Componets.Converters.DateOnlyConverter";
            _typeNameTable[10] = "Object";
            _typeNameTable[11] = "Universal_Planner.Componets.Converters.TimeOnlyConverter";
            _typeNameTable[12] = "Universal_Planner.Componets.Converters.DateTimeToStringConverter";
            _typeNameTable[13] = "Universal_Planner.Componets.Converters.BoolToIndent";
            _typeNameTable[14] = "Universal_Planner.Componets.Converters.LevelIndent";
            _typeNameTable[15] = "Universal_Planner.Componets.Converters.LevelToMargin";
            _typeNameTable[16] = "Universal_Planner.MainPage";
            _typeNameTable[17] = "Universal_Planner.Pages.StartScreen";

            _typeTable = new global::System.Type[18];
            _typeTable[0] = typeof(global::Universal_Planner.Pages.planner);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[2] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[3] = typeof(global::Universal_Planner.Pages.PomodoroPage);
            _typeTable[4] = typeof(global::System.String);
            _typeTable[5] = typeof(global::Universal_Planner.Pages.SettingsPage);
            _typeTable[6] = typeof(global::Universal_Planner.Pages.SettingsPageGeneral);
            _typeTable[7] = typeof(global::Universal_Planner.Componets.Pages.SettingsPagePomodoro);
            _typeTable[8] = typeof(global::Universal_Planner.Componets.Pages.Statistics);
            _typeTable[9] = typeof(global::Universal_Planner.Componets.Converters.DateOnlyConverter);
            _typeTable[10] = typeof(global::System.Object);
            _typeTable[11] = typeof(global::Universal_Planner.Componets.Converters.TimeOnlyConverter);
            _typeTable[12] = typeof(global::Universal_Planner.Componets.Converters.DateTimeToStringConverter);
            _typeTable[13] = typeof(global::Universal_Planner.Componets.Converters.BoolToIndent);
            _typeTable[14] = typeof(global::Universal_Planner.Componets.Converters.LevelIndent);
            _typeTable[15] = typeof(global::Universal_Planner.Componets.Converters.LevelToMargin);
            _typeTable[16] = typeof(global::Universal_Planner.MainPage);
            _typeTable[17] = typeof(global::Universal_Planner.Pages.StartScreen);
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

        private object Activate_0_planner() { return new global::Universal_Planner.Pages.planner(); }
        private object Activate_3_PomodoroPage() { return new global::Universal_Planner.Pages.PomodoroPage(); }
        private object Activate_5_SettingsPage() { return new global::Universal_Planner.Pages.SettingsPage(); }
        private object Activate_6_SettingsPageGeneral() { return new global::Universal_Planner.Pages.SettingsPageGeneral(); }
        private object Activate_7_SettingsPagePomodoro() { return new global::Universal_Planner.Componets.Pages.SettingsPagePomodoro(); }
        private object Activate_8_Statistics() { return new global::Universal_Planner.Componets.Pages.Statistics(); }
        private object Activate_9_DateOnlyConverter() { return new global::Universal_Planner.Componets.Converters.DateOnlyConverter(); }
        private object Activate_11_TimeOnlyConverter() { return new global::Universal_Planner.Componets.Converters.TimeOnlyConverter(); }
        private object Activate_12_DateTimeToStringConverter() { return new global::Universal_Planner.Componets.Converters.DateTimeToStringConverter(); }
        private object Activate_13_BoolToIndent() { return new global::Universal_Planner.Componets.Converters.BoolToIndent(); }
        private object Activate_14_LevelIndent() { return new global::Universal_Planner.Componets.Converters.LevelIndent(); }
        private object Activate_15_LevelToMargin() { return new global::Universal_Planner.Componets.Converters.LevelToMargin(); }
        private object Activate_16_MainPage() { return new global::Universal_Planner.MainPage(); }
        private object Activate_17_StartScreen() { return new global::Universal_Planner.Pages.StartScreen(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  Universal_Planner.Pages.planner
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_0_planner;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  Universal_Planner.Pages.PomodoroPage
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_3_PomodoroPage;
                userType.AddMemberName("TimeDisplay");
                userType.AddMemberName("CurrentPhaseLabel");
                userType.AddMemberName("PhaseCounterDisplay");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 4:   //  String
                xamlType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  Universal_Planner.Pages.SettingsPage
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_5_SettingsPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 6:   //  Universal_Planner.Pages.SettingsPageGeneral
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_6_SettingsPageGeneral;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 7:   //  Universal_Planner.Componets.Pages.SettingsPagePomodoro
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_7_SettingsPagePomodoro;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  Universal_Planner.Componets.Pages.Statistics
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_8_Statistics;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 9:   //  Universal_Planner.Componets.Converters.DateOnlyConverter
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_9_DateOnlyConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 10:   //  Object
                xamlType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 11:   //  Universal_Planner.Componets.Converters.TimeOnlyConverter
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_11_TimeOnlyConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 12:   //  Universal_Planner.Componets.Converters.DateTimeToStringConverter
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_12_DateTimeToStringConverter;
                userType.AddMemberName("Format");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 13:   //  Universal_Planner.Componets.Converters.BoolToIndent
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_13_BoolToIndent;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 14:   //  Universal_Planner.Componets.Converters.LevelIndent
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_14_LevelIndent;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 15:   //  Universal_Planner.Componets.Converters.LevelToMargin
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_15_LevelToMargin;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 16:   //  Universal_Planner.MainPage
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_16_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 17:   //  Universal_Planner.Pages.StartScreen
                userType = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_17_StartScreen;
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_PomodoroPage_TimeDisplay(object instance)
        {
            var that = (global::Universal_Planner.Pages.PomodoroPage)instance;
            return that.TimeDisplay;
        }
        private object get_1_PomodoroPage_CurrentPhaseLabel(object instance)
        {
            var that = (global::Universal_Planner.Pages.PomodoroPage)instance;
            return that.CurrentPhaseLabel;
        }
        private object get_2_PomodoroPage_PhaseCounterDisplay(object instance)
        {
            var that = (global::Universal_Planner.Pages.PomodoroPage)instance;
            return that.PhaseCounterDisplay;
        }
        private object get_3_DateTimeToStringConverter_Format(object instance)
        {
            var that = (global::Universal_Planner.Componets.Converters.DateTimeToStringConverter)instance;
            return that.Format;
        }
        private void set_3_DateTimeToStringConverter_Format(object instance, object Value)
        {
            var that = (global::Universal_Planner.Componets.Converters.DateTimeToStringConverter)instance;
            that.Format = (global::System.String)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlMember xamlMember = null;
            global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "Universal_Planner.Pages.PomodoroPage.TimeDisplay":
                userType = (global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Universal_Planner.Pages.PomodoroPage");
                xamlMember = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlMember(this, "TimeDisplay", "String");
                xamlMember.Getter = get_0_PomodoroPage_TimeDisplay;
                xamlMember.SetIsReadOnly();
                break;
            case "Universal_Planner.Pages.PomodoroPage.CurrentPhaseLabel":
                userType = (global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Universal_Planner.Pages.PomodoroPage");
                xamlMember = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlMember(this, "CurrentPhaseLabel", "String");
                xamlMember.Getter = get_1_PomodoroPage_CurrentPhaseLabel;
                xamlMember.SetIsReadOnly();
                break;
            case "Universal_Planner.Pages.PomodoroPage.PhaseCounterDisplay":
                userType = (global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Universal_Planner.Pages.PomodoroPage");
                xamlMember = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlMember(this, "PhaseCounterDisplay", "String");
                xamlMember.Getter = get_2_PomodoroPage_PhaseCounterDisplay;
                xamlMember.SetIsReadOnly();
                break;
            case "Universal_Planner.Componets.Converters.DateTimeToStringConverter.Format":
                userType = (global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Universal_Planner.Componets.Converters.DateTimeToStringConverter");
                xamlMember = new global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlMember(this, "Format", "String");
                xamlMember.Getter = get_3_DateTimeToStringConverter_Format;
                xamlMember.Setter = set_3_DateTimeToStringConverter_Format;
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
    internal class XamlUserType : global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlSystemBaseType
    {
        global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlTypeInfoProvider _provider;
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

        public XamlUserType(global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
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
        global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::Universal_Planner.Universal_Planner_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
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

