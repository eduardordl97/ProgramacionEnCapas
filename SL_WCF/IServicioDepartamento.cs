using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioDepartamento" in both code and config file together.
    [ServiceContract]
    public interface IServicioDepartamento
    {
        [OperationContract]
        string Saludar(string Nombre);

        [OperationContract]
        SL_WCF.Result Add(ML.Departamento departamento);

        [OperationContract]
        SL_WCF.Result Update(ML.Departamento departamento);

        [OperationContract]
        SL_WCF.Result Delete(int IdDepartamento);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Departamento))]
        SL_WCF.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Departamento))]
        SL_WCF.Result GetById(int IdDepartamento);


    }
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public object Object { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
    }
}
