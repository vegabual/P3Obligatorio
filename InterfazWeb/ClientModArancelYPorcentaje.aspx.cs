using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioModArancelyPorcentaje;
using EntidadesNegocio;

namespace InterfazWeb
{
    public partial class ClientModArancelYPorcentaje : System.Web.UI.Page
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
            ServicioModArancelyPorcentajeClient clienteWCF = new ServicioModArancelyPorcentajeClient();
            clienteWCF.Open();
           
            clienteWCF.Close();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ServicioModArancelyPorcentajeClient clienteWCF = new ServicioModArancelyPorcentajeClient();
            clienteWCF.Open();

            double arancel = Convert.ToDouble(txtArancel.Text);
            double porcentaje = Convert.ToDouble(txtPorcentaje.Text);

            if (clienteWCF.ModificarArancel(arancel) && clienteWCF.ModificarPorcentaje(porcentaje))
            {
                LblMensajes.Text = "El nuevo arancel de los proveedores es " + txtArancel.Text + " y el porcentaje para los VIP es " + txtPorcentaje.Text + "%";
            }
            else
            {
                LblMensajes.Text = "La modificación no pudo realizarse";
            }
            Limpiar();
            clienteWCF.Close();
        }

        private void Limpiar()
        {
            txtArancel.Text = "";
            txtPorcentaje.Text = "";
        }
    }
}