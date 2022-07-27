using Telesignal.Services.Database.EF;
using Telesignal.Services.Database.EF.Models;

namespace Telesignal.Services.Database.DAO
{
    abstract public class DataAccessObject<T> where T : DatabaseEntity
    {
        protected DatabaseContext db { get; init; }
        protected abstract void Add(T entity);
        protected abstract void Delete(T entity);
        protected DataAccessObject(DatabaseContext db)
        {
            this.db = db;
        }
    }

    public interface IDataAccessObject<T> where T : DatabaseEntity
    {
        public T Delete(int id);
        public T? Get(int id);
        public List<T> Find(Dictionary<UserAttributes, object> searchDict);

    }

    public enum UserAttributes
    {
        Id,
        Email,
        Profile,
        Contacts,
    }
}
