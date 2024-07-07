using ChatAppTest.Common.Interfaces;
using ChatApptTest.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatModel>> GetChat(int id)
        {
            var chat = await _chatService.GetChatByIdAsync(id);

            if (chat == null)
            {
                return NotFound();
            }
            return Ok(chat);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatModel>>> GetChats()
        {
            var chats = await _chatService.GetAllChatsAsync();
            return Ok(chats);
        }

        [HttpPost]
        public async Task<ActionResult> CreateChat([FromBody] ChatModel chat)
        {
            if (chat == null)
                return BadRequest("Chat is null");

            await _chatService.CreateChatAsync(chat);
            return CreatedAtAction(nameof(GetChat), new { id = chat.ChatId },chat);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChat(int id, [FromBody] string userId)
        {
            try
            {
                await _chatService.DeleteChatAsync(id, userId);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
        }
    }
}
