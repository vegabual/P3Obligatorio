using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntidadesNegocio;

namespace WCFProveedorXRut
{
    [ServiceContract]
    public interface IServicioProveedorXRut
    {
        [OperationContract]
        Proveedor FindById(string rut);
    }

    [DataContract]
    public class CompositeType
    {
        string rut = string.Empty;

        [DataMember]
        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }
    }
}
