using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Entities.Auth
{
    [Index(nameof(RoleId), Name = "IX_AspNetUserRole_RoleId")]
    public partial class AspNetUserRole : IdentityUserRole<string>, IEntity
    {
    }
}