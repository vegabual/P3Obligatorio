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
    public abstract class Proveedor
    {
        public static double arancel;
        private string rut;
        private string nombreFantasia;
        private string email;
        private string telefono;
        private bool activo;
        private List<Servicio> servicios;


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
            return (int.TryParse(rut, out i) && regexEmail.IsMatch(email) && int.TryParse(telefono, out i));
        }


        public virtual bool Insertar()
        {
            if (!this.Validar()) return false;

            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Proveedor
                                VALUES(@rut,@nombreFantasia,@email,@activo)";
            cmd.Parameters.AddWithValue("@rut", this.Rut);
            cmd.Parameters.AddWithValue("@nombreFantasia", this.NombreFantasia);
            cmd.Parameters.AddWithValue("@activo", this.Activo);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Connection = cn;
            try
            {
                Conexion.AbrirConexion(cn);
                int filas = cmd.ExecuteNonQuery();
                //Falta guardar en la tabla telefono
                //Usamos el mismo objeto para la conexión y para el comando.
                //Al comando le cambiamos la cadena de inserción y los parámetros
                cmd.CommandText = @"INSERT INTO TelefonoProveedor VALUES(@rut,@telefono)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@rut", this.Rut));
                cmd.Parameters.Add(new SqlParameter("@telefono", this.Telefono));

                filas += cmd.ExecuteNonQuery();

                return filas == 2;
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
