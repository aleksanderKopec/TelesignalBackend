using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Telesignal.Common.Database.EntityFramework;
using Telesignal.Common.Database.Repositories.Interfaces;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Database.Repositories;

public class MessageRepository : IMessageRepository
{
    readonly private DatabaseContext _context;
    readonly private IMapper _mapper;

    public MessageRepository(DatabaseContext databaseContext, IMapper mapper) {
        _context = databaseContext;
        _mapper = mapper;
    }

    public async Task<DatabaseModel.Message?> Find(int id) {
        return await _context.Messages.FindAsync(id);
    }

    public async Task<DatabaseModel.Message> Create(DatabaseModel.Message entity) {
        var createdEntity = _context.Messages.Add(entity);
        await _context.SaveChangesAsync();
        return createdEntity.Entity;
    }

    public async Task<DatabaseModel.Message> Delete(DatabaseModel.Message entity) {
        var deletedEntity = _context.Messages.Remove(entity);
        await _context.SaveChangesAsync();
        return deletedEntity.Entity;
    }

    public async Task<DatabaseModel.Message> Update(DatabaseModel.Message entity) {
        var updatedEntity = _context.Messages.Update(entity);
        await _context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task<List<DatabaseModel.Message>> GetMessages(int roomId, int pageNo, int pageSize) {
        var skip = pageNo * pageSize;
        return await _context.Messages
                             .OrderByDescending(it => it.DateAdded)
                             .Skip(skip)
                             .Take(pageSize)
                             .ToListAsync();
    }
}
