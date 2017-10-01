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

        public static new Proveedor_Comun CargarDatosDesdeReader(IDataRecord fila)
        {
            Proveedor_Comun pv = null;

            if (fila != null)
            {
                string pvRut = fila.IsDBNull(fila.GetOrdinal("Rut")) ? "" : fila.GetString(fila.GetOrdinal("Rut"));
                pv = new Proveedor_Comun
                {
                    Rut = fila.IsDBNull(fila.GetOrdinal("Rut")) ? "" : fila.GetString(fila.GetOrdinal("Rut")),
                    NombreFantasia = fila.IsDBNull(fila.GetOrdinal("NombreFantasia")) ? "" : fila.GetString(fila.GetOrdinal("NombreFantasia")),
                    Email = fila.IsDBNull(fila.GetOrdinal("Email")) ? "" : fila.GetString(fila.GetOrdinal("Email")),
                    Telefono = fila.IsDBNull(fila.GetOrdinal("Telefono")) ? "" : fila.GetString(fila.GetOrdinal("Telefono")),
                    Activo = (bool)fila["Activo"],
                    Servicios = CargarServicios(pvRut)
                };
            }
            return pv;
        }
    }
}
