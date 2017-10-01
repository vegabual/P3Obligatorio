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
        public DTOProveedor FindById(string rut)
        {
            Proveedor prov = Proveedor.FindById(rut);
            DTOProveedor dtoProv = null;
            if (prov.GetType() == typeof(Proveedor_Comun))
            {
                dtoProv = new DTOProveedor
                {
                    Rut = prov.Rut,
                    NombreFantasia = prov.NombreFantasia,
                    Telefono = prov.Telefono,
                    Email = prov.Email,
                    Activo = prov.Activo,
                    Porcentaje = 0,
                    Servicios = prov.Servicios
                };
            }
            else
            {
                Proveedor_Vip provVip = prov as Proveedor_Vip;
                dtoProv = new DTOProveedor
                {
                    Rut = prov.Rut,
                    NombreFantasia = prov.NombreFantasia,
                    Telefono = prov.Telefono,
                    Email = prov.Email,
                    Activo = prov.Activo,
                    Porcentaje = provVip.Porcentaje,
                    Servicios = prov.Servicios
                };
            }
            return dtoProv;
        }
    }
}
