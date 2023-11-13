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
                    user.Email = accounts.First().email;
                    user.Password = "";
                    user.ProfileImage = accounts.First().profileImage;
                    user.Status = true;
                }
            }
            return user;
        }

        public bool UpdateUserUserName(string userName, string updateUserName)
        {
            var status = false;
            using (var context = new StopEntities())
            {
                var userToUpdate = context.Users.FirstOrDefault(n => n.userName.Equals(updateUserName));
                if(userToUpdate == null)
                {
                    return false;
                }
                userToUpdate.userName = userName;
                status = context.SaveChanges() > 0;
            }
            return status;
        }

        public bool SaveImage(string imageManager, int idProfile)
        {
            var status = false;
            using(var context = new StopEntities())
            {
                var userToUpdate = context.Users.FirstOrDefault(c => c.idUser.Equals(idProfile));
                if(userToUpdate == null)
                {
                    return false;
                }
                userToUpdate.profileImage = imageManager;
                status = context.SaveChanges() > 0;
            }
            return status;
        }
    }
}
