using Telesignal.Services.Database.EF;
using Telesignal.Services.Database.EF.Models;

namespace Telesignal.Services.Database.DAO
{
    public class RoomDAO : DataAccessObject<Room>, IDataAccessObject<Room>
    {
        public RoomDAO(DatabaseContext context) : base(context) { }

        protected override void Add(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        protected override void Delete(Room room)
        {
            db.Rooms.Remove(room);
            db.SaveChanges();
        }

        public Room? Delete(int id)
        {
            var room = db.Rooms.Find(id);
            if (room != null)
                Delete(room);
            return room;
        }

        public Room? Get(int id)
        {
            var room = db.Rooms.Find(id);
            return room;
        }

    }
}
