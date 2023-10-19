using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract]
    internal interface IUpdateProfile
    {
        [OperationContract]
        List<String> GetGlobalUser();
    }
}
