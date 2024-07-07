using ChatApptTest.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApptTest.DAL.Data
{
    public class ChatAppDbContext : DbContext
    {
        public DbSet<ChatModel> Chats { get; set; }
        public DbSet<MessageModel> Messages { get; set; }

        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatModel>()
                .HasKey(c => c.ChatId);

            modelBuilder.Entity<ChatModel>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Chat)
                .HasForeignKey(m => m.ChatId);

            modelBuilder.Entity<MessageModel>()
                .HasKey(m => m.MessageId);
        }
    }
}
