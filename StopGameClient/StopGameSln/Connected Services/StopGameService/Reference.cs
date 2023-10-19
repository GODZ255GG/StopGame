﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StopGame.StopGameService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Logic")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUser {
            get {
                return this.IdUserField;
            }
            set {
                if ((this.IdUserField.Equals(value) != true)) {
                    this.IdUserField = value;
                    this.RaisePropertyChanged("IdUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StopGameService.IUserManager")]
    public interface IUserManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManager/Login", ReplyAction="http://tempuri.org/IUserManager/LoginResponse")]
        StopGame.StopGameService.User Login(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManager/Login", ReplyAction="http://tempuri.org/IUserManager/LoginResponse")]
        System.Threading.Tasks.Task<StopGame.StopGameService.User> LoginAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManager/Register", ReplyAction="http://tempuri.org/IUserManager/RegisterResponse")]
        bool Register(StopGame.StopGameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManager/Register", ReplyAction="http://tempuri.org/IUserManager/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(StopGame.StopGameService.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserManagerChannel : StopGame.StopGameService.IUserManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserManagerClient : System.ServiceModel.ClientBase<StopGame.StopGameService.IUserManager>, StopGame.StopGameService.IUserManager {
        
        public UserManagerClient() {
        }
        
        public UserManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public StopGame.StopGameService.User Login(string userName, string password) {
            return base.Channel.Login(userName, password);
        }
        
        public System.Threading.Tasks.Task<StopGame.StopGameService.User> LoginAsync(string userName, string password) {
            return base.Channel.LoginAsync(userName, password);
        }
        
        public bool Register(StopGame.StopGameService.User user) {
            return base.Channel.Register(user);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(StopGame.StopGameService.User user) {
            return base.Channel.RegisterAsync(user);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StopGameService.IUpdateProfile")]
    public interface IUpdateProfile {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateProfile/GetGlobalUser", ReplyAction="http://tempuri.org/IUpdateProfile/GetGlobalUserResponse")]
        string[] GetGlobalUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateProfile/GetGlobalUser", ReplyAction="http://tempuri.org/IUpdateProfile/GetGlobalUserResponse")]
        System.Threading.Tasks.Task<string[]> GetGlobalUserAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUpdateProfileChannel : StopGame.StopGameService.IUpdateProfile, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateProfileClient : System.ServiceModel.ClientBase<StopGame.StopGameService.IUpdateProfile>, StopGame.StopGameService.IUpdateProfile {
        
        public UpdateProfileClient() {
        }
        
        public UpdateProfileClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UpdateProfileClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpdateProfileClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpdateProfileClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetGlobalUser() {
            return base.Channel.GetGlobalUser();
        }
        
        public System.Threading.Tasks.Task<string[]> GetGlobalUserAsync() {
            return base.Channel.GetGlobalUserAsync();
        }
    }
}
