using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioDesactivarProveedor;
using EntidadesNegocio;

namespace InterfazWeb
{
    public partial class ClientDesactivarProveedor : System.Web.UI.Page
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
            ServicioDesactivarProveedorClient clienteWCF = new ServicioDesactivarProveedorClient();
            clienteWCF.Open();
            DDLProveedor.DataSource = Proveedor.FindAll();
            DDLProveedor.DataValueField = "Rut";
            DDLProveedor.DataTextField = "Rut";
            DDLProveedor.DataBind();
            clienteWCF.Close();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void btnDesactivarProv_Click(object sender, EventArgs e)
        {
            ServicioDesactivarProveedorClient clienteWCF = new ServicioDesactivarProveedorClient();
            clienteWCF.Open();

            string activo = DDLActivo.SelectedValue;

            if (clienteWCF.DesactivarProveedor(DDLProveedor.SelectedValue, Convert.ToBoolean(activo)))
            {
                if (Convert.ToBoolean(activo) == false)
                {
                    LblMensajes.Text = "El proveedor " + DDLProveedor.SelectedValue + " ha sido desactivado";
                }
                else
                {
                    LblMensajes.Text = "El proveedor " + DDLProveedor.SelectedValue + " ha sido activado";
                }
            }
            else
            {
                LblMensajes.Text = "La modificación no pudo realizarse";
            }

            clienteWCF.Close();
        }
    }
}