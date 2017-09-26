using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using System.Diagnostics;

namespace EntidadesNegocio
{
    public class Proveedor_Comun : Proveedor
    {
        public Proveedor_Comun(string rut, string nombreFantasia, string email, string telefono, List<Servicio> servicios)
        {
            this.Activo = true;
            this.Rut = rut;
            this.Email = email;
            this.NombreFantasia = nombreFantasia;
            this.Telefono = telefono;
            this.Servicios = servicios;
        }

        public Proveedor_Comun() { }
    }
}
