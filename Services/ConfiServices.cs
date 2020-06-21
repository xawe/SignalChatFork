using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;


namespace SignalRSimpleChat.Services
{
    public class ConfiServices : IConfigServices
    {
        public static System.Collections.Specialized.NameValueCollection AppSettings { get; }
        
        public bool GetSaveMessagesConfig()
        {
            return false;
        }
    }
}
