using Telesignal.Common.Database.EntityFramework;
using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Sample.Interfaces;

namespace Telesignal.Sample;

public class SampleUserRepository : ISampleUserRepository
{

    private DatabaseContext _context;
    public SampleUserRepository(DatabaseContext context) {
        _context = context;
    }

    public User Find(int id) {
        throw new NotImplementedException();
    }

    public User Create(User entity) {
        throw new NotImplementedException();
    }

    public User Delete(User entity) {
        throw new NotImplementedException();
    }

    public User Delete(int id) {
        throw new NotImplementedException();
    }

    public User Update(User entity) {
        throw new NotImplementedException();
    }
}
