using Core.Business;
using Repository.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Business.Abstract
{
    public interface IAdminService : IServiceRepository<AspNetUserRole>// IServiceRepository<AspNetUser>, IServiceRepository<AspNetRole>,
    {
        IList<AspNetUser> GetListUsers(Expression<Func<AspNetUser, bool>> filter = null);

        IList<AspNetRole> GetListRoles(Expression<Func<AspNetRole, bool>> filter = null);

        List<AspNetUser> GetAllUsers();

        List<AspNetRole> GetAllRoles();

        List<AspNetUserRole> GetAllUserRoles();

    }
}