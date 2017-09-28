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
        int idServicio = -1;
        string descripcionServicio = string.Empty;

        [DataMember]
        public int IdServicio
        {
            get { return idServicio; }
            set { idServicio = value; }
        }

        [DataMember]
        public string DescripcionServicio
        {
            get { return descripcionServicio; }
            set { descripcionServicio = value; }
        }
    }
}
