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
                       IRoomRepository roomRepository, IUserRepository userRepository) {
        _messageRepository = messageRepository;
        _roomRepository = roomRepository;
        _userRepository = userRepository;
    }

    public async Task<ActionResult<Room?>> GetRoom(int roomId) {
        var foundRoom = await _roomRepository.Find(roomId);
        return ModelToRoom(foundRoom!);
    }

    public async Task<ActionResult<Room>> CreateRoom(Room room) {
        var savedRoom = await _roomRepository.Create(await RoomToModel(room));
        return ModelToRoom(savedRoom);
    }

    public async Task<ActionResult<DatabaseModel.Message>> AddMessage(MessageWrapper message) {
        var author = await _userRepository.Find(int.Parse(message.AuthorId));
        var room = await _roomRepository.Find(int.Parse(message.RoomId));
        var messageModel = new DatabaseModel.Message {
            Author = author,
            Content = message.EncryptedMessage,
            KeyMapJson = JsonSerializer.Serialize(message.KeyMap),
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

    private async Task<DatabaseModel.Room> RoomToModel(Room room) {
        var foundUser = await _userRepository.FindByUsername(room.Author);
        return new DatabaseModel.Room {
            Name = room.Name,
            Admins = new HashSet<DatabaseModel.User> { foundUser },
            Members = new HashSet<DatabaseModel.User> { foundUser },
            Messages = new List<DatabaseModel.Message>()
        };
    }

    private Room ModelToRoom(DatabaseModel.Room model) {
        return new Room {
            RoomId = model.Id,
            Author = model.Admins.First().Username,
            Name = model.Name
        };
    }
}
