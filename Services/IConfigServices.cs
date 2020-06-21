using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSimpleChat.Services
{
    public interface IConfigServices
    {
        bool GetSaveMessagesConfig();
    }
}
