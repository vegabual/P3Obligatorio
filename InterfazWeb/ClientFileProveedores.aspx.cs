using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioFileProveedores;

namespace InterfazWeb
{
    public partial class ClientFileProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void btnCrearFile_Click(object sender, EventArgs e)
        {
            ServicioFileProveedoresClient ClienteWCF = new ServicioFileProveedoresClient();
            ClienteWCF.Open();
            if (ClienteWCF.ProveedoresFile())
            {
                LblMensajes.Text = "El archivo fue creado correctamente.";
            }
            else
            {
                LblMensajes.Text = "Ocurrio un error en la creacion del archivo, intente nuevamente.";
            }
        }
    }
}