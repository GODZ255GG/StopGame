using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract(CallbackContract = typeof(IGameServiceCallback))]
    public interface IGameServices
    {
        [OperationContract]
        bool NewRoom(string hostUserName, string roomId);
        [OperationContract]
        string GenerateRoomCode();
        [OperationContract]
        void Connect(string userName, string roomId, string message);
        [OperationContract]
        void Disconnect(string userName, string roomId, string message);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string userName, string roomId);
    }

    [ServiceContract]
    public interface IGameServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallBack(string message);
    }
}
