using ChatAppTest.Common.Interfaces;
using ChatApptTest.DAL.Data;
using ChatApptTest.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApptTest.DAL.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatAppDbContext _context;

        public ChatRepository(ChatAppDbContext context)
        {
            _context = context;
        }

        public async Task<ChatModel> GetChatByIdAsync(int chatId)
        {
            return await _context.Chats.Include(c => c.Messages).FirstOrDefaultAsync(c => c.ChatId == chatId);
        }

        public async Task<IEnumerable<ChatModel>> GetAllChatsAsync()
        {
            return await _context.Chats.Include(c => c.Messages).ToListAsync();
        }

        public async Task CreateChatAsync(ChatModel chat)
        {
            await _context.Chats.AddAsync(chat);
        }

        public async Task DeleteChatAsync(int chatId, string userId)
        {
            var chat = await _context.Chats.FirstOrDefaultAsync(c => c.ChatId == chatId && c.CreatedBy == userId);
            if (chat == null) throw new UnauthorizedAccessException("No permissions to delete this chat");
            _context.Chats.Remove(chat);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
