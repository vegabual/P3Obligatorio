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
            string cadena = ConfigurationManager.ConnectionStrings["conexionProvEventos"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rut, nombrefantasia FROM Proveedor"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            grvProveedores.DataSource = dt;
                            grvProveedores.DataBind();
                        }
                    }
                }
            }
        }

        protected void grvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rut"] = grvProveedores.SelectedValue.ToString();
            Response.Redirect("ListarProveedoresSeleccionado.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }
    }
}