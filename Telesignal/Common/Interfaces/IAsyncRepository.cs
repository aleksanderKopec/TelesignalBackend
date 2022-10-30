using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Interfaces;

public interface IAsyncRepository<T> where T : IDatabaseEntity
{
    Task<T> Find(string id);

    Task<T> Create(T entity);

    Task<T> Delete(T entity);

    Task<T> Delete(int id);

    Task<T> Update(T entity);
}
