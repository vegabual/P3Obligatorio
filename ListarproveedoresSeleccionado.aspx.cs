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
            string cadena = ConfigurationManager.ConnectionStrings["conexionProvEventos"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT p.rut, p.nombrefantasia, p.email, 
                                                        CASE CAST(p.activo AS VARCHAR(10)) WHEN '1' THEN 'Si' WHEN '0' THEN 'No' END AS activo, 
                                                        ISNULL(pv.porcentaje,0.00) AS porcentaje, tp.telefono FROM Proveedor AS p FULL JOIN ProveedorVIP AS pv ON p.rut = pv.rut 
                                                        FULL JOIN TelefonoProveedor AS tp ON p.rut = tp.rut
                                                        WHERE @rut = p.rut"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        string rut = Session["rut"].ToString();
                        cmd.Parameters.Add(new SqlParameter("@rut", rut));
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            grvProveedoresSeleccionado.DataSource = dt;
                            grvProveedoresSeleccionado.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarProveedores.aspx");
        }
    }
}