using ChatApptTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppTest.Common.Interfaces
{
    public interface IChatService
    {
        public Task<ChatModel> GetChatByIdAsync(int chatId);
        public Task<IEnumerable<ChatModel>> GetAllChatsAsync();
        public Task CreateChatAsync(ChatModel chat);
        public Task DeleteChatAsync(int chatId, string userId);
    }
}
