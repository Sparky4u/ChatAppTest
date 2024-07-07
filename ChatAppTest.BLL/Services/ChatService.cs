using ChatAppTest.Common.Interfaces;
using ChatApptTest.Common.Models;

namespace ChatAppTest.BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<ChatModel> GetChatByIdAsync(int chatId)
        {
            return await _chatRepository.GetChatByIdAsync(chatId);
        }

        public async Task<IEnumerable<ChatModel>> GetAllChatsAsync()
        {
            return await _chatRepository.GetAllChatsAsync();
        }

        public async Task CreateChatAsync(ChatModel chat)
        {
            await _chatRepository.CreateChatAsync(chat);
            await _chatRepository.SaveAsync();
        }

        public async Task DeleteChatAsync(int chatId, string userId)
        {
            await _chatRepository.DeleteChatAsync(chatId, userId);
            await _chatRepository.SaveAsync();
        }
    }

}
