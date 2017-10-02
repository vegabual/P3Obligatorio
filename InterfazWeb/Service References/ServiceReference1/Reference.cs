﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterfazWeb.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTOProveedor", Namespace="http://schemas.datacontract.org/2004/07/WCFListaProveedores")]
    [System.SerializableAttribute()]
    public partial class DTOProveedor : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreFantasiaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PorcentajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RutField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private EntidadesNegocio.Servicio[] ServiciosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
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
        public bool Activo {
            get {
                return this.ActivoField;
            }
            set {
                if ((this.ActivoField.Equals(value) != true)) {
                    this.ActivoField = value;
                    this.RaisePropertyChanged("Activo");
                }
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
        public string NombreFantasia {
            get {
                return this.NombreFantasiaField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreFantasiaField, value) != true)) {
                    this.NombreFantasiaField = value;
                    this.RaisePropertyChanged("NombreFantasia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Porcentaje {
            get {
                return this.PorcentajeField;
            }
            set {
                if ((this.PorcentajeField.Equals(value) != true)) {
                    this.PorcentajeField = value;
                    this.RaisePropertyChanged("Porcentaje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Rut {
            get {
                return this.RutField;
            }
            set {
                if ((object.ReferenceEquals(this.RutField, value) != true)) {
                    this.RutField = value;
                    this.RaisePropertyChanged("Rut");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public EntidadesNegocio.Servicio[] Servicios {
            get {
                return this.ServiciosField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiciosField, value) != true)) {
                    this.ServiciosField = value;
                    this.RaisePropertyChanged("Servicios");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IServicioListaProveedores")]
    public interface IServicioListaProveedores {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioListaProveedores/ListarProveedores", ReplyAction="http://tempuri.org/IServicioListaProveedores/ListarProveedoresResponse")]
        InterfazWeb.ServiceReference1.DTOProveedor[] ListarProveedores();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioListaProveedores/ListarProveedores", ReplyAction="http://tempuri.org/IServicioListaProveedores/ListarProveedoresResponse")]
        System.Threading.Tasks.Task<InterfazWeb.ServiceReference1.DTOProveedor[]> ListarProveedoresAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioListaProveedoresChannel : InterfazWeb.ServiceReference1.IServicioListaProveedores, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioListaProveedoresClient : System.ServiceModel.ClientBase<InterfazWeb.ServiceReference1.IServicioListaProveedores>, InterfazWeb.ServiceReference1.IServicioListaProveedores {
        
        public ServicioListaProveedoresClient() {
        }
        
        public ServicioListaProveedoresClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioListaProveedoresClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioListaProveedoresClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioListaProveedoresClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public InterfazWeb.ServiceReference1.DTOProveedor[] ListarProveedores() {
            return base.Channel.ListarProveedores();
        }
        
        public System.Threading.Tasks.Task<InterfazWeb.ServiceReference1.DTOProveedor[]> ListarProveedoresAsync() {
            return base.Channel.ListarProveedoresAsync();
        }
    }
}
