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

        public Proveedor_Vip(string rut, string nombreFantasia, string email, string telefono, List<Servicio> servicios)
        {
            this.Rut = rut;
            this.Email = email;
            this.NombreFantasia = nombreFantasia;
            this.Porcentaje = porcentajeNuevoVip;
            this.Telefono = telefono;
            this.Activo = true;
            this.Servicios = servicios;
        }

        public Proveedor_Vip() { }

        public void ConfigurarPorcentajeNuevoProv()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            try
            {
                Conexion.AbrirConexion(cn);
                cmd.CommandText = @"SELECT valor FROM Parametros WHERE nombre='porcentaje'";
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    porcentajeNuevoVip = dr.IsDBNull(dr.GetOrdinal("valor")) ? 0 : dr.GetDouble(dr.GetOrdinal("valor"));
                }
            }
            catch { }
        }

        public override bool Insertar()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlTransaction trn = null;
            if (!this.Validar()) return false;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO ProveedorVIP VALUES(@rut,(SELECT valor FROM Parametros WHERE nombre='porcentaje'))";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@rut", this.Rut));
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

        public static bool ModificarPorcentaje(double porcentaje)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"UPDATE Parametros SET valor = @porcentaje FROM Parametros where nombre = 'porcentaje'";
            cmd.Parameters.AddWithValue("@porcentaje", porcentaje);
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
    }
}
