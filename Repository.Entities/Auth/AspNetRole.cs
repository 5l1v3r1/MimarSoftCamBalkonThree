using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Repository.Entities.Auth
{
    public partial class AspNetRole : IdentityRole<string>, IEntity
    {
    }
}