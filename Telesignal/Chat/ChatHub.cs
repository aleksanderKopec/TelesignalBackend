using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using Telesignal.Chat.Model;
using Telesignal.Chat.Model.Message;
using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Common.Database.Repositories.Interfaces;
using Room = Telesignal.Common.Database.EntityFramework.Model.Room;

namespace Telesignal.Chat;

[Authorize]
public class ChatHub : Hub
{
    readonly private IMessageRepository _messageRepository;
    readonly private IRoomRepository _roomRepository;
    readonly private IUserRepository _userRepository;

    public ChatHub(IMessageRepository messageRepository, IRoomRepository roomRepository,
                   IUserRepository userRepository) {
        _messageRepository = messageRepository;
        _roomRepository = roomRepository;
        _userRepository = userRepository;
    }

    public async Task SendMessage(MessageWrapper message) {
        Log.Information("Got message: ${Message}, with key map: ${KeyMap}", message, message.KeyMap);
        var model = new Message {
            Author = await _userRepository.Find(int.Parse(message.AuthorId)),
            Content = message.EncryptedMessage,
            DateAdded = DateTime.Now,
            KeyMapJson = JsonSerializer.Serialize(message.KeyMap),
            Room = await _roomRepository.Find(int.Parse(message.RoomId))
        };
        await _messageRepository.Create(model);
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task ConnectToRoom(string roomName, string userId) {
        Log.Information("User: ${UserId} attempting to connect to room: ${RoomName}", userId, roomName);
        var room = await _roomRepository.FindByRoomName(roomName);
        var user = await _userRepository.Find(int.Parse(userId));
        if (room == null) {
//            await SendError();
            return;
        }
        room.Members.Add(user!);
        var keyMap = GetRoomKeyMap(room);
        await _roomRepository.Update(room);
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        await Clients.Caller.SendAsync("ConnectToRoom", room.Id);
        await Clients.Group(roomName).SendAsync("GetRoomKeyMap", room.Id.ToString(), keyMap);
    }

    public async Task GetRoomKeyMap(string roomId) {
        var room = await _roomRepository.Find(int.Parse(roomId));
        var keyMap = GetRoomKeyMap(room);
        Log.Information("KeyMap: ${KeyMap}", keyMap.ToString());
        await Clients.Caller.SendAsync("GetRoomKeyMap", room.Id.ToString(), keyMap);
    }

    public async Task GetAllRoomMembers(string roomId) {
        var room = await _roomRepository.Find(int.Parse(roomId));
        var roomMembers = room!.Members.ToList().ConvertAll(it => it.Username);
        await Clients.Caller.SendAsync("GetAllRoomMembers", roomMembers);
    }

    private KeyMap GetRoomKeyMap(Room room) {
        var keyMap = new KeyMap();
        room.Members.ToList().ForEach(user => {
            keyMap.Add(user.Username, Convert.ToBase64String(user.PublicKey));
        });
        return keyMap;
    }

//    private Task SendError() {
//    }
}
