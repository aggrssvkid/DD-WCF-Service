//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ParallelParse", ReplyAction="http://tempuri.org/IService/ParallelParseResponse")]
        System.Collections.Generic.Dictionary<string, int> ParallelParse(string[] fContent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ParallelParse", ReplyAction="http://tempuri.org/IService/ParallelParseResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, int>> ParallelParseAsync(string[] fContent);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ConsoleClient.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ConsoleClient.ServiceReference1.IService>, ConsoleClient.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.Dictionary<string, int> ParallelParse(string[] fContent) {
            return base.Channel.ParallelParse(fContent);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, int>> ParallelParseAsync(string[] fContent) {
            return base.Channel.ParallelParseAsync(fContent);
        }
    }
}
