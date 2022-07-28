using Microsoft.EntityFrameworkCore;
using Telesignal.Services.Database.EF;
using Telesignal.Services.Database.EF.Models;

namespace Telesignal.Services.Database.DAO
{
    public class ProfileDAO : DataAccessObject<Profile>, IDataAccessObject<Profile>
    {
        public ProfileDAO(DatabaseContext context) : base(context) { }

        protected override void Add(Profile profile)
        {
            db.Profiles.Add(profile);
            db.SaveChanges();
        }

        protected override void Delete(Profile profile)
        {
            db.Profiles.Remove(profile);
            db.SaveChanges();
        }

        public Profile? Delete(int id)
        {
            var profile = db.Profiles.Find(id);
            if (profile != null)
                Delete(profile);
            return profile;
        }

        public Profile? Get(int id)
        {
            var profile = db.Profiles.Find(id);
            return profile;
        }

    }
}
