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

        public IEnumerable<DTOProveedor> GetProveedor()
        {
            IEnumerable<Proveedor> lista = Proveedor.FindAll();
            List<DTOProveedor> listaprov = new List<DTOProveedor>();
            if (lista != null)
            {
                foreach (Proveedor p in lista)
                {
                    listaprov.Add(new WCFDesactivarProveedor.DTOProveedor{ Rut = p.Rut, Activo = p.Activo});
                }
            }
            return listaprov;   
        }
    }
}
