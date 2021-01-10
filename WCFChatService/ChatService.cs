using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private Dictionary<string, IChatServiceCallback> m_UsersDict = new Dictionary<string, IChatServiceCallback>();


        IChatServiceCallback Callback
        {
            get
            {             
                return OperationContext.Current.GetCallbackChannel<IChatServiceCallback>();              
            }
        }

        public bool Connect(string username)
        {
            if (m_UsersDict.ContainsKey(username))
                return false;

            m_UsersDict.Add(username, Callback);
            foreach (IChatServiceCallback callback in m_UsersDict.Values)
            {
                callback.OnUserJoined(username);
            }
            return true;
        }

        public void SendMessage(string username, string message)
        {
            foreach (IChatServiceCallback callback in m_UsersDict.Values)
            {
                callback.OnReceiveMessage($"{username}: {message}");
            }
        }
       
        public List<string> GetCurrentlyJoinedUsers()
        {
            return m_UsersDict.Keys.ToList();
        }
    }
}
