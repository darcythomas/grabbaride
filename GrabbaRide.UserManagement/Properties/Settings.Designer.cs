﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrabbaRide.UserManagement.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int MaxInvalidPasswordAttempts {
            get {
                return ((int)(this["MaxInvalidPasswordAttempts"]));
            }
            set {
                this["MaxInvalidPasswordAttempts"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int MinRequiredNonAlphanumericCharacters {
            get {
                return ((int)(this["MinRequiredNonAlphanumericCharacters"]));
            }
            set {
                this["MinRequiredNonAlphanumericCharacters"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int MinRequiredPasswordLength {
            get {
                return ((int)(this["MinRequiredPasswordLength"]));
            }
            set {
                this["MinRequiredPasswordLength"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int PasswordAttemptWindow {
            get {
                return ((int)(this["PasswordAttemptWindow"]));
            }
            set {
                this["PasswordAttemptWindow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("^(?=.{8,})(?=.*\\d)(?=.*[a-zA-Z]).*$")]
        public string PasswordStrengthRegularExpression {
            get {
                return ((string)(this["PasswordStrengthRegularExpression"]));
            }
            set {
                this["PasswordStrengthRegularExpression"] = value;
            }
        }
    }
}
