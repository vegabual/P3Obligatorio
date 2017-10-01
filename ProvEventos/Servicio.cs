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
        //private List<Tipo_Evento> eventos;
        private bool activo;

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        //public List<Tipo_Evento> Eventos { get; set; }
        public bool Activo { get; set; }
        
        public static List<Servicio> FindAll()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT s.nombreservicio as nombre, s.descripcion, s.imagen,ps.activo
                                FROM Servicio AS s JOIN ProveedorServicio AS ps ON s.idservicio = ps.idservicio";

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

        public static List<Servicio> FindServFile()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT s.nombreservicio, t.nombreevento FROM Servicio AS s 
                                JOIN ServicioTipoEvento AS ste ON s.idservicio = ste.idservicio 
                                JOIN TipoEvento AS t ON ste.idtipoevento = t.idtipoevento";

            cmd.Connection = cn;
            List<Servicio> listaservicios = null;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listaservicios = new List<Servicio>();
                    while (dr.Read())
                    {
                        Servicio s = CargarDatosDesdeReader2(dr);
                        listaservicios.Add(s);
                    }
                }
                return listaservicios;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
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
                    Nombre = fila.IsDBNull(fila.GetOrdinal("Nombre")) ? "" : fila.GetString(fila.GetOrdinal("Nombre")),
                    Descripcion = fila.IsDBNull(fila.GetOrdinal("Descripcion")) ? "" : fila.GetString(fila.GetOrdinal("Descripcion")),
                    Imagen = fila.IsDBNull(fila.GetOrdinal("Imagen")) ? "No hay imagen disponible" : fila.GetString(fila.GetOrdinal("Imagen")),
                    Activo = (bool)fila["Activo"]
                    //Eventos = fila.IsDBNull(fila.GetOrdinal("Nombreevento")) ? "" : fila.GetString(fila.GetOrdinal("Nombreevento")),
                };
            }
            return s;
        }

        protected static Servicio CargarDatosDesdeReader2(IDataRecord fila)
        {
            Servicio s = null;

            if (fila != null)
            {
                s = new Servicio
                {
                    Nombre = fila.IsDBNull(fila.GetOrdinal("Nombreservicio")) ? "" : fila.GetString(fila.GetOrdinal("Nombreservicio")),
                    //Eventos = fila.IsDBNull(fila.GetOrdinal("Nombreevento")) ? "" : fila.GetString(fila.GetOrdinal("Nombreevento")),
                };
            }
            return s;
        }

        public int ObtenerIdServicio()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT idservicio FROM servicio WHERE servicio.nombreservicio = @nombre AND servicio.descripcion = @descripcion AND servicio.imagen = @imagen";
            cmd.Parameters.AddWithValue("@nombre", this.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
            cmd.Parameters.AddWithValue("@imagen", this.Imagen);
            cmd.Connection = cn;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    return dr.IsDBNull(dr.GetOrdinal("idrol")) ? 0 : dr.GetInt32(dr.GetOrdinal("idrol"));
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return 0;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }


        public static Servicio EncuentraServicio(int idServicio)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT idservicio FROM servicio WHERE servicio.idservicio = @id";
            cmd.Parameters.AddWithValue("@id", idServicio);
            cmd.Connection = cn;
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    return CargarDatosDesdeReader(dr);
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public override string ToString()
        {
            return this.Nombre + " - " + this.Descripcion;
        }
    }
}
