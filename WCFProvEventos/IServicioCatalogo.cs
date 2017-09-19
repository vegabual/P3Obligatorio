using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntidadesNegocio;

namespace WCFProvEventos
{
    [ServiceContract]
    public interface IServicioCatalogo
    {
        [OperationContract]
        List<Servicio> FindAll();
    }

    [DataContract]
    public class CatalogoServicios
    {
        string nombre = string.Empty;
        string descripcion = string.Empty;
        string imagen = string.Empty;
        string nombreevento = string.Empty;

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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
