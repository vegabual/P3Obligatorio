﻿using System;
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
    public class Servicio
    {
        private string nombre;
        private string descripcion;
        private string imagen;
        private string nombreevento;

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Nombreevento { get; set; }
        public string Imagen { get; set; }


        public static List<Servicio> FindAll()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT nombre, descripcion, imagen, idtipoevento FROM Servicio";

            cmd.Connection = cn;
            List<Servicio> listaServicios = null;
            try
            {
                Conexion.AbrirConexion(cn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listaServicios = new List<Servicio>();
                    while (dr.Read())
                    {
                        Servicio s = CargarDatosDesdeReader(dr);
                        listaServicios.Add(s);
                    }
                }
                return listaServicios;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        protected static Servicio CargarDatosDesdeReader(IDataRecord fila)
        {
            Servicio s = null;

            if (fila != null)
            {
                s = new Servicio
                {
                    Nombre = fila.IsDBNull(fila.GetOrdinal("Nombre")) ? "" : fila.GetString(fila.GetOrdinal("Nombre")),
                    Descripcion = fila.IsDBNull(fila.GetOrdinal("Descripcion")) ? "" : fila.GetString(fila.GetOrdinal("Descripcion")),
                    Imagen = fila.IsDBNull(fila.GetOrdinal("Imagen")) ? "" : fila.GetString(fila.GetOrdinal("Imagen")),
                    Nombreevento = fila.IsDBNull(fila.GetOrdinal("Nombreevento")) ? "" : fila.GetString(fila.GetOrdinal("Nombreevento"))
                };
            }
            return s;
        }
    }
}
