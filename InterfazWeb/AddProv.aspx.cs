using EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb
{
    public partial class AddProv : System.Web.UI.Page
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

        protected void ValRut_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int i;
            args.IsValid = args.Value != null && args.Value != "" && int.TryParse(args.Value, out i);
        }

        protected void valClave_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value != null && args.Value != "" && Usuario.ValidarClave(args.Value);
        }

        protected void valEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            args.IsValid = args.Value != null && args.Value != "" && regexEmail.IsMatch(args.Value);
        }

        protected void valTel_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int i;
            args.IsValid = args.Value != null && args.Value != "" && int.TryParse(args.Value, out i);
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string rut = txtRut.Text;
                string clave = txtClave.Text;
                string nombre = txtNombre.Text;
                string email = txtEmail.Text;
                string tel = txtTel.Text;
                Usuario user = new Usuario(rut, Usuario.HashPassword(clave), Rol.Proveedor);
                Proveedor prov;
                List<Servicio> serviciosProv = new List<Servicio>();
                foreach (GridViewRow row in grvServicios.Rows)
                {
                    if (((CheckBox)row.FindControl("ChkSelect")).Checked)
                    {
                        int id;
                        if (int.TryParse(row.Cells[1].Text, out id))
                        {
                            Servicio s = Servicio.EncuentraServicio(id);
                            if (s != null)
                                serviciosProv.Add(s);
                        }
                    }
                }
                if (chkVip.Checked)
                {
                    prov = new Proveedor_Vip(rut, nombre, email, tel, serviciosProv);
                }
                else
                {
                    prov = new Proveedor_Comun(rut, nombre, email, tel, serviciosProv);
                }
                if (Usuario.ValidarClave(clave) && prov.Validar())
                {
                    if (user.Insertar() && prov.Insertar())
                    {
                        lblResultado.Text = "El proveedor ha sido registrado exitosamente";
                    }
                    else
                    {
                        lblResultado.Text = "Ha occurrido un error, verifique sus datos por favor";
                    }
                }
                else
                {
                    lblResultado.Text = "Ha occurrido un error, verifique sus datos por favor";
                }
            }
            else
            {
                lblResultado.Text = "Ha occurrido un error, verifique sus datos por favor";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
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