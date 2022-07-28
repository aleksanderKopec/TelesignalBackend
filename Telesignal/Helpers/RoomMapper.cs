using DatabaseRoom = Telesignal.Services.Database.EF.Models.Room;
using Telesignal.Services.Chat.Components;
using AutoMapper;

namespace Telesignal.Helpers
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
