﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServicioServiciosFile;

namespace InterfazWeb
{
    public partial class ClientServiciosFile : System.Web.UI.Page
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
            ServicioServiciosFileClient ClienteWCF = new ServicioServiciosFileClient();
            ClienteWCF.Open();
            if (ClienteWCF.ServiciosFile())
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