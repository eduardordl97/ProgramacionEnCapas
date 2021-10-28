﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReferenceDepartamento {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceDepartamento.IServicioDepartamento")]
    public interface IServicioDepartamento {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/Saludar", ReplyAction="http://tempuri.org/IServicioDepartamento/SaludarResponse")]
        string Saludar(string Nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/Saludar", ReplyAction="http://tempuri.org/IServicioDepartamento/SaludarResponse")]
        System.Threading.Tasks.Task<string> SaludarAsync(string Nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/Add", ReplyAction="http://tempuri.org/IServicioDepartamento/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        SL_WCF.Result Add(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/Add", ReplyAction="http://tempuri.org/IServicioDepartamento/AddResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> AddAsync(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/Update", ReplyAction="http://tempuri.org/IServicioDepartamento/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        SL_WCF.Result Update(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/Update", ReplyAction="http://tempuri.org/IServicioDepartamento/UpdateResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> UpdateAsync(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/Delete", ReplyAction="http://tempuri.org/IServicioDepartamento/DeleteResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        SL_WCF.Result Delete(int IdDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/Delete", ReplyAction="http://tempuri.org/IServicioDepartamento/DeleteResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> DeleteAsync(int IdDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/GetAll", ReplyAction="http://tempuri.org/IServicioDepartamento/GetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        SL_WCF.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/GetAll", ReplyAction="http://tempuri.org/IServicioDepartamento/GetAllResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/GetById", ReplyAction="http://tempuri.org/IServicioDepartamento/GetByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        SL_WCF.Result GetById(int IdDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioDepartamento/GetById", ReplyAction="http://tempuri.org/IServicioDepartamento/GetByIdResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> GetByIdAsync(int IdDepartamento);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioDepartamentoChannel : PL.ServiceReferenceDepartamento.IServicioDepartamento, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioDepartamentoClient : System.ServiceModel.ClientBase<PL.ServiceReferenceDepartamento.IServicioDepartamento>, PL.ServiceReferenceDepartamento.IServicioDepartamento {
        
        public ServicioDepartamentoClient() {
        }
        
        public ServicioDepartamentoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioDepartamentoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioDepartamentoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioDepartamentoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Saludar(string Nombre) {
            return base.Channel.Saludar(Nombre);
        }
        
        public System.Threading.Tasks.Task<string> SaludarAsync(string Nombre) {
            return base.Channel.SaludarAsync(Nombre);
        }
        
        public SL_WCF.Result Add(ML.Departamento departamento) {
            return base.Channel.Add(departamento);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> AddAsync(ML.Departamento departamento) {
            return base.Channel.AddAsync(departamento);
        }
        
        public SL_WCF.Result Update(ML.Departamento departamento) {
            return base.Channel.Update(departamento);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> UpdateAsync(ML.Departamento departamento) {
            return base.Channel.UpdateAsync(departamento);
        }
        
        public SL_WCF.Result Delete(int IdDepartamento) {
            return base.Channel.Delete(IdDepartamento);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> DeleteAsync(int IdDepartamento) {
            return base.Channel.DeleteAsync(IdDepartamento);
        }
        
        public SL_WCF.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public SL_WCF.Result GetById(int IdDepartamento) {
            return base.Channel.GetById(IdDepartamento);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> GetByIdAsync(int IdDepartamento) {
            return base.Channel.GetByIdAsync(IdDepartamento);
        }
    }
}
