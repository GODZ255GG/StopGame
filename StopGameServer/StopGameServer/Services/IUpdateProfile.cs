using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract]
    public interface IUpdateProfile
    {
        [OperationContract]
        bool SaveImage(string imageManager, int idProfile);
        [OperationContract]
        bool UpdateNewUserName(string userName, string newUserName);
    }
}
