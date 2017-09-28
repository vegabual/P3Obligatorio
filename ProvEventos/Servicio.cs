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
        private List<Tipo_Evento> eventos;
        private bool activo;

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public List<Tipo_Evento> Eventos { get; set; }
        public bool Activo { get; set; }
        
        public virtual bool Insertar(SqlConnection cn, SqlTransaction trn, string rutProv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Proveedor VALUES(@rut,@nombreFantasia,@email,@activo)";
            cmd.Parameters.AddWithValue("@rut", this.Nombre);
            cmd.Parameters.AddWithValue("@nombreFantasia", this.Eventos);
            cmd.Parameters.AddWithValue("@activo", this.Imagen);
            cmd.Parameters.AddWithValue("@email", this.Descripcion);
            cmd.Parameters.AddWithValue("@email", this.Activo);
            cmd.Transaction = trn;
            cmd.Connection = cn;
            int filas = cmd.ExecuteNonQuery();
            //Falta guardar el tipo evento
            foreach (Tipo_Evento e in this.Eventos)
            {
                filas += e.Insertar(cn, trn, rutProv);
            }
            return filas == this.Eventos.Count() + 1;
        }


        public static List<Servicio> FindAll()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT s.nombreservicio, s.descripcion, s.imagen, t.nombreevento, s.activo FROM Servicio as s 
                                INNER JOIN TipoEvento as t ON t.idtipoevento = s.idtipoevento";

            cmd.Connection = cn;
            List<Servicio> listaServicios = null;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listaServicios = new List<Servicio>();
                    while (dr.Read())
                    {
                        Servicio s = CargarDatosDesdeReader(dr);
                        listaServicios.Add(s);
                    }
                }
                return listaServicios;
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

        protected static Servicio CargarDatosDesdeReader(IDataRecord fila)
        {
            Servicio s = null;

            if (fila != null)   
            {
                s = new Servicio
                {
                    Nombre = fila.IsDBNull(fila.GetOrdinal("Nombreservicio")) ? "" : fila.GetString(fila.GetOrdinal("Nombreservicio")),
                    Descripcion = fila.IsDBNull(fila.GetOrdinal("Descripcion")) ? "" : fila.GetString(fila.GetOrdinal("Descripcion")),
                    Imagen = fila.IsDBNull(fila.GetOrdinal("Imagen")) ? "No hay imagen disponible" : fila.GetString(fila.GetOrdinal("Imagen")),
                    //Nombreevento = fila.IsDBNull(fila.GetOrdinal("Nombreevento")) ? "" : fila.GetString(fila.GetOrdinal("Nombreevento")),
                    Activo = (bool)fila["Activo"]
                };
            }
            return s;
        }
    }
}
