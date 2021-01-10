using System.ServiceModel;

namespace WCFChatService
{
    interface IChatServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnUserJoined(string username);
        [OperationContract(IsOneWay = true)]
        void OnReceiveMessage(string message);
    }
}
