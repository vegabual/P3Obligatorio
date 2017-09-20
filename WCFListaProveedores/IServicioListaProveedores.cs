using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntidadesNegocio;

namespace WCFListaProveedores
{
    [ServiceContract]
    public interface IServicioListaProveedores
    {
        [OperationContract]
        int ListarProveedores();
    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue;
        string stringValue;

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
