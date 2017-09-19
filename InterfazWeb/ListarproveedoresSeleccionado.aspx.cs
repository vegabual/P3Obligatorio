using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

namespace InterfazWeb
{
    public partial class ListarproveedoresSeleccionado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGridView();
        }

        private void BindGridView()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = null;

            try
            {
                string sQuery = @"SELECT p.*, CAST(ISNULL(pv.porcentaje,0) AS VARCHAR(28)) + '%', tp.telefono FROM Proveedor AS p 
                                  LEFT JOIN ProveedorVIP AS pv ON p.rut = pv.rut LEFT JOIN TelefonoProveedor AS tp ON p.rut = tp.rut";

                cn = Conexion.CrearConexion();
                cn.Open();
                SqlCommand cmd = new SqlCommand(sQuery, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);
                grvProveedoresSeleccionado.DataSource = dt;
                grvProveedoresSeleccionado.DataBind();
            }
            catch { }
            finally
            {
                dt.Dispose();
                cn.Close();
            }
        }

        protected void grvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}