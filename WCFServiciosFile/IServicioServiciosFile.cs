using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntidadesNegocio;

namespace WCFServiciosFile
{
    [ServiceContract]
    public interface IServicioServiciosFile
    {
        [OperationContract]
        bool ServiciosFile();
    }
}
