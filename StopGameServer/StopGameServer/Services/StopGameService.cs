using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Logic;

namespace Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public partial class StopGameService : IUserManager
    {

        public Logic.User Login(String userName, String password)
        {
            var user = new Logic.User()
            {
                Status = false
            };
            try
            {
                var client = new Authentication();
                user = client.Login(userName, password);
            }
            catch (EntityException e)
            {
                
            }
            return user;
        }

        public bool Register(User user)
        {
            var status = false;
            try
            {
                Register register = new Register();
                Logic.User user1 = new Logic.User()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password
                };
                status = register.RegisterUser(user1);
            }
            catch (EntityException e)
            {
                
            }
            return status;
        }

    }

    public partial class StopGameService : IUpdateProfile
    {
        public List<String> GetGlobalUser()
        {
            ListUsers list = new ListUsers();
            List<string> result = new List<string>();
            try
            {
                result = list.ListAllUser();
            }
            catch (EntityException ex)
            {

            };
            return result;
        }
    }
}
