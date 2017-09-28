using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using System.Diagnostics;

namespace InterfazWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT nombreusuario, clave FROM Usuario WHERE nombreusuario = @usuario AND clave = @password";
            cmd.Parameters.AddWithValue("@usuario", login.UserName);
            cmd.Parameters.AddWithValue("@password", login.Password);
            cmd.Connection = cn;
      
            Conexion.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.HasRows)
            {
                dr.Close();
                cmd.CommandText = @"SELECT * FROM Usuario WHERE idrol = '1001' AND nombreusuario = @usuario";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@usuario", login.UserName));

                SqlDataReader dr2 = cmd.ExecuteReader();

                if (dr2.HasRows)
                {
                    Response.Redirect("ListarProveedores.aspx");
                }
                else
                {
                    Response.Redirect("MenuProv.aspx");
                }
            }
            Conexion.CerrarConexion(cn);
        }

        protected void LinkButton_Register(object sender, EventArgs e)
        {
            Response.Redirect("AddProv.aspx");
        }
    }
}