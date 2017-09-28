using EntidadesNegocio;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace WcfNuevoProveedor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicioNuevoProv : IServicioNuevoProv
    {
        public bool NuevoProveedor(string rut, string clave, string nombre, string email, string telefono, bool vip, List<DTOServicio> dtoServicios)
        {
            bool result = false;
            int i;
            //La clave debe tener entre 8 y 15 caracteres, tener al menos un numero, una letra minuscula y una letra mayuscula
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regexEmail.IsMatch(email) && int.TryParse(telefono,out i) && Usuario.ValidarClave(clave))
            {
                Usuario usu = new Usuario(rut, Usuario.HashPassword(clave), Rol.Proveedor);
                List<Servicio> servicios = new List<Servicio>();
                bool serviciosExisten = true;
                i = 0;
                int end = dtoServicios.Count - 1;
                while (i < end && serviciosExisten)
                {
                    DTOServicio dtoS = dtoServicios[i];
                    Servicio s = Servicio.EncuentraServicio(dtoS.IdServicio);
                    if (s != null)
                    {
                        servicios.Add(s);
                        i++;
                    }
                    else
                    {
                        serviciosExisten = false;
                    }
                }
                Proveedor prov = null;
                if (vip)
                {
                    prov = new Proveedor_Vip(rut, nombre, email, telefono, servicios);
                }
                else
                {
                    prov = new Proveedor_Comun(rut, nombre, email, telefono, servicios);
                }
                result = serviciosExisten && usu.Insertar() && prov.Insertar();
            }
            return result;
        }
    }
}
