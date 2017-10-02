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

            result = Proveedor.ModificarArancel(arancel);

            return result;
        }

        public bool ModificarPorcentaje(double porcentaje)
        {
            bool result = false;
            result = Proveedor_Vip.ModificarPorcentaje(porcentaje);

            return result;
        }

        public IEnumerable<DTOProveedor> GetPorcYArancel()
        {
            IEnumerable<Proveedor> lista = Proveedor.FindAll();
            List<DTOProveedor> listaprov = new List<DTOProveedor>();
            if (lista != null)
            {
                foreach (Proveedor_Vip pv in lista)
                {
                    //listaprov.Add(new WCFModificarArancelyPorcentaje.DTOProveedor { Arancel = , Porcentaje = pv.Porcentaje });
                }
            }
            return listaprov;
        }
    }
}
