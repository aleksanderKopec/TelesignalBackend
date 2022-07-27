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

        //public User Add(
        //    Email email,
        //    string password,
        //    Profile? profile,
        //    List<User>? contacts)
        //{
        //    Random random = new Random();
        //    if (profile == null)
        //    {
        //        profile = new Profile { Name = random.Next(1000, 9999).ToString() };
        //    }
        //    if (contacts == null)
        //    {
        //        contacts = new List<User>();
        //    }
        //    var user = new User
        //    {
        //        Email = email,
        //        Password = password,
        //        Profile = profile,
        //        Contacts = contacts
        //    };
        //    Add(user);
        //    return user;
        //}

        /// <summary>
        /// Used to find users by 
        /// </summary>
        /// <param name="searchUser"></param>
        /// <returns></returns>
        public List<User> Find(Dictionary<UserAttributes, object> searchUser)
        {
            if (searchUser.ContainsKey(UserAttributes.Id))
                return Get(searchUser[UserAttributes.Id]).To
            var user = db.Users.AsQueryable();
            if (searchUser.ContainsKey(UserAttributes.Email))
                user = user.Where(u => u.Email == searchUser[UserAttributes.Email]);
            if (searchUser.ContainsKey(UserAttributes.Profile))
                user = user.Where(u => u.Profile == searchUser[UserAttributes.Profile]);
            if (searchUser.ContainsKey(UserAttributes.Contacts))
                user = user.Where(u => u.Contacts == searchUser[UserAttributes.Contacts]);
        }



    }
}
