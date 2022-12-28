using Microsoft.AspNetCore.Mvc;
using Telesignal.Chat.Model;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Chat.Interfaces;

public interface IChatService
{
    public Task<ActionResult<Room?>> GetRoom(int roomId);

    public Task<ActionResult<Room>> CreateRoom(Room room);

    public Task<ActionResult<Room>> DeleteRoom(Room room);

    public Task<ActionResult<List<DatabaseModel.Message>>> GetMessages(int roomId, int pageNo, int pageSize);

    public Task<ActionResult<DatabaseModel.Message>> AddMessage(MessageWrapper message);
}
