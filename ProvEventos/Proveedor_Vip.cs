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
    public class Proveedor_Vip : Proveedor, IActiveRecord
    {
        public static double porcentajeNuevoVip;
        private double porcentaje;

        public double Porcentaje { get; set; }

        public Proveedor_Vip(string rut, string nombreFantasia, string email, string telefono, bool activo, string nombreservicio)
        {
            this.Rut = rut;
            this.Email = email;
            this.NombreFantasia = nombreFantasia;
            this.Porcentaje = porcentajeNuevoVip;
            this.Telefono = telefono;
            this.Activo = true;
            this.Nombreservicio = nombreservicio;
        }
        
        public override bool Insertar()
        {
            if (!base.Insertar() || !this.Validar()) return false;

            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO ProveedorVIP VALUES(@rut,@porcentaje)";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@rut", this.Rut));
            cmd.Parameters.Add(new SqlParameter("@porcentaje", porcentajeNuevoVip));
            cmd.Connection = cn;
            try
            {
                Conexion.AbrirConexion(cn);
                int filas = cmd.ExecuteNonQuery();

                return filas == 1;
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
