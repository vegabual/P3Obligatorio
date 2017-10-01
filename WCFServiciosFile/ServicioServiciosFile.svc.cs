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
                    List<Servicio> servicios = Servicio.FindAll();
                    foreach (Servicio s in servicios)
                    {
                        string print = s.Nombre + "#" + s.Eventos[0].Nombre;
                        for (int i = 1; i < s.Eventos.Count; i++)
                        {
                            print += ":" + s.Eventos[i].Nombre;
                        }
                        sw.WriteLine(print);
                    }
                }
            }
            return true;
        }
    }
}
