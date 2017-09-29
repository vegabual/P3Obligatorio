using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntidadesNegocio;

namespace WCFFileProveedores
{
    [ServiceContract]
    public interface IServicioFileProveedores
    {
        [OperationContract]
        bool ProveedoresFile();
    }
}
