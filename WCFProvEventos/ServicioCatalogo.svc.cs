using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntidadesNegocio;

namespace WCFProvEventos
{
    public class ServicioCatalogo : IServicioCatalogo
    {
        public List<CatalogoServicios> FindAll()
        {
            List<Servicio> listaServicios = Servicio.FindAll();
            List<CatalogoServicios> listaRet = new List<CatalogoServicios>();
            foreach (Servicio s in listaServicios)
            {
                CatalogoServicios elem = new CatalogoServicios()
                {
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Imagen = s.Imagen
                };
                listaRet.Add(elem);
            }
            return listaRet;
        }
    }
}