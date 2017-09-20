using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public bool Validar()
        {
            Regex regexPass = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
            return (regexPass.IsMatch(this.Clave));
        }
        
        public bool Insertar()
        {
            if (!this.Validar() || UsuExists(this.NombreUsuario)) return false;

            SqlConnection cn = Conexion.CrearConexion();
            SqlTransaction trn = null;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Usuario VALUES(@nombreUsuario,@clave,@fechaReg)";
            cmd.Parameters.AddWithValue("@nombreUsuario", this.NombreUsuario);
            cmd.Parameters.AddWithValue("@clave", this.Clave);
            cmd.Parameters.AddWithValue("@fechaReg", this.FechaRegistro);
            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Connection = cn;
                cmd.Transaction = trn;
                int filas = cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO Rol VALUES(@nombreUsuario,@rol)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", this.NombreUsuario));
                cmd.Parameters.Add(new SqlParameter("@rol", this.Rol));

                filas += cmd.ExecuteNonQuery();

                if (filas == 2)
                {
                    trn.Commit();
                }
                else
                {
                    trn.Rollback();
                }
                return filas == 2;
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
    }
}
