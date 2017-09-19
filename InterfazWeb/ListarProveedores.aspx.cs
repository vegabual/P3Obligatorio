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
    public partial class ListarProveedores : System.Web.UI.Page
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
                string sQuery = "SELECT p.rut, p.nombrefantasia FROM Proveedor AS p";

                cn = Conexion.CrearConexion();
                Conexion.AbrirConexion(cn);
                SqlCommand cmd = new SqlCommand(sQuery, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);
                grvProveedores.DataSource = dt;
                grvProveedores.DataBind();
            }
            catch { }
            finally
            {
                dt.Dispose();
                Conexion.CerrarConexion(cn);
            }
        }

        protected void grvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ListarProveedoresSeleccionado.aspx");
        }
    }
}