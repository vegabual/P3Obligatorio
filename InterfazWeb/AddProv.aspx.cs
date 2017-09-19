using EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void ValRut_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int i;
            args.IsValid = args.Value != null && args.Value != "" && int.TryParse(args.Value, out i);
        }

        protected void valClave_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Regex regexPass = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
            args.IsValid = args.Value != null && args.Value != "" && regexPass.IsMatch(args.Value);
        }

        protected void valEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            args.IsValid = args.Value != null && args.Value != ""  && regexEmail.IsMatch(args.Value);
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
                Usuario user = new Usuario(rut, clave, Rol.Proveedor);
                Proveedor prov;
                if (chkVip.Checked)
                {
                    prov = new Proveedor_Vip(rut, nombre, email, tel, null);
                }
                else
                {
                    prov = new Proveedor_Comun(rut, nombre, email, tel, null);
                }
                bool uservalido = user.Validar();
                bool provvalido = prov.Validar();
                if (user.Validar() && prov.Validar())
                {
                    user.Insertar();
                    prov.Insertar();
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
    }
}