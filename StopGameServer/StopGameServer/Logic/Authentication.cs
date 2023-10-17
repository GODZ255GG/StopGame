using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Authentication
    {
        public List<User> UsersList { get; set; }
        public Authentication()
        {
        }

        public Logic.User Login(string username, string password)
        {
            Logic.User user = new Logic.User();
            using (var context = new StopEntities())
            {
                var accounts = (from users in context.Users
                                where users.userName == username && users.password == password
                                select users);
                if (accounts.Any())
                {
                    user.IdUser = accounts.First().idUser;
                    user.UserName = accounts.First().userName;
                    user.Password = "";
                    user.Status = true;
                }
            }
            return user;
        }
    }
}
