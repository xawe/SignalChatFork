using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SignalRSimpleChat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSimpleChat.Services
{
    public class ChatService : IChatService
    {

        private NetchatContext context;
        public ChatService(NetchatContext _context)
        {
            context = _context;
        }
        public async Task SaveChat(string username, string message)
        {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(message))
            {
                context.Chat.Add(new Repository.Chat {
                CreatedOn = DateTime.Now,
                Message = message,
                UserName = username
                });
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var x = ex;
                    throw ex;
                }
                
            }                       
        }
    }
}
