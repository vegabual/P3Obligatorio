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
    public class ServicioProveedorXRut : IServicioProveedorXRut
    {
        public Proveedor FindById(string rut)
        {
            Proveedor p = Proveedor.FindById(rut);
            return p;
        }
    }
}
