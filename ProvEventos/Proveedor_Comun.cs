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
    public class Proveedor_Comun : Proveedor
    {
        public Proveedor_Comun(string rut, string nombreFantasia, string email, string telefono, List<Servicio> servicios)
        {
            this.Activo = true;
            this.Rut = rut;
            this.Email = email;
            this.NombreFantasia = nombreFantasia;
            this.Telefono = telefono;
            this.Servicios = servicios;
        }

        public Proveedor_Comun() { }


        public static List<Proveedor_Comun> FindProvFile()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT p.rut, p.nombrefantasia, p.email, telefono FROM Proveedor AS	p JOIN TelefonoProveedor AS tp ON p.rut = tp.rut";

            cmd.Connection = cn;
            List<Proveedor_Comun> listaproveedores = null;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listaproveedores = new List<Proveedor_Comun>();
                    while (dr.Read())
                    {
                        Proveedor_Comun pv = CargarDatosDesdeReader(dr);
                        listaproveedores.Add(pv);
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

        public static List<Proveedor_Comun> FindAll()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT p.rut, p.nombrefantasia, p.email, tp.telefono, p.activo ,s.nombreservicio
                                FROM Proveedor AS p JOIN TelefonoProveedor AS tp ON p.rut = tp.rut 
                                JOIN ProveedorServicio AS ps ON p.rut = ps.rut JOIN Servicio AS s ON ps.idservicio = s.idservicio";
            cmd.Connection = cn;

            List<Proveedor_Comun> listaproveedores = null;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listaproveedores = new List<Proveedor_Comun>();
                    while (dr.Read())
                    {
                        Proveedor_Comun p = CargarDatosDesdeReader(dr);
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

        protected static new Proveedor_Comun CargarDatosDesdeReader(IDataRecord fila)
        {
            Proveedor_Comun pv = null;

            if (fila != null)
            {
                pv = new Proveedor_Comun
                {
                    Rut = fila.IsDBNull(fila.GetOrdinal("Rut")) ? "" : fila.GetString(fila.GetOrdinal("Rut")),
                    NombreFantasia = fila.IsDBNull(fila.GetOrdinal("NombreFantasia")) ? "" : fila.GetString(fila.GetOrdinal("NombreFantasia")),
                    Email = fila.IsDBNull(fila.GetOrdinal("Email")) ? "" : fila.GetString(fila.GetOrdinal("Email")),
                    Telefono = fila.IsDBNull(fila.GetOrdinal("Telefono")) ? "" : fila.GetString(fila.GetOrdinal("Telefono")),
                    Activo = (bool)fila["Activo"],
                    Servicios = CargarServicios(pv)
                };
            }
            return pv;
        }

        protected static List<Servicio> CargarServicios(Proveedor_Comun pv)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT s.nombreservicio FROM ProveedorServicio AS ps JOIN Servicio AS s ON ps.idservicio = s.idservicio";
            cmd.Connection = cn;
            List<Servicio> listaservicios = null;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Servicio s = new Servicio();
                    listaservicios = new List<Servicio>();
                    while (dr.Read())
                    {
                        s = ReadSingleRow((IDataRecord)dr,s);
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

        private static Servicio ReadSingleRow(IDataRecord dr, Servicio s)
        {
            s.Nombre = String.Format("{0}",dr[0]);
            return s;
        }
    }
}
