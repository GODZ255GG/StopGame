using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [DataContract]  
    public class Room
    {
        private string id;
        private int round;
        private string hostUserName;
        private RoomStatus matchStatus;
        private string winner;
        private const int MAX_USERS = 4;
        private const int MIN_USERS = 2;
        private int currentUsersCount = 0;
        private int roomTokens;
        private List<User> users;

        #region Properties
        [DataMember]
        public string Id { get {  return id; } set { id = value; } }
        [DataMember] 
        public int Round { get {  return round; } set { round = value; } }
        [DataMember]
        public string HostUserName { get {  return hostUserName; } set {  hostUserName = value; } }
        [DataMember]
        public RoomStatus MatchStatus { get {  return matchStatus; } set {  matchStatus = value; } }
        [DataMember]
        public string Winner { get {  return winner; } set {  winner = value; } }
        [DataMember]
        public int MAX_USERS1 => MAX_USERS;
        [DataMember]
        public int MIN_USERS1 => MIN_USERS;
        [DataMember]
        public int CurrentUsersCount { get {  return currentUsersCount; } set {  currentUsersCount = value; } }
        [DataMember]
        public int RoomTokens { get {  return roomTokens; } set {  roomTokens = value; } }
        [DataMember]
        public List<User> Users { get {  return users; } set { users = value; } }
        #endregion
    }
}
