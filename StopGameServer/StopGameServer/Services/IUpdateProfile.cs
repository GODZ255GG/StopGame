using System.ServiceModel;

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
