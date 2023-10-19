using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ListUsers
    {
        public List<String> ListAllUser()
        {
            List<String> logicUsers = new List<String>();
            using(var context = new StopEntities())
            {
                var accounts = (from users in context.Users
                                select users);
                if(accounts.Any())
                {
                    foreach (var account in accounts)
                    {
                        logicUsers.Add(account.userName);
                    }
                }
            }
            return logicUsers;
        }
    }
}
