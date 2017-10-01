using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntidadesNegocio;

namespace WCFDesactivarProveedor
{
    [ServiceContract]
    public interface IServicioDesactivarProveedor
    {
        [OperationContract]
        bool DesactivarProveedor(string rut, bool activo);
    }

    [DataContract]
    public class CompositeType
    {
        string rut = string.Empty;
        bool activo = false;

        [DataMember]
        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
    }
}
