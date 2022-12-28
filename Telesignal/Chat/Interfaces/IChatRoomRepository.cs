using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Common.Interfaces;

namespace Telesignal.Chat.Interfaces;

public interface IChatRoomRepository : IAsyncRepository<Room>
{
}
