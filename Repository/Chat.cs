using System;
using System.Collections.Generic;

namespace SignalRSimpleChat.Repository
{
    public partial class Chat
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
