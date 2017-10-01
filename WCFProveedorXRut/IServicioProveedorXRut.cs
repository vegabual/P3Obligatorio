using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
<<<<<<< HEAD
using EntidadesNegocio;

namespace WCFProveedorXRut
{
    [ServiceContract]
    public interface IServicioProveedorXRut
    {
        [OperationContract]
        Proveedor_Vip FindById(string rut);
    }

    [DataContract]
    public class CompositeType
    {
        string rut = string.Empty;
        string nombrefantasia = string.Empty;
        string email = string.Empty;
        string telefono = string.Empty;

        [DataMember]
        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        [DataMember]
        public string NombreFantasia
        {
            get { return nombrefantasia; }
            set { nombrefantasia = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}
=======
using EntidadesNegocio;

namespace WCFProveedorXRut
{
    [ServiceContract]
    public interface IServicioProveedorXRut
    {
        [OperationContract]
        Proveedor_Vip FindById(string rut);
    }

    [DataContract]
    public class CompositeType
    {
        string rut = string.Empty;
        string nombrefantasia = string.Empty;
        string email = string.Empty;
        string telefono = string.Empty;

        [DataMember]
        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        [DataMember]
        public string NombreFantasia
        {
            get { return nombrefantasia; }
            set { nombrefantasia = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}
>>>>>>> 5cd4113433b66b0ca4c5cf4d3303ce21c5198061
