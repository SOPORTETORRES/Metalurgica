﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Metalurgica.Px_Conectores {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://torresOcaranza.cl/", ConfigurationName="Px_Conectores.Ws_ConectoresSoap")]
    public interface Ws_ConectoresSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://torresOcaranza.cl/NroConectoresPorDia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string NroConectoresPorDia(string idia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://torresOcaranza.cl/DetalleConectoresPorDia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Metalurgica.Px_Conectores.ListaDataSet DetalleConectoresPorDia(string idia);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://torresOcaranza.cl/")]
    public partial class ListaDataSet : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Data.DataSet _dataSetField;
        
        private string _errorField;
        
        private System.Data.DataSet dataSetField;
        
        private string mensajeErrorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.Data.DataSet _dataSet {
            get {
                return this._dataSetField;
            }
            set {
                this._dataSetField = value;
                this.RaisePropertyChanged("_dataSet");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string _error {
            get {
                return this._errorField;
            }
            set {
                this._errorField = value;
                this.RaisePropertyChanged("_error");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public System.Data.DataSet DataSet {
            get {
                return this.dataSetField;
            }
            set {
                this.dataSetField = value;
                this.RaisePropertyChanged("DataSet");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string MensajeError {
            get {
                return this.mensajeErrorField;
            }
            set {
                this.mensajeErrorField = value;
                this.RaisePropertyChanged("MensajeError");
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
    public interface Ws_ConectoresSoapChannel : Metalurgica.Px_Conectores.Ws_ConectoresSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Ws_ConectoresSoapClient : System.ServiceModel.ClientBase<Metalurgica.Px_Conectores.Ws_ConectoresSoap>, Metalurgica.Px_Conectores.Ws_ConectoresSoap {
        
        public Ws_ConectoresSoapClient() {
        }
        
        public Ws_ConectoresSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Ws_ConectoresSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Ws_ConectoresSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Ws_ConectoresSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string NroConectoresPorDia(string idia) {
            return base.Channel.NroConectoresPorDia(idia);
        }
        
        public Metalurgica.Px_Conectores.ListaDataSet DetalleConectoresPorDia(string idia) {
            return base.Channel.DetalleConectoresPorDia(idia);
        }
    }
}
