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

        public User? Delete(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
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
        /// Used to find users by attributes other than Id.
        /// To get user by Id use Get().
        /// </summary>
        /// <param name="searchCriteria">Dictionary containing search parameters.</param>
        /// <returns>List of users matching search criteria</returns>
        public List<User> Find(Dictionary<UserAttributes, object> searchCriteria)
        {
            var user = db.Users.AsQueryable();
            if (searchCriteria.ContainsKey(UserAttributes.Email))
                user = user.Where(u => u.Email == searchCriteria[UserAttributes.Email]);
            if (searchCriteria.ContainsKey(UserAttributes.Profile))
                user = user.Where(u => u.Profile == searchCriteria[UserAttributes.Profile]);
            if (searchCriteria.ContainsKey(UserAttributes.Contacts))
                user = user.Where(u => u.Contacts == searchCriteria[UserAttributes.Contacts]);
            return user.ToList();
        }



    }
}
