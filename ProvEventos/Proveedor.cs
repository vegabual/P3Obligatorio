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
        private string rut;
        private string nombreFantasia;
        private string email;
        private string telefono;
        private bool activo;
        private List<Servicio> nombreservicio;

        public string Rut { get; set; }
        public string NombreFantasia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public List<Servicio> Servicios { get; set; }

        public Proveedor(string rut, string nombreFantasia, string email, string telefono, List<Servicio> servicios)
        {
            this.Rut = rut;
            this.Email = email;
            this.NombreFantasia = nombreFantasia;
            this.Telefono = telefono;
            this.Activo = true;
            this.Servicios = servicios;
        }

        public Proveedor() { }

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
            foreach (Servicio s in this.Servicios)
            {
                int idServicio = s.ObtenerIdServicio();
                cmd.CommandText = @"INSERT INTO ProveedorServicio VALUES(@rut,@idservicio)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@rut", this.Rut));
                cmd.Parameters.Add(new SqlParameter("@idservicio", idServicio));
                filas += cmd.ExecuteNonQuery();
            }
            return filas == Servicios.Count() + 2;
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

                return filas >= 2;
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

                return filas >= 2;
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
            cmd.CommandText = @"";
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
            cmd.CommandText = @"SELECT p.rut, p.nombrefantasia, p.email, tp.telefono, 
                                CASE CAST(p.activo AS VARCHAR(10)) WHEN '1' THEN 'Si' WHEN '0' THEN 'No' END AS activo, s.nombreservicio 
                                FROM Proveedor AS p JOIN TelefonoProveedor AS tp ON p.rut = tp.rut JOIN Servicio AS s ON p.rut = s.rut";

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
                //p = new Proveedor_Vip
                //{
                //    Rut = fila.IsDBNull(fila.GetOrdinal("Rut")) ? "" : fila.GetString(fila.GetOrdinal("Rut")),
                //    NombreFantasia = fila.IsDBNull(fila.GetOrdinal("NombreFantasia")) ? "" : fila.GetString(fila.GetOrdinal("NombreFantasia")),
                //    Email = fila.IsDBNull(fila.GetOrdinal("Email")) ? "" : fila.GetString(fila.GetOrdinal("Email")),
                //    Telefono = fila.IsDBNull(fila.GetOrdinal("Telefono")) ? "" : fila.GetString(fila.GetOrdinal("Telefono")),
                //    //Activo = (bool)fila["Activo"],
                //    Nombreservicio = fila.IsDBNull(fila.GetOrdinal("Nombreservicio")) ? "" : fila.GetString(fila.GetOrdinal("Nombreservicio"))
                //};
            }
            return p;
        }
    }
}
