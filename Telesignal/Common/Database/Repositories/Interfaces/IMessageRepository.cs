using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Common.Interfaces;

namespace Telesignal.Common.Database.Repositories.Interfaces;

public interface IMessageRepository : IAsyncRepository<Message>
{
    Task<List<Message>> GetMessages(int roomId, int pageNo, int pageSize);
}
