using ChatAppTest.BLL.Services;
using ChatAppTest.Common.Interfaces;
using ChatApptTest.Common.Models;
using Moq;



namespace ChatAppTest.UnitTests
{
    [TestFixture]
    public class ChatServiceTest
    {
        private ChatService _chatService;
        private Mock<IChatRepository> _chatRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _chatRepositoryMock = new Mock<IChatRepository>();
            _chatService = new ChatService( _chatRepositoryMock.Object);
        }


        [Test]
        public async Task GetChatByIdAsync_ShouldReturnChat_WhenChatExists()
        {
            var chatId = 1;
            var chat = new ChatModel { ChatId = chatId };
            _chatRepositoryMock.Setup(repo => repo.GetChatByIdAsync(chatId)).ReturnsAsync(chat);

            var result = await _chatService.GetChatByIdAsync(chatId);

            Assert.AreEqual(chatId,result.ChatId);
        }

        [Test]
        public async Task GetAllChatsAsync_ShouldReturnAllChats()
        {
            var chats = new List<ChatModel> { new ChatModel { ChatId = 1 }, new ChatModel { ChatId = 2 } };
            _chatRepositoryMock.Setup(repo => repo.GetAllChatsAsync()).ReturnsAsync(chats);

            var result = await _chatService.GetAllChatsAsync();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task CreateChatAsync_ShouldCallRepositoryCreateChat()
        {
            var chat = new ChatModel { ChatId = 1, Name = "Test Chat", CreatedBy = "user1" };
            _chatRepositoryMock.Setup(repo => repo.CreateChatAsync(chat)).Returns(Task.CompletedTask);

            await _chatService.CreateChatAsync(chat);

            _chatRepositoryMock.Verify(repo => repo.CreateChatAsync(chat), Times.Once);
            _chatRepositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteChatAsync_ShouldCallRepositoryDeleteChat()
        {
            var chatId = 1;
            var userId = "user1";
            _chatRepositoryMock.Setup(repo => repo.DeleteChatAsync(chatId, userId)).Returns(Task.CompletedTask);

            await _chatService.DeleteChatAsync(chatId, userId);

            _chatRepositoryMock.Verify(repo => repo.DeleteChatAsync(chatId, userId), Times.Once);
            _chatRepositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }
    }
}