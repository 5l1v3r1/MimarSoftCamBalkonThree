using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Entities.Auth
{
    [Index(nameof(UserId), Name = "IX_AspNetUserClaims_UserId")]
    public partial class AspNetUserClaim : IdentityUserClaim<string>, IEntity
    {
    }
}