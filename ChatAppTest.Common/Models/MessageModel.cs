
namespace ChatApptTest.Common.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public int ChatId { get; set; }
        public ChatModel Chat { get; set; }
    }
}
