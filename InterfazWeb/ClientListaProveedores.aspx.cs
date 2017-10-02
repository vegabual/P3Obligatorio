using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioListaProveedores;

namespace InterfazWeb
{
    public partial class ClientListaProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Inicializar();
            }
        }

        private void Inicializar()
        {
            ServicioListaProveedoresClient ClienteWFC = new ServicioListaProveedoresClient();
            ClienteWFC.Open();
            grvProveedores.DataSource = ClienteWFC.ListarProveedores();
            grvProveedores.DataBind();
            ClienteWFC.Close();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }
    }
}