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
        //private bool activo;

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public List<Tipo_Evento> Eventos { get; set; }
        //public bool Activo { get; set; }
        
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
                        Servicio s = CargarDatosDesdeReader(dr);
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

        public static Servicio CargarDatosDesdeReader(IDataRecord fila)
        {
            Servicio s = null;

            if (fila != null)   
            {
                int id = fila.IsDBNull(fila.GetOrdinal("idservicio")) ? -1 : fila.GetInt32(fila.GetOrdinal("idservicio"));
                s = new Servicio
                {
                    Nombre = fila.IsDBNull(fila.GetOrdinal("NombreServicio")) ? "" : fila.GetString(fila.GetOrdinal("NombreServicio")),
                    Descripcion = fila.IsDBNull(fila.GetOrdinal("Descripcion")) ? "" : fila.GetString(fila.GetOrdinal("Descripcion")),
                    Imagen = fila.IsDBNull(fila.GetOrdinal("Imagen")) ? "No hay imagen disponible" : fila.GetString(fila.GetOrdinal("Imagen")),
                    Eventos = CargarEventos(id)
                };
            }
            return s;
        }

        protected static List<Tipo_Evento> CargarEventos(int idSv)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT DISTINCT e.* FROM ServicioTipoEvento AS st JOIN TipoEvento AS e ON st.idtipoevento = e.idtipoevento where st.idservicio = @idServicio";
            cmd.Parameters.AddWithValue("@idServicio", idSv);
            cmd.Connection = cn;
            List<Tipo_Evento> listaTipoEvento = null;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listaTipoEvento = new List<Tipo_Evento>();
                    while (dr.Read())
                    {
                        Tipo_Evento e = Tipo_Evento.CargarDatosDesdeReader(dr);
                        listaTipoEvento.Add(e);
                    }
                }
                return listaTipoEvento;
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

        public int ObtenerIdServicio()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            if (this.Imagen == "No hay imagen disponible")
            {
                cmd.CommandText = @"SELECT idservicio FROM servicio WHERE servicio.nombreservicio = @nombre AND servicio.descripcion = @descripcion AND servicio.imagen is null";
            }
            else
            {
                cmd.CommandText = @"SELECT idservicio FROM servicio WHERE servicio.nombreservicio = @nombre AND servicio.descripcion = @descripcion AND servicio.imagen = @imagen";
                cmd.Parameters.AddWithValue("@imagen", this.Imagen);
            }
            cmd.Parameters.AddWithValue("@nombre", this.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
            cmd.Connection = cn;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    return dr.IsDBNull(dr.GetOrdinal("idservicio")) ? 0 : dr.GetInt32(dr.GetOrdinal("idservicio"));
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
            cmd.CommandText = @"SELECT servicio.* FROM servicio WHERE servicio.idservicio = @id";
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
