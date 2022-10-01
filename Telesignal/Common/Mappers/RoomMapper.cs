using DatabaseRoom = Telesignal.Common.Database.EntityFramework.Model.Room;
using Telesignal.Services.Chat.Components;
using AutoMapper;

namespace Telesignal.Common.Mappers
{
    /// <summary>
    /// Singleton mapper for user entities.
    /// </summary>
    internal sealed class RoomMapper : DatabaseMapper<DatabaseRoom, User>
    {
        private RoomMapper() : base() { }

        private static RoomMapper? _instance;

        public static RoomMapper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RoomMapper();
            }
            return _instance;
        }

    }
}
