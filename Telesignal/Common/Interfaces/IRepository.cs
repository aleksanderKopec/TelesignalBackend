using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Interfaces
{
    public interface IRepository<T> where T: DatabaseEntity
    {
        T Find(int id);

        T Create(T entity);

        T Delete(T entity);

        T Delete(int id);

        T Update(T entity);
    }
}