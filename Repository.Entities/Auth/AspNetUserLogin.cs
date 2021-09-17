using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Entities.Auth
{
    [Index(nameof(UserId), Name = "IX_AspNetUserLogins_UserId")]
    public partial class AspNetUserLogin : IdentityUserLogin<string>, IEntity
    {
    }
}