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
        List<DTOProveedor> ListarProveedores();
    }

    [DataContract]
    public class DTOProveedor
    {
        string rut = string.Empty;
        string nombrefantasia = string.Empty;
        string email = string.Empty;
        string telefono = string.Empty;
        bool activo = false;
        List<Servicio> servicios = null;
        double porcentaje = 0;

        [DataMember]
        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        [DataMember]
        public string Nombre
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

        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        [DataMember]
        public List<Servicio> Servicios
        {
            get { return servicios; }
            set { servicios = value; }
        }

        [DataMember]
        public Double Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }
        
    }
}