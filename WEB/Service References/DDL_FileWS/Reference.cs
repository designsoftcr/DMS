﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEB.DDL_FileWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DDL_FileWS.FileWSSoap")]
    public interface FileWSSoap {
        
        // CODEGEN: Generating message contract since element name myFile from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FileUpload", ReplyAction="*")]
        WEB.DDL_FileWS.FileUploadResponse FileUpload(WEB.DDL_FileWS.FileUploadRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class FileUploadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="FileUpload", Namespace="http://tempuri.org/", Order=0)]
        public WEB.DDL_FileWS.FileUploadRequestBody Body;
        
        public FileUploadRequest() {
        }
        
        public FileUploadRequest(WEB.DDL_FileWS.FileUploadRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class FileUploadRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public byte[] myFile;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string fileName;
        
        public FileUploadRequestBody() {
        }
        
        public FileUploadRequestBody(byte[] myFile, string fileName) {
            this.myFile = myFile;
            this.fileName = fileName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class FileUploadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="FileUploadResponse", Namespace="http://tempuri.org/", Order=0)]
        public WEB.DDL_FileWS.FileUploadResponseBody Body;
        
        public FileUploadResponse() {
        }
        
        public FileUploadResponse(WEB.DDL_FileWS.FileUploadResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class FileUploadResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string FileUploadResult;
        
        public FileUploadResponseBody() {
        }
        
        public FileUploadResponseBody(string FileUploadResult) {
            this.FileUploadResult = FileUploadResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FileWSSoapChannel : WEB.DDL_FileWS.FileWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileWSSoapClient : System.ServiceModel.ClientBase<WEB.DDL_FileWS.FileWSSoap>, WEB.DDL_FileWS.FileWSSoap {
        
        public FileWSSoapClient() {
        }
        
        public FileWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WEB.DDL_FileWS.FileUploadResponse WEB.DDL_FileWS.FileWSSoap.FileUpload(WEB.DDL_FileWS.FileUploadRequest request) {
            return base.Channel.FileUpload(request);
        }
        
        public string FileUpload(byte[] myFile, string fileName) {
            WEB.DDL_FileWS.FileUploadRequest inValue = new WEB.DDL_FileWS.FileUploadRequest();
            inValue.Body = new WEB.DDL_FileWS.FileUploadRequestBody();
            inValue.Body.myFile = myFile;
            inValue.Body.fileName = fileName;
            WEB.DDL_FileWS.FileUploadResponse retVal = ((WEB.DDL_FileWS.FileWSSoap)(this)).FileUpload(inValue);
            return retVal.Body.FileUploadResult;
        }
    }
}
