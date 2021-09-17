using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Entities.Auth
{
    [Index(nameof(RoleId), Name = "IX_AspNetRoleClaims_RoleId")]
    public partial class AspNetRoleClaim : IdentityRoleClaim<string>, IEntity
    {
    }
}