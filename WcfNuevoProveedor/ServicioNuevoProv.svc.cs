using EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace WcfNuevoProveedor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicioNuevoProv : IServicioNuevoProv
    {
        public bool NuevoProveedor(string rut, string clave, string nombre, string email, string telefono, bool vip)
        {
            bool result = false;
            int i;
            //La clave debe tener entre 8 y 15 caracteres, tener al menos un numero, una letra minuscula y una letra mayuscula
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regexEmail.IsMatch(email) && int.TryParse(telefono,out i) && Usuario.ValidarClave(clave))
            {
                Usuario usu = new Usuario(rut, Usuario.EncryptPassword(clave), Rol.Proveedor);
                Proveedor prov = null;
                if (vip)
                {
                    prov = new Proveedor_Vip(rut, nombre, email, telefono, null);
                }
                else
                {
                    prov = new Proveedor_Comun(rut, nombre, email, telefono, null);
                }
                result = usu.Insertar() && prov.Insertar();
            }
            return result;
        }
    }
}
