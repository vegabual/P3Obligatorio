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
        private double porcentaje;

        public double Porcentaje { get; set; }

        public Proveedor_Vip(string rut, string nombreFantasia, string email, string telefono, List<Servicio> servicios)
        {
            this.Rut = rut;
            this.Email = email;
            this.NombreFantasia = nombreFantasia;
            this.Telefono = telefono;
            this.Activo = true;
            this.Servicios = servicios;
        }

        public Proveedor_Vip() { }
        
        public override bool Insertar()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlTransaction trn = null;
            if (!this.Validar()) return false;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO ProveedorVIP VALUES(@rut,(SELECT valor FROM Parametro WHERE nombre='porcentaje'))";
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
            cmd.CommandText = @"UPDATE Parametro SET valor = @porcentaje FROM Parametro where nombre = 'porcentaje'";
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

        public static new Proveedor_Vip CargarDatosDesdeReader(IDataRecord fila)
        {
            Proveedor_Vip pv = null;

            if (fila != null)
            {
                string pvRut = fila.IsDBNull(fila.GetOrdinal("Rut")) ? "" : fila.GetString(fila.GetOrdinal("Rut"));
                pv = new Proveedor_Vip
                {
                    Rut = fila.IsDBNull(fila.GetOrdinal("Rut")) ? "" : fila.GetString(fila.GetOrdinal("Rut")),
                    NombreFantasia = fila.IsDBNull(fila.GetOrdinal("NombreFantasia")) ? "" : fila.GetString(fila.GetOrdinal("NombreFantasia")),
                    Email = fila.IsDBNull(fila.GetOrdinal("Email")) ? "" : fila.GetString(fila.GetOrdinal("Email")),
                    Telefono = fila.IsDBNull(fila.GetOrdinal("Telefono")) ? "" : fila.GetString(fila.GetOrdinal("Telefono")),
                    Activo = (bool)fila["Activo"],
                    Servicios = CargarServicios(pvRut),
                    Porcentaje = fila.IsDBNull(fila.GetOrdinal("Porcentaje")) ? 0 : (double)fila.GetDecimal(fila.GetOrdinal("Porcentaje"))
                };
            }
            return pv;
        }
    }
}
