using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class Usuario
    {
        private string nombreUsuario;
        private string clave;
        private DateTime fechaRegistro;
        private Rol rol;

        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public DateTime FechaRegistro { get; }
        public Rol Rol { get; set; }

        public Usuario(string nombreUsuario, string clave, Rol rol)
        {
            this.fechaRegistro = DateTime.Today;
            this.NombreUsuario = nombreUsuario;
            this.Clave = clave;
            this.Rol = rol;
            this.FechaRegistro = DateTime.Today;
        }

        public Usuario() { }

        public static bool ValidarClave(string pass)
        {
            Regex regexPass = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
            return (regexPass.IsMatch(pass));
        }
        
        public int ObtenerRolId(Rol rol)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            string rolstr = rol.ToString();
            cmd.CommandText = @"SELECT * FROM Rol WHERE rol = @rol";
            cmd.Parameters.AddWithValue("@rol", rolstr);
            cmd.Connection = cn;
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    int id = dr.IsDBNull(dr.GetOrdinal("idrol")) ? 0 : dr.GetInt32(dr.GetOrdinal("idrol"));
                    return id;
                }
                else
                {
                    dr.Close();
                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.CommandText = @"Insert into Rol (rol) output inserted.idrol values (@rol)";
                    cmdInsert.Parameters.AddWithValue("@rol", rolstr);
                    cmdInsert.Connection = cn;
                    
                    SqlDataReader dr2 = cmdInsert.ExecuteReader();
                    long id = 0;
                    if (dr2.Read())
                    {
                        id = dr2.IsDBNull(dr2.GetOrdinal("idrol")) ? 0 : dr2.GetInt32(dr2.GetOrdinal("idrol"));
                    }
                    return (int)id;
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

        public bool Insertar()
        {
            if (UsuExists(this.NombreUsuario)) return false;

            SqlConnection cn = Conexion.CrearConexion();
            SqlTransaction trn = null;
            SqlCommand cmd = new SqlCommand();
            int idrol = ObtenerRolId(this.Rol);
            cmd.CommandText = @"INSERT INTO Usuario VALUES(@nombreUsuario,@clave,@idrol,@fechaReg)";
            cmd.Parameters.AddWithValue("@nombreUsuario", this.NombreUsuario);
            cmd.Parameters.AddWithValue("@clave", this.Clave);
            cmd.Parameters.AddWithValue("@idrol", idrol);
            cmd.Parameters.AddWithValue("@fechaReg", this.FechaRegistro);
            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Connection = cn;
                cmd.Transaction = trn;
                int filas = cmd.ExecuteNonQuery();

                if (filas == 1)
                {
                    trn.Commit();
                }
                else
                {
                    trn.Rollback();
                }
                return filas == 1;
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

        public static bool UsuExists(string username)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM Usuario WHERE usuario.nombreusuario = @usu";
            cmd.Parameters.AddWithValue("@usu", username);

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

        public static string EncryptPassword(string password)
        {
            //byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            //data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            //String hash = System.Text.Encoding.ASCII.GetString(data);
            //return hash;
            UnicodeEncoding uEncode = new UnicodeEncoding();
            byte[] bytPassword = uEncode.GetBytes(password);
            SHA512Managed sha = new SHA512Managed();
            byte[] hash = sha.ComputeHash(bytPassword);
            return Convert.ToBase64String(hash);
        }
    }
}
