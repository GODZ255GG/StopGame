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
    //El OperationContext que se encuentra en esta clase cumple la función de devolver un objeto User completo
    //Utilizamos el OperationContext sin serializar, y poder convertir los datos del EntitiyFramework a una clase
    //serializable que pueda ocupar el servicio en conjunto con los demás OperationContext
    [DataContract]
    public class User
    {
        private int _idUser;
        private int _tokens;
        private bool _status;
        private string _userName;
        private string _email;
        private string _password;
        private string _profileImage;

        #region Non-Serializable
        private OperationContext userContext;
        public OperationContext UserContext { get { return userContext; } set { userContext = value; } }
        #endregion
        //revisar
        #region Properties
        [DataMember]
        public int IdUser { get { return _idUser; } set { _idUser = value; } }
        [DataMember]
        public int Tokens { get { return _tokens; } set { _tokens = value; } }
        [DataMember]
        public bool Status { get { return _status; } set { _status = value; } }
        [DataMember]
        public string UserName { get { return _userName; } set { _userName = value; } }
        [DataMember]
        public string Email { get { return _email; } set { _email = value; } }
        [DataMember]
        public string Password { get { return _password; } set { _password = value; } }
        [DataMember]
        public string ProfileImage { get {  return _profileImage; } set {  _profileImage = value; } }
        #endregion
    }
}
