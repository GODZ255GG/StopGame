using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserAdministration
    {
        public UserDTO Login(string username, string password)
        {
            UserDTO userDTO = null;

            using (var context = new StopGameEntities())
            {
                var users = (from User in context.User where User.userName == username && User.password == password select User);
                if (users.Count() > 0)
                {
                    userDTO = new UserDTO();
                    userDTO.UserName = users.First().userName;
                    userDTO.Password = users.First().password;
                    userDTO.Email = users.First().email;
                }
                return userDTO;
            }
        }
    }
}
