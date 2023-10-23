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
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
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

    public partial class StopGameService : IGameServices
    {
        List<string> Users = new List<string>();
        List<IGameServiceCallback> Callbacks = new List<IGameServiceCallback>();
        public void Connect(string userName)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IGameServiceCallback>();
            Users.Add(userName);
            Callbacks.Add(callback);

            UpdateAllUsers();
        }

        public void Disconnect(string userName)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IGameServiceCallback>();
            Users.Remove(userName);
            Callbacks.Remove(callback);

            UpdateAllUsers();
        }

        private void UpdateAllUsers()
        {
            foreach (var callback in Callbacks)
            {
                callback.UpdateUsersList(Users);
            }
        }
    }
}
