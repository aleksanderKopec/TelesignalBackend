using AutoMapper;
using Telesignal.Common.Database.EntityFramework;
using Telesignal.Common.Database.Repositories.Interfaces;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Database.Repositories;

public class ProfileRepository : IProfileRepository
{
    readonly private DatabaseContext _context;
    readonly private IMapper _mapper;

    public ProfileRepository(DatabaseContext databaseContext, IMapper mapper) {
        _context = databaseContext;
        _mapper = mapper;
    }

    public async Task<DatabaseModel.Profile?> Find(int id) {
        return await _context.Profiles.FindAsync(id);
    }

    public async Task<DatabaseModel.Profile> Create(DatabaseModel.Profile entity) {
        var createdEntity = _context.Profiles.Add(entity);
        await _context.SaveChangesAsync();
        return createdEntity.Entity;
    }

    public async Task<DatabaseModel.Profile> Delete(DatabaseModel.Profile entity) {
        var deletedEntity = _context.Profiles.Remove(entity);
        await _context.SaveChangesAsync();
        return deletedEntity.Entity;
    }

    public async Task<DatabaseModel.Profile> Update(DatabaseModel.Profile entity) {
        var updatedEntity = _context.Profiles.Update(entity);
        await _context.SaveChangesAsync();
        return updatedEntity.Entity;
    }
}
