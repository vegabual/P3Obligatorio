using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class Tipo_Evento
    {
        private string nombre;
        private string descripcion;

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        Tipo_Evento() { }

        Tipo_Evento(string nombre, string descripcion)
        {
            this.Nombre = Nombre;
            this.Descripcion = descripcion;
        }

        public static Tipo_Evento CargarDatosDesdeReader(IDataRecord fila)
        {
            Tipo_Evento e = null;

            if (fila != null)
            {
                e = new Tipo_Evento
                {
                    Nombre = fila.IsDBNull(fila.GetOrdinal("NombreEvento")) ? "" : fila.GetString(fila.GetOrdinal("NombreEvento")),
                    Descripcion = fila.IsDBNull(fila.GetOrdinal("Descripcion")) ? "" : fila.GetString(fila.GetOrdinal("Descripcion"))
                };
            }
            return e;
        }
    }
}
