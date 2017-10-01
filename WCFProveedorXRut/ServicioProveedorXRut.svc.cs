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
        public Proveedor_Vip FindById(string rut)
        {
            Proveedor_Vip pv = Proveedor_Vip.FindById(rut);
            return pv;
        }
    }
}
