using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telesignal.Chat.Interfaces;
using Telesignal.Chat.Model;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Chat;

[ApiController]
[Authorize]
[Route("/chat")]
public class SampleController : ControllerBase
{
    readonly private IChatService _chatService;

    public SampleController(IChatService chatService) {
        _chatService = chatService;
    }

    [HttpGet("/room/{roomId:int}")]
    public async Task<ActionResult<Room?>> GetRoom(int roomId) {
        return await _chatService.GetRoom(roomId);
    }

    [HttpPut("/room")]
    public async Task<ActionResult<Room>> CreateRoom(Room room) {
        return await _chatService.CreateRoom(room);
    }

    [HttpDelete("/room/{roomId:int}")]
    public string DeleteRoom() {
        return "Delete room";
    }

    [HttpPost("/room/{roomId:int}")]
    public string ModifyRoom() {
        return "Hello world";
    }
}
