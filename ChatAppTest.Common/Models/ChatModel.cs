
namespace ChatApptTest.Common.Models
{
    public class ChatModel
    {
        public int ChatId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<MessageModel> Messages { get; set; } = new List<MessageModel>();
    }
}
