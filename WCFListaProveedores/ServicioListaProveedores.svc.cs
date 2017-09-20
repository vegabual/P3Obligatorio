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
    public class ServicioListaProveedores : IServicioListaProveedores
    {
        public int ListarProveedores()
        {
            IEnumerable<Proveedor> lista = Proveedor.FindAll();
            return lista == null ? 0 : lista.Count();
        }
    }
}

