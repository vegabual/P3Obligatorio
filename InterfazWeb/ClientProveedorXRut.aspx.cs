using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioProveedorXRut;
using EntidadesNegocio;

namespace InterfazWeb
{
    public partial class ClientProveedorXRut : System.Web.UI.Page
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
            ServicioProveedorXRutClient clienteWCF = new ServicioProveedorXRutClient();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string rut = DDLProveedor.SelectedValue;
           
            ServicioProveedorXRutClient ClienteWFC = new ServicioProveedorXRutClient();
            ClienteWFC.Open();

            List<DTOProveedor> dtoprov = new List<DTOProveedor>();
            dtoprov.Add(ClienteWFC.FindById(rut));

            grvProveedores.DataSource = dtoprov;
            grvProveedores.DataBind();
            grvServicios.DataSource = ClienteWFC.FindById(rut).Servicios;
            grvServicios.DataBind();
            ClienteWFC.Close();
            Limpiar();
        }

        private void Limpiar()
        {   
            DDLProveedor.SelectedIndex = -1;
        }
    }
}