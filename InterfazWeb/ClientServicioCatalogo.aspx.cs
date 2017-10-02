using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioCatalogo;
using EntidadesNegocio;
using WCFProvEventos;

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
            List<CatalogoServicios> servicios = ClienteWFC.FindAll().ToList();
            grvServicios.DataSource = ClienteWFC.FindAll().ToList();
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