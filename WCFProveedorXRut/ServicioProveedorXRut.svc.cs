using System.Text;
using EntidadesNegocio;

namespace WCFProveedorXRut
{
    public class ServicioProveedorXRut : IServicioProveedorXRut
    {
        public DTOProveedor FindById(string rut)
        {
            Proveedor p = Proveedor.FindById(rut);
            DTOProveedor elem = null;
            if (p.GetType() == typeof(Proveedor_Comun))
            {
                elem = new DTOProveedor
                {
                    Rut = p.Rut,
                    NombreFantasia = p.NombreFantasia,
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
                    NombreFantasia = p.NombreFantasia,
                    Telefono = p.Telefono,
                    Email = p.Email,
                    Activo = p.Activo,
                    Porcentaje = pv.Porcentaje,
                    Servicios = p.Servicios
                };
            }
            return elem;
        }
    }
}