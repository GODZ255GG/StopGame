using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Register
    {
        public Register()
        {
        }

        public bool RegisterUser(Logic.User user)
        {
            bool status = NewRecord(user);
            return status;
        }

        public bool NewRecord(Logic.User user)
        {
            var status = false;
            using (var context = new StopEntities())
            {
                DataAccess.User newUser = new DataAccess.User()
                {
                    userName = user.UserName,
                    email = user.Email,
                    password = user.Password,
                    profileImage = user.ProfileImage,
                };
                context.Users.Add(newUser);
                status = context.SaveChanges() > 0;
            }
            return status;
        }

        public bool ExistsEmailOrUserName(string userName, string email)
        {
            bool result = false;
            using (var context = new StopEntities())
            {
                var accounts = (from users in context.Users
                                where users.email == userName || users.email == email
                                select users).Count();
                if(accounts > 0)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
