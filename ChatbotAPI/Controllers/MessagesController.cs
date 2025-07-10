using BusinessLogic.IServices;
using DataAccess.Constant;
using DataAccess.DTO.ChatDTOs;
using DataAccess.PaginatedList;
using DataAccess.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(
            IChatService chatService
        ) : ControllerBase
    {

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetAllMessagesByUserId(int id)
        {
            var message = await chatService.GetAllChatMessageByUserId(id);
            if (message == null)
            {
                return NotFound(
                new BaseResponseModel<List<ChatMessageDTO>>(
                StatusCodes.Status404NotFound,
                code: ResponseCodeConstants.FAILED,
                data: message,
                message: "Null")
                );
            }
            return Ok(new BaseResponseModel<List<ChatMessageDTO>>(
                StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS,
                data: message,
                message: "Messages founded!"));
        }

        [HttpGet("chatbox/{id}")]
        public async Task<IActionResult> GetAllMessagesByChatBoxId(int id)
        {
            var message = await chatService.GetAllChatMessageByChatBoxId(id);
            if (message == null)
            {
                return NotFound(
                  new BaseResponseModel<List<ChatMessageDTO>>(
                  StatusCodes.Status404NotFound,
                  code: ResponseCodeConstants.FAILED,
                  data: message,
                  message: "Null")
                );
            }
            return Ok(
                new BaseResponseModel<List<ChatMessageDTO>>(
                    StatusCodes.Status404NotFound,
                    code: ResponseCodeConstants.FAILED,
                    data: message,
                    message: "Null"));
        }
    }
}
