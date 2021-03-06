﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KR.ServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceRef.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Select", ReplyAction="http://tempuri.org/IService1/SelectResponse")]
        System.Data.DataSet Select(System.DateTime before, System.DateTime after);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Select", ReplyAction="http://tempuri.org/IService1/SelectResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> SelectAsync(System.DateTime before, System.DateTime after);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Insert", ReplyAction="http://tempuri.org/IService1/InsertResponse")]
        string Insert(int k, System.DateTime cur, string author, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Insert", ReplyAction="http://tempuri.org/IService1/InsertResponse")]
        System.Threading.Tasks.Task<string> InsertAsync(int k, System.DateTime cur, string author, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Update", ReplyAction="http://tempuri.org/IService1/UpdateResponse")]
        string Update(int k, System.DateTime cur, string author, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Update", ReplyAction="http://tempuri.org/IService1/UpdateResponse")]
        System.Threading.Tasks.Task<string> UpdateAsync(int k, System.DateTime cur, string author, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Delete", ReplyAction="http://tempuri.org/IService1/DeleteResponse")]
        string Delete(int k);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Delete", ReplyAction="http://tempuri.org/IService1/DeleteResponse")]
        System.Threading.Tasks.Task<string> DeleteAsync(int k);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : KR.ServiceRef.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<KR.ServiceRef.IService1>, KR.ServiceRef.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet Select(System.DateTime before, System.DateTime after) {
            return base.Channel.Select(before, after);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SelectAsync(System.DateTime before, System.DateTime after) {
            return base.Channel.SelectAsync(before, after);
        }
        
        public string Insert(int k, System.DateTime cur, string author, string description) {
            return base.Channel.Insert(k, cur, author, description);
        }
        
        public System.Threading.Tasks.Task<string> InsertAsync(int k, System.DateTime cur, string author, string description) {
            return base.Channel.InsertAsync(k, cur, author, description);
        }
        
        public string Update(int k, System.DateTime cur, string author, string description) {
            return base.Channel.Update(k, cur, author, description);
        }
        
        public System.Threading.Tasks.Task<string> UpdateAsync(int k, System.DateTime cur, string author, string description) {
            return base.Channel.UpdateAsync(k, cur, author, description);
        }
        
        public string Delete(int k) {
            return base.Channel.Delete(k);
        }
        
        public System.Threading.Tasks.Task<string> DeleteAsync(int k) {
            return base.Channel.DeleteAsync(k);
        }
    }
}
