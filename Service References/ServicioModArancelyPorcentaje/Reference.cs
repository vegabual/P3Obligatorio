﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterfazWeb.ServicioModArancelyPorcentaje {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioModArancelyPorcentaje.IServicioModArancelyPorcentaje")]
    public interface IServicioModArancelyPorcentaje {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioModArancelyPorcentaje/ModificarArancel", ReplyAction="http://tempuri.org/IServicioModArancelyPorcentaje/ModificarArancelResponse")]
        bool ModificarArancel(double arancel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioModArancelyPorcentaje/ModificarArancel", ReplyAction="http://tempuri.org/IServicioModArancelyPorcentaje/ModificarArancelResponse")]
        System.Threading.Tasks.Task<bool> ModificarArancelAsync(double arancel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioModArancelyPorcentaje/ModificarPorcentaje", ReplyAction="http://tempuri.org/IServicioModArancelyPorcentaje/ModificarPorcentajeResponse")]
        bool ModificarPorcentaje(double porcentaje);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioModArancelyPorcentaje/ModificarPorcentaje", ReplyAction="http://tempuri.org/IServicioModArancelyPorcentaje/ModificarPorcentajeResponse")]
        System.Threading.Tasks.Task<bool> ModificarPorcentajeAsync(double porcentaje);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioModArancelyPorcentajeChannel : InterfazWeb.ServicioModArancelyPorcentaje.IServicioModArancelyPorcentaje, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioModArancelyPorcentajeClient : System.ServiceModel.ClientBase<InterfazWeb.ServicioModArancelyPorcentaje.IServicioModArancelyPorcentaje>, InterfazWeb.ServicioModArancelyPorcentaje.IServicioModArancelyPorcentaje {
        
        public ServicioModArancelyPorcentajeClient() {
        }
        
        public ServicioModArancelyPorcentajeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioModArancelyPorcentajeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioModArancelyPorcentajeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioModArancelyPorcentajeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ModificarArancel(double arancel) {
            return base.Channel.ModificarArancel(arancel);
        }
        
        public System.Threading.Tasks.Task<bool> ModificarArancelAsync(double arancel) {
            return base.Channel.ModificarArancelAsync(arancel);
        }
        
        public bool ModificarPorcentaje(double porcentaje) {
            return base.Channel.ModificarPorcentaje(porcentaje);
        }
        
        public System.Threading.Tasks.Task<bool> ModificarPorcentajeAsync(double porcentaje) {
            return base.Channel.ModificarPorcentajeAsync(porcentaje);
        }
    }
}