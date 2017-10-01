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
        public List<Servicio> FindAll()
        {
            List<Servicio> lista = Servicio.FindAll();
            return lista;
        }
    }
}