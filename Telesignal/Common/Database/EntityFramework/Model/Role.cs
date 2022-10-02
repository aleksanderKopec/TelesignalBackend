using Microsoft.AspNetCore.Identity;

namespace Telesignal.Common.Database.EntityFramework.Model;

public class Role : IdentityRole<int>, DatabaseEntity
{
    public Role() { }

    public Role(string roleName) {
        Name = roleName;
    }
}
