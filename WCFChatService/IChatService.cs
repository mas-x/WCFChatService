using System.Collections.Generic;
using System.ServiceModel;

namespace WCFChatService
{
    [ServiceContract(SessionMode = SessionMode.Required,
                 CallbackContract = typeof(IChatServiceCallback))]
    public interface IChatService
    {
        [OperationContract]
        bool Connect(string username);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string username, string message);
        [OperationContract]
        List<string> GetCurrentlyJoinedUsers();
    }

}
