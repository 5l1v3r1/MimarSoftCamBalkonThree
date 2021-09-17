using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Repository.Entities.Auth
{
    public partial class AspNetUserToken : IdentityUserToken<string>, IEntity
    {
    }
}