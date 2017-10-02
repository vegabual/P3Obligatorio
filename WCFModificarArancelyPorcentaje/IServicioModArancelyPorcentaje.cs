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
    [ServiceContract]
    public interface IServicioModArancelyPorcentaje
    {
        [OperationContract]
        bool ModificarArancel(double arancel);

        [OperationContract]
        bool ModificarPorcentaje(double porcentaje);

        [OperationContract]
        IEnumerable<DTOProveedor> GetPorcYArancel();
    }

    [DataContract]
    public class DTOProveedor
    {
        double porcentaje = 0;
        double arancel = 0;

        [DataMember]
        public double Arancel
        {
            get { return arancel; }
            set { arancel = value; }
        }

        [DataMember]
        public double Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }
    }
}
