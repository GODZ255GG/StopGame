using System.Runtime.Serialization;

namespace DataAccess
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
