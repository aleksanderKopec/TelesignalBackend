using DatabaseUser = Telesignal.Common.Database.EntityFramework.Model.User;
using Telesignal.Services.Chat.Components;
using AutoMapper;
using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Mappers
{
    /// <summary>
    /// Singleton mapper for user entities.
    /// </summary>
    internal sealed class UserMapper : DatabaseMapper<DatabaseUser, User>
    {
        private UserMapper() : base() { }

        private static UserMapper? _instance;

        public static UserMapper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserMapper();
            }
            return _instance;
        }

    }
}
