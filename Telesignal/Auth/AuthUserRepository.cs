using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Telesignal.Auth.Interfaces;
using Telesignal.Auth.Model;
using Telesignal.Common.Database.EntityFramework;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth;

public class AuthUserRepository : IAuthUserRepository
{
    readonly private DatabaseContext _databaseContext;
    readonly private IMapper _mapper;

    public AuthUserRepository(DatabaseContext databaseContext, IMapper mapper) {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public async Task<bool> AddUser(User authUser) {
        var databaseUser = _mapper.Map<DatabaseModel.User>(authUser);
        return await AddUser(databaseUser);
    }

    public async Task<DatabaseModel.User?> FindUserByName(string username) {
        return await (from user in _databaseContext.Users
                      where user.Username == username
                      select user).SingleOrDefaultAsync();
    }

    public async Task<bool> AddUser(DatabaseModel.User databaseUser) {
        await _databaseContext.Users.AddAsync(databaseUser);
        await _databaseContext.SaveChangesAsync();
        return true;
    }
}
