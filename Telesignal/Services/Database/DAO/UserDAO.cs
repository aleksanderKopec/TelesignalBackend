using Microsoft.EntityFrameworkCore;
using Telesignal.Services.Database.EF;
using Telesignal.Services.Database.EF.Models;

namespace Telesignal.Services.Database.DAO
{
    public class UserDAO : DataAccessObject<User>, IDataAccessObject<User>
    {
        public UserDAO(DatabaseContext context) : base(context){ }

        protected override void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        protected override void Delete(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User Delete(int id)
        {
            var user = db.Users.Find(id);
            Delete(user);
            return user;
        }

        public User? Get(int id)
        {
            var user = db.Users.Find(id);
            return user;
        }

        public User Add(
            Email email,
            string password,
            Profile? profile,
            List<User>? contacts)
        {
            Random random = new Random();
            if (profile == null)
            {
                profile = new Profile { Name = random.Next(1000, 9999).ToString() };
            }
            if (contacts == null)
            {
                contacts = new List<User>();
            }
            var user = new User
            {
                Email = email,
                Password = password,
                Profile = profile,
                Contacts = contacts
            };
            Add(user);
            return user;
        }

        public 



    }
}
