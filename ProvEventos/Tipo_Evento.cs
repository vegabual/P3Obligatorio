using System;
using System.Collections.Generic;
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

        Tipo_Evento(string nombre, string descripcion)
        {
            this.Nombre = Nombre;
            this.Descripcion = descripcion;
        }
    }
}
