using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        private int idUser;
        private string userName;
        private string email;
        private string password;

        #region Singletone
        private static User userClient;
        public static User UserClient { get { return userClient; } set { userClient = value; } }
        #endregion

        public int IdUser { get { return idUser; } set { idUser = value; } }
        public string UserName { get { return userName; } set { userName = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
    }
}
