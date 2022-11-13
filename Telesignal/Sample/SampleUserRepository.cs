using Telesignal.Common.Database.EntityFramework;
using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Sample.Interfaces;

namespace Telesignal.Sample;

public class SampleUserRepository : ISampleUserRepository
{

    readonly private DatabaseContext _context;
    public SampleUserRepository(DatabaseContext context) {
        _context = context;
    }

    public Task<User> Create(User entity) {
        throw new NotImplementedException();
    }

    public Task<User> Delete(User entity) {
        throw new NotImplementedException();
    }

    public Task<User> Delete(int id) {
        throw new NotImplementedException();
    }

    public Task<User> Update(User entity) {
        throw new NotImplementedException();
    }

    public async Task<User> Find(string id) {
        return (await _context.Users!.FindAsync(id))!;
    }
}
