using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntidadesNegocio;

namespace WCFModificarArancelyPorcentaje
{
    public class ServicioModArancelyPorcentaje : IServicioModArancelyPorcentaje
    {
        public bool ModificarArancel(double arancel) 
        {
            bool result = false;

            result = Proveedor.Modificar(arancel);

            return result;
        }

        public bool ModificarPorcentaje(double porcentaje)
        {
            bool result = false;
            result = Proveedor_Vip.Modificar(porcentaje);

            return result;
        }
    }
}
