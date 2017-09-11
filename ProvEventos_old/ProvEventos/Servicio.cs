using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class Servicio
    {
        private string nombre;
        private string descripcion;
        private string imagen;
        private List<Tipo_Evento> tipos_evento;

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Tipo_Evento> Tipos_evento { get; set; }
        public string Imagen { get; set; }

        Servicio(string nombre, string description, string imagen, List<Tipo_Evento> tipos_evento)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Tipos_evento = tipos_evento;
        }
    }
}
