using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Telesignal.Common.Database.EntityFramework;
using Telesignal.Common.Database.Repositories.Interfaces;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Database.Repositories;

public class RoomRepository : IRoomRepository
{
    readonly private DatabaseContext _context;
    readonly private IMapper _mapper;

    public RoomRepository(DatabaseContext databaseContext, IMapper mapper) {
        _context = databaseContext;
        _mapper = mapper;
    }

    public async Task<DatabaseModel.Room?> Find(int id) {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task<DatabaseModel.Room> Create(DatabaseModel.Room entity) {
        var createdEntity = _context.Rooms.Add(entity);
        await _context.SaveChangesAsync();
        return createdEntity.Entity;
    }

    public async Task<DatabaseModel.Room> Delete(DatabaseModel.Room entity) {
        var deletedEntity = _context.Rooms.Remove(entity);
        await _context.SaveChangesAsync();
        return deletedEntity.Entity;
    }

    public async Task<DatabaseModel.Room> Update(DatabaseModel.Room entity) {
        var updatedEntity = _context.Rooms.Update(entity);
        await _context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task<DatabaseModel.Room?> FindByRoomName(string roomName) {
        return await _context.Rooms
                             .Where(it => it.Name == roomName)
                             .FirstOrDefaultAsync();
    }
}
