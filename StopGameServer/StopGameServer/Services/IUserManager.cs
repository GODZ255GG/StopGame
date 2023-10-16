using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    [ServiceContract]
    public interface IUserManager
    {
        [OperationContract]
        Logic.User Login(String userName, String password);

        [OperationContract]
        bool Register(User user);
    }
}
