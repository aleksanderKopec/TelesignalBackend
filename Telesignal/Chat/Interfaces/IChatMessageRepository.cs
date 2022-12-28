using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Common.Interfaces;

namespace Telesignal.Chat.Interfaces;

public interface IChatMessageRepository : IAsyncRepository<Message>
{
    Task<List<Message>> GetPaginatedMessages(int roomId, int pageSize, int pageNo);
}
