using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.ServiceModel;
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
                Logic.User newUser = new Logic.User()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    ProfileImage = user.ProfileImage
                };
                status = register.RegisterUser(newUser);
            }
            catch (EntityException e)
            {
                
            }
            return status;
        }

        public bool ExistsEmailOrUserName(string userName, string email)
        {
            Register register = new Register();
            var status = false;

            try
            {
                status = register.ExistsEmailOrUserName(userName, email);
            }
            catch (EntityException e)
            { 

            }
            return status;
        }

        public bool SendValidationEmail(String toEmail, String affair, int validationCode)
        {
            var client = new EmailSender();
            var status = client.SendValidationEmail(toEmail, affair, validationCode);
            return status;
        }

        public bool UpdatePassword(string password, string email)
        {
            var status = false;
            try
            {
                var client = new Authentication();
                status = client.UpdateUserPassword(password, email);
            }
            catch (EntityException e)
            {

            }
            return status;
        }

    }

    public partial class StopGameService : IGameServices
    {
        private List<Logic.Room> globalRooms = new List<Room>();

        public bool NewRoom(string hostUserName, string roomId)
        {
            var newRoom = new Logic.Room()
            {
                Id = roomId,
                HostUserName = hostUserName,
                MatchStatus = RoomStatus.Waitting,
                CurrentUsersCount = 0,
                Users = new List<User>(),
                Round = 0,
                Winner = "",
                RoomTokens = 0
            };
            globalRooms.Add(newRoom);
            return true;
        }

        public string GenerateRoomCode()
        {
            Guid roomId = Guid.NewGuid();
            return roomId.ToString();
        }

        public void Connect(string userName, string roomId, string message)
        {
            User user = new User()
            {
                UserName = userName,
                UserContext = OperationContext.Current,
                Tokens = 11
            };

            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));
            if(room.Users.Count > 0)
            {
                SendMessage($": {user.UserName} {message}!", user.UserName, roomId);
            }
            room.Users.Add(user);
            room.CurrentUsersCount++;
        }

        public void Disconnect(string userName, string roomId, string message)
        {
            Logic.User user = null;
            var room = globalRooms.FirstOrDefault(r =>r.Id.Equals(roomId));

            if(room != null)
            {
                user = room.Users.FirstOrDefault(i => i.UserName.Equals(userName));
            }

            if(user != null)
            {
                room.Users.Remove(user);
                room.CurrentUsersCount--;
                if(room.Users.Count() == 0)
                {
                    globalRooms.Remove(room);
                }
                else
                {
                    SendMessage($": {user.UserName} {message}!", user.UserName, roomId);
                }
            }
        }

        public void SendMessage(string message, string userName, string roomId)
        {
            var room = globalRooms.FirstOrDefault(r =>r.Id.Equals(roomId));
            foreach(var user in room.Users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var anotherUser = room.Users.FirstOrDefault(i => i.UserName.Equals(userName));
                if (anotherUser != null)
                {
                    answer += $": {anotherUser.UserName} ";
                }
                answer += message;
                user.UserContext.GetCallbackChannel<IGameServiceCallback>().MessageCallBack(answer);
            }
        }

    }

    public partial class StopGameService : IUpdateProfile
    {
        public bool SaveImage(string imageManager, int idProfile)
        {
            var status = false;
            try
            {
                var client = new Authentication();
                status = client.SaveImage(imageManager, idProfile);
            }
            catch (EntityException e)
            {

            }
            Console.WriteLine();
            return status;
        }

        public bool UpdateNewUserName(string userName, string newUserName)
        {
            var status = false;
            try
            {
                var client = new Authentication();
                status = client.UpdateUserUserName(userName, newUserName);
            }
            catch (EntityException e)
            {

            }
            return status;
        }
    }
}
