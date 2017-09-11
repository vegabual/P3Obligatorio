using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class Proveedor_Comun : Proveedor
    {
        public Proveedor_Comun(string rut, string nombreFantasia, string email, string telefono, List<Servicio> servicios)
        {
            this.Activo = true;
            this.Rut = rut;
            this.NombreFantasia = nombreFantasia;
            this.Telefono = telefono;
            this.Servicios = servicios;
        }
    }
}
