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
        public List<DTOProveedor> ListarProveedores()
        {
            List<Proveedor> lista = Proveedor.FindAll();
            List<DTOProveedor> ret = new List<DTOProveedor>();
            foreach (Proveedor p in lista)
            {
                DTOProveedor elem = null;
                if (p.GetType() == typeof(Proveedor_Comun))
                {
                    elem = new DTOProveedor
                    {
                        Rut = p.Rut,
                        Nombre = p.NombreFantasia,
                        Telefono = p.Telefono,
                        Email = p.Email,
                        Activo = p.Activo,
                        Porcentaje = 0,
                        Servicios = p.Servicios
                    };
                }
                else
                {
                    Proveedor_Vip pv = p as Proveedor_Vip;
                    elem = new DTOProveedor
                    {
                        Rut = p.Rut,
                        Nombre = p.NombreFantasia,
                        Telefono = p.Telefono,
                        Email = p.Email,
                        Activo = p.Activo,
                        Porcentaje = pv.Porcentaje,
                        Servicios = p.Servicios
                    };
                }
                ret.Add(elem);
            }
            return ret;
        }
    }
}

