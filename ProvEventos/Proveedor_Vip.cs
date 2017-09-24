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
        public static double porcentajeNuevoVip = 15;
        private double porcentaje;

        public double Porcentaje { get; set; }

        public Proveedor_Vip(string rut, string nombreFantasia, string email, string telefono, string nombreservicio)
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
            SqlConnection cn = Conexion.CrearConexion();
            SqlTransaction trn = null;
            if (!this.Validar()) return false;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO ProveedorVIP VALUES(@rut,@porcentaje)";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@rut", this.Rut));
            cmd.Parameters.Add(new SqlParameter("@porcentaje", porcentajeNuevoVip));
            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Connection = cn;
                cmd.Transaction = trn;
                if (base.Insertar(cn, trn))
                {
                    int filas = cmd.ExecuteNonQuery();
                    if (filas == 1)
                    {
                        trn.Commit();
                    }
                    else
                    {
                        System.Diagnostics.Debug.Assert(false, "Cantidad de filas modificadas incorrecta");
                        trn.Rollback();
                    }
                    return filas == 1;
                }
                else
                {
                    System.Diagnostics.Debug.Assert(false, "Cantidad de filas modificadas en metodo base incorrecta");
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

        public static bool Modificar(double porcentaje)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE ProveedorVIP SET porcentaje = @porcentaje FROM ProveedorVIP";
            cmd.Parameters.AddWithValue("@porcentaje", porcentaje);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                int filas = cmd.ExecuteNonQuery();

                return filas >= 2;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }
    }
}
