using AutoMapper;
using Telesignal.Auth.Model;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Mappers;

public class AuthUserMapperProfile : Profile
{
    public AuthUserMapperProfile() {
        CreateMap<User, DatabaseModel.User>();
        CreateMap<Email, DatabaseModel.Email>();
    }
}
