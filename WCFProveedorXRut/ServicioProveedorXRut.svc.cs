using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
<<<<<<< HEAD
using System.Text;
using EntidadesNegocio;

namespace WCFProveedorXRut
{
    public class ServicioProveedorXRut : IServicioProveedorXRut
    {
=======
using System.Text;
using EntidadesNegocio;

namespace WCFProveedorXRut
{
    public class ServicioProveedorXRut : IServicioProveedorXRut
    {
>>>>>>> 5cd4113433b66b0ca4c5cf4d3303ce21c5198061
        public Proveedor_Vip FindById(string rut)
        {
            Proveedor_Vip pv = Proveedor_Vip.FindById(rut);
            return pv;
<<<<<<< HEAD
        }
    }
}
=======
        }
    }
}
>>>>>>> 5cd4113433b66b0ca4c5cf4d3303ce21c5198061
