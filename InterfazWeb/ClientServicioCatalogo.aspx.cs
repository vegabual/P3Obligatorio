using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioCatalogo;

namespace InterfazWeb
{
    public partial class ClientServicioCatalogo : System.Web.UI.Page
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
            ServicioCatalogoClient ClienteWFC = new ServicioCatalogoClient();
            ClienteWFC.Open();
            grvServicios.DataSource = ClienteWFC.FindAll();
            grvServicios.DataBind();
            ClienteWFC.Close();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {

        }
    }
}