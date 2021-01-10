using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFChatService;

namespace WCFChatServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(ChatService));
            serviceHost.Open();
            Console.WriteLine("Service started ...");
            Console.WriteLine("Press key to stop the service.");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}
