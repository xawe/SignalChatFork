using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;
using SignalRSimpleChat.Model;
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
        private IOptions<ApplicationConfig> configs;
        public ChatService(NetchatContext _context, IOptions<ApplicationConfig> applicationConfigs)
        {
            context = _context;
            configs = applicationConfigs;
        }
        public async Task SaveChat(string username, string message)
        {

            if(configs.Value.Save_Messages_In_DB)
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(message))
                {
                    context.Chat.Add(new SignalRSimpleChat.Model.Chat
                    {
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
                        throw ex;
                    }
                }  
            }                       
        }
    }
}
