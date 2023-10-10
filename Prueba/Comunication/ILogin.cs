using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Comunication
{
    [ServiceContract]
    interface ILogin
    {
        [OperationContract]
        UserDTO Login(string username, string password);
    }
}
