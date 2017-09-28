using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfNuevoProveedor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicioNuevoProv
    {

        [OperationContract]
        bool NuevoProveedor(string rut, string clave, string nombre, string email, string telefono, bool vip, List<DTOServicio> dtoServicios);
        
    }

    [DataContract]
    public class DTOServicio
    {
        string nombreservicio = string.Empty;
        string descripcion = string.Empty;
        string imagen = string.Empty;
        string nombreevento = string.Empty;

        [DataMember]
        public string Nombreservicio
        {
            get { return nombreservicio; }
            set { nombreservicio = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [DataMember]
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        [DataMember]
        public string Nombreevento
        {
            get { return nombreevento; }
            set { nombreevento = value; }
        }
    }
}
