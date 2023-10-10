using DataAccess;
using Logic;
using System.ServiceModel;

namespace Comunication
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
    public class Login : ILogin
    {
        UserDTO ILogin.Login(string username, string password)
        {
            UserAdministration user = new UserAdministration();
            UserDTO userDTO = user.Login(username, password);
            return userDTO;
        }
    }
}
