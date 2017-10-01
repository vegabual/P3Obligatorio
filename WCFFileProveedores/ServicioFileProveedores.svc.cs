<<<<<<< HEAD
﻿using System;
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
                    int count = 1;
                    foreach(Proveedor_Comun pv in Proveedor_Comun.FindProvFile())
                    {
                        sw.WriteLine("RUT" + count + " " + pv.Rut + " " + "#" + pv.NombreFantasia + " " + "#" + pv.Email + " " + "#" + pv.Telefono + " | ");
                        Console.WriteLine();
                        count++;
                    }
                }
            }
            return true;
        }
    }
=======
﻿using System;
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
                    int count = 1;

                    foreach (Proveedor_Comun pv in Proveedor_Comun.FindProvFile())
                    {
                        foreach (Servicio s in Servicio.FindServFile())
                        {
                            sw.WriteLine("RUT" + count + " " + pv.Rut + " " + "#" + pv.NombreFantasia + " " + "#" + pv.Email + " " + "#" + pv.Telefono + " | "
                            + s.Nombre + count + ":" + s.Descripcion + count + ":" + s.Imagen);
                            count++;
                        }
                    }
                }
            }
            return true;
        }
    }
>>>>>>> 5cd4113433b66b0ca4c5cf4d3303ce21c5198061
}