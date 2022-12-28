using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Telesignal.Common.Database.EntityFramework;
using Telesignal.Common.Database.Repositories.Interfaces;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Database.Repositories;

public class UserRepository : IUserRepository
{
    readonly private DatabaseContext _context;
    readonly private IMapper _mapper;

    public UserRepository(DatabaseContext databaseContext, IMapper mapper) {
        _context = databaseContext;
        _mapper = mapper;
    }

    public async Task<DatabaseModel.User?> Find(int id) {
        return await _context.Users.FindAsync(id);
    }

    public async Task<DatabaseModel.User> Create(DatabaseModel.User entity) {
        var createdEntity = _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return createdEntity.Entity;
    }

    public async Task<DatabaseModel.User> Delete(DatabaseModel.User entity) {
        var deletedEntity = _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
        return deletedEntity.Entity;
    }

    public async Task<DatabaseModel.User> Update(DatabaseModel.User entity) {
        var updatedEntity = _context.Users.Update(entity);
        await _context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task<DatabaseModel.User?> FindByUsername(string username) {
        return await _context.Users
                             .Where(it => it.Username == username)
                             .FirstOrDefaultAsync();
    }
}
