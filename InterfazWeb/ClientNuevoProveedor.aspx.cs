using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioNuevoProv;
using EntidadesNegocio;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace InterfazWeb
{
    public partial class ClientNuevoProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                vaciar();
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string cadena = ConfigurationManager.ConnectionStrings["conexionProvEventos"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT idServicio, nombreservicio, descripcion FROM Servicio"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            grvServicios.DataSource = dt;
                            grvServicios.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ServicioNuevoProvClient ClienteWCF = new ServicioNuevoProvClient();
            ClienteWCF.Open();
            string rut = txtRut.Text;
            string clave = txtClave.Text;
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            string tel = txtTel.Text;
            Usuario user = new Usuario(rut, Usuario.HashPassword(clave), Rol.Proveedor);
            List<int> serviciosProv = new List<int>();
            foreach (GridViewRow row in grvServicios.Rows)
            {
                if (((CheckBox)row.FindControl("ChkSelect")).Checked)
                {
                    int id;
                    if (int.TryParse(row.Cells[1].Text, out id))
                    {
                        serviciosProv.Add(id);
                    }
                }
            }
            bool res = ClienteWCF.NuevoProveedor(rut, clave, nombre, email, tel, chkVip.Checked, serviciosProv.ToArray());
            if (res)
            {
                LblMensajes.Text = "El proveedor se ha creado correctamente";
            }
            else
            {
                LblMensajes.Text = "Ocurrio un error en la creacion, revise los datos";
            }
        }
        protected void vaciar()
        {
            txtRut.Text = "";
            txtClave.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            foreach (GridViewRow row in grvServicios.Rows)
            {
                ((CheckBox)row.FindControl("ChkSelect")).Checked = false;
            }
        }
    }
}