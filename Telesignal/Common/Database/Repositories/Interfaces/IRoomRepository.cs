using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Common.Interfaces;

namespace Telesignal.Common.Database.Repositories.Interfaces;

public interface IRoomRepository : IAsyncRepository<Room>
{
    Task<Room> FindByRoomName(string roomName);
}
