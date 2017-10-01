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

namespace WCFServiciosFile
{
    public class ServicioServiciosFile : IServicioServiciosFile
    {
        public bool ServiciosFile()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileLoc = Path.Combine(projectFolder, System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\..\FileServicios.txt");

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
                    int count = 1;
                    foreach (Servicio s in Servicio.FindServFile())
                    {
                        sw.WriteLine(s.Nombre);
                        Console.WriteLine();
                        count++;
                    }
                }
            }
            return true;
        }
    }
}
