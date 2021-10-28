﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReferenceProducto {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceProducto.IServicioProducto")]
    public interface IServicioProducto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/Add", ReplyAction="http://tempuri.org/IServicioProducto/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        SL_WCF.Result Add(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/Add", ReplyAction="http://tempuri.org/IServicioProducto/AddResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> AddAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/Update", ReplyAction="http://tempuri.org/IServicioProducto/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        SL_WCF.Result Update(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/Update", ReplyAction="http://tempuri.org/IServicioProducto/UpdateResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> UpdateAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/Delete", ReplyAction="http://tempuri.org/IServicioProducto/DeleteResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        SL_WCF.Result Delete(int IdProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/Delete", ReplyAction="http://tempuri.org/IServicioProducto/DeleteResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> DeleteAsync(int IdProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/GetAll", ReplyAction="http://tempuri.org/IServicioProducto/GetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        SL_WCF.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/GetAll", ReplyAction="http://tempuri.org/IServicioProducto/GetAllResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/GetById", ReplyAction="http://tempuri.org/IServicioProducto/GetByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        SL_WCF.Result GetById(int IdProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/GetById", ReplyAction="http://tempuri.org/IServicioProducto/GetByIdResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> GetByIdAsync(int IdProducto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioProductoChannel : PL.ServiceReferenceProducto.IServicioProducto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioProductoClient : System.ServiceModel.ClientBase<PL.ServiceReferenceProducto.IServicioProducto>, PL.ServiceReferenceProducto.IServicioProducto {
        
        public ServicioProductoClient() {
        }
        
        public ServicioProductoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioProductoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioProductoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioProductoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SL_WCF.Result Add(ML.Producto producto) {
            return base.Channel.Add(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> AddAsync(ML.Producto producto) {
            return base.Channel.AddAsync(producto);
        }
        
        public SL_WCF.Result Update(ML.Producto producto) {
            return base.Channel.Update(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> UpdateAsync(ML.Producto producto) {
            return base.Channel.UpdateAsync(producto);
        }
        
        public SL_WCF.Result Delete(int IdProducto) {
            return base.Channel.Delete(IdProducto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> DeleteAsync(int IdProducto) {
            return base.Channel.DeleteAsync(IdProducto);
        }
        
        public SL_WCF.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public SL_WCF.Result GetById(int IdProducto) {
            return base.Channel.GetById(IdProducto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> GetByIdAsync(int IdProducto) {
            return base.Channel.GetByIdAsync(IdProducto);
        }
    }
}
