using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace EntidadesNegocio
{
    public abstract class Proveedor
    {
        private static double arancel;
        private string rut;
        private string nombreFantasia;
        private string email;
        private string telefono;
        private bool activo;
        private List<Servicio> servicios;

        public static double Arancel;
        public string Rut { get; set; }
        public string NombreFantasia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public List<Servicio> Servicios { get; set; }
        
        public bool Validar()
        {
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            int i;
            return (regexEmail.IsMatch(this.Email) && int.TryParse(this.Telefono, out i));
        }
        
        public virtual bool Insertar()
        {
            SqlConnection cn = Conexion.CrearConexion();
            if (!this.Validar()) return false;
            SqlTransaction trn = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                if (this.Insertar(cn, trn))
                {
                    trn.Commit();
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.Assert(false, "Cantidad de filas modificadas incorrecta");
                    trn.Rollback();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public virtual bool Insertar(SqlConnection cn, SqlTransaction trn)
        {
            if (!this.Validar() || Exists(this.Rut)) return false;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Proveedor VALUES(@rut,@nombreFantasia,@email,@activo)";
            cmd.Parameters.AddWithValue("@rut", this.Rut);
            cmd.Parameters.AddWithValue("@nombreFantasia", this.NombreFantasia);
            cmd.Parameters.AddWithValue("@activo", this.Activo);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Transaction = trn;
            cmd.Connection = cn;
            int filas = cmd.ExecuteNonQuery();

            //Falta guardar en la tabla telefono
            //Usamos el mismo objeto para la conexión y para el comando.
            //Al comando le cambiamos la cadena de inserción y los parámetros
            cmd.CommandText = @"INSERT INTO TelefonoProveedor VALUES(@rut,@telefono)";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@rut", this.Rut));
            cmd.Parameters.Add(new SqlParameter("@telefono", this.Telefono));

            filas += cmd.ExecuteNonQuery();
            //Falta guardar en la tabla relacional de servicio y proveedor
            if (this.Servicios != null)
            {
                foreach (Servicio s in this.Servicios)
                {
                    int idServicio = s.ObtenerIdServicio();
                    if (idServicio != -1)
                    {
                        cmd.CommandText = @"INSERT INTO ProveedorServicio VALUES(@rut,@idservicio,@activo)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@rut", this.Rut));
                        cmd.Parameters.Add(new SqlParameter("@idservicio", idServicio));
                        cmd.Parameters.Add(new SqlParameter("@activo", true));
                        filas += cmd.ExecuteNonQuery();
                    }
                }
            }
            int cantServicios = this.Servicios == null ? 0 : this.Servicios.Count();
            return filas == cantServicios + 2;
        }
        
        public static bool Exists(string rut)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM Proveedor WHERE rut = @rut";
            cmd.Parameters.AddWithValue("@rut", rut);

            cmd.Connection = cn;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public static bool ModificarArancel(double arancel)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"UPDATE Parametro SET valor = @arancel FROM Parametro where nombre = 'arancel'";
            cmd.Parameters.AddWithValue("@arancel", arancel);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                int filas = cmd.ExecuteNonQuery();
                trn.Commit();

                return filas >= 1;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                trn.Rollback();
                return true;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public static bool Desactivar(string rut, bool activo)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"UPDATE Proveedor SET activo = @activo FROM Proveedor WHERE rut = @rut
                                UPDATE ProveedorServicio  SET activo = @activo FROM ProveedorServicio WHERE rut = @rut";
            cmd.Parameters.AddWithValue("@rut", rut);
            cmd.Parameters.AddWithValue("@activo", activo);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                int filas = cmd.ExecuteNonQuery();
                trn.Commit();

                return filas >= 1;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public static Proveedor FindById(string rut)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT p.*, tp.telefono, pv.porcentaje FROM Proveedor AS p JOIN TelefonoProveedor AS tp ON p.rut = tp.rut 
                                FULL JOIN ProveedorVip AS pv ON p.rut = pv.rut WHERE p.rut = @rut";
            cmd.Parameters.AddWithValue("@rut", rut);
            cmd.Connection = cn;
            try
            {
                cn.Open();
                Proveedor p = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = CargarDatosDesdeReader(dr);
                }
                return p;
            }
            catch (SqlException ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public static List<Proveedor> FindAll()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT p.*, tp.telefono, pv.porcentaje FROM Proveedor AS p JOIN TelefonoProveedor AS tp ON p.rut = tp.rut 
                                FULL JOIN ProveedorVip AS pv ON p.rut = pv.rut";
            cmd.Connection = cn;

            List<Proveedor> listaproveedores = null;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listaproveedores = new List<Proveedor>();
                    while (dr.Read())
                    {
                        Proveedor p = CargarDatosDesdeReader(dr);
                        listaproveedores.Add(p);
                    }
                }
                return listaproveedores;
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

        protected static Proveedor CargarDatosDesdeReader(IDataRecord fila)
        {
            Proveedor p = null;

            if (fila != null)
            {
                if (fila.IsDBNull(fila.GetOrdinal("porcentaje")))
                {
                    p = Proveedor_Comun.CargarDatosDesdeReader(fila);
                }
                else
                {
                    p = Proveedor_Vip.CargarDatosDesdeReader(fila);
                }
            }
            return p;
        }
        
        protected static List<Servicio> CargarServicios(string idPv)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT s.* FROM ProveedorServicio AS ps JOIN Servicio AS s ON ps.idservicio = s.idservicio where ps.rut = @rut";
            cmd.Parameters.AddWithValue("@rut", idPv);
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
                        Servicio s = Servicio.CargarDatosDesdeReader(dr);
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

        public override string ToString()
        {
            string strServicio = "";
            foreach (Servicio s in this.Servicios)
            {
                strServicio += "#" + s.ToString();
            } 
            return this.Rut + "#" + this.NombreFantasia + "#" + this.Email + "#" + this.Telefono + strServicio;
        }
    }
}
