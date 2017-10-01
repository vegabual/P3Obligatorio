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
    public class ServicioDesactivarProveedor : IServicioDesactivarProveedor
    {
        public bool DesactivarProveedor(string rut, bool activo)
        {
            bool result = false;

            result = Proveedor.Desactivar(rut, activo);

            return result;
        }
    }
}
