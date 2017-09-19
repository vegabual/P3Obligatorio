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

        protected static Servicio CargarDatosDesdeReader(IDataRecord fila)
        {
            Servicio s = null;
            List<Tipo_Evento> lista = new List<Tipo_Evento>();

            if (fila != null)
            {
            //    s = new Servicio
            //    {
            //        Nombre = fila.IsDBNull(fila.GetOrdinal("Nombre")) ? "" : fila.GetString(fila.GetOrdinal("Nombre")),
            //        Descripcion = fila.IsDBNull(fila.GetOrdinal("Descripcion")) ? "" : fila.GetString(fila.GetOrdinal("Descripcion")),
            //        Imagen = fila.IsDBNull(fila.GetOrdinal("Imagen")) ? "" : fila.GetString(fila.GetOrdinal("Imagen")),
            //        //Tipos_evento = fila.IsDBNull(fila.GetOrdinal("Tipos_evento")) ? "" : fila.GetString(fila.GetOrdinal("Tipos_evento"))
                    
            //}; 
            }
            return s;
        }

        public static List<Servicio> FindAll()
        {
            string consulta = @"SELECT s.idservicio, s.nombre, s.descripcion, e.idtipoevento, e.nombre FROM	Servicio AS s INNER JOIN TipoEvento	AS e ON s.idtipoevento = e.idtipoevento";

            SqlConnection cn = Conexion.CrearConexion();

            List<Servicio> listaservicios = new List<Servicio>();

            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Servicio s = CargarDatosDesdeReader(dr);
                    listaservicios.Add(s);
                }
                dr.Close();
                return listaservicios;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }
    }
}
