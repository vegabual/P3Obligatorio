using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using EntidadesNegocio;
using System.IO;

namespace WCFFileProveedores
{
    public class ServicioFileProveedores : IServicioFileProveedores
    {
        public bool ProveedoresFile()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileLoc = Path.Combine(projectFolder, System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\..\FileProveedores.txt");

            FileStream fs = null;
            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {

                }
            }
            if (File.Exists(fileLoc))
            {
                using (StreamWriter sw = new StreamWriter(fileLoc))
                {
                    List<Proveedor> proveedores = Proveedor.FindAll();
                    foreach (Proveedor p in proveedores)
                    {
                        sw.WriteLine(p.ToString());
                    }
                }
            }
            return true;
        }
    }
}