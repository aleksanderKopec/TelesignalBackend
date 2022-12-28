using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Telesignal.Chat.Interfaces;
using Telesignal.Chat.Model;
using Telesignal.Common.Database.Repositories.Interfaces;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Chat;

public class ChatService : IChatService
{
    readonly private IMessageRepository _messageRepository;
    readonly private IRoomRepository _roomRepository;
    readonly private IUserRepository _userRepository;


    public ChatService(IMessageRepository messageRepository,
                       IRoomRepository roomRepository) {
        _messageRepository = messageRepository;
        _roomRepository = roomRepository;
    }

    public async Task<ActionResult<Room?>> GetRoom(int roomId) {
//        return await _roomRepository.Find(roomId);
        throw new NotImplementedException();
    }

    public async Task<ActionResult<Room>> CreateRoom(Room room) {
//        var newRoom = new DatabaseModel.Room()
//        return await _roomRepository.Create(room);
        throw new NotImplementedException();
    }

    public async Task<ActionResult<DatabaseModel.Message>> AddMessage(MessageWrapper message) {
        var author = await _userRepository.Find(message.AuthorId);
        var room = await _roomRepository.Find(message.RoomId);
        var messageModel = new DatabaseModel.Message {
            Author = author,
            Content = message.MessageContent.Value,
            KeyMapJson = JsonSerializer.Serialize(message.MessageContent.KeyMap),
            Room = room
        };
        return await _messageRepository.Create(messageModel);
    }

    public async Task<ActionResult<Room>> DeleteRoom(Room room) {
//        return await _roomRepository.Delete(room);
        throw new NotImplementedException();
    }

    public async Task<ActionResult<List<DatabaseModel.Message>>> GetMessages(int roomId, int pageNo, int pageSize) {
        return await _messageRepository.GetMessages(roomId, pageNo, pageSize);
    }
}
