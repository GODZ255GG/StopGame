using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class User
    {
        private int idUser;
        private string userName;
        private string email;
        private string password;
        private bool status;

        #region Non-Serializable
        private OperationContext aOperationContext;
        public OperationContext AOperationContext { get { return aOperationContext; } set { aOperationContext = value; } }
        #endregion

        #region Properties
        [DataMember]
        public bool Status { get { return status; } set { status = value; } }
        [DataMember]
        public int IdUser { get { return idUser; } set { idUser = value; } }
        [DataMember]
        public string UserName { get { return userName; } set { userName = value; } }
        [DataMember]
        public string Email { get { return email; } set { email = value; } }
        [DataMember]
        public string Password { get { return password; } set { password = value; } }
        #endregion
    }
}
