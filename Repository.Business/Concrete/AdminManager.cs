using Core.Business;
using Microsoft.AspNetCore.Identity;
using Repository.Business.Abstract;
using Repository.DataAccess.Concrete.EFCore.DbContexts;
using Repository.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;

        private readonly RepositoryContext _repositoryContext;

        public AdminManager()
        {
            _repositoryContext = new RepositoryContext();
        }

        // ********************************



        public IList<AspNetRole> GetRoles(int roleId)
        {
            var sorgu = from p in _repositoryContext.AspNetRoles
                        where Convert.ToInt32(p.Id) >= roleId
                        select p;
            return (IList<AspNetRole>)sorgu;
        }

        // ********************************
        public void Add(AspNetUserRole entity)
        {
            _repositoryContext.Add(entity);
            _repositoryContext.SaveChanges();
        }

        public void AddList(IList<AspNetUserRole> entities)
        {
            throw new NotImplementedException();
        }

        public void AddList_Async(IList<AspNetUserRole> entities)
        {
            throw new NotImplementedException();
        }

        public void Add_Async(AspNetUserRole entity)
        {
            _repositoryContext.AddAsync(entity);
            _repositoryContext.SaveChanges();
        }

        public void Delete(AspNetUserRole entity)
        {
            _repositoryContext.Remove(entity);
            _repositoryContext.SaveChanges();
        }

        public void DeleteList(IList<AspNetUserRole> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteList_Async(IList<AspNetUserRole> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete_Async(AspNetUserRole entity)
        {
            throw new NotImplementedException();
        }

        public List<AspNetRole> GetAllRoles()
        {
            return _repositoryContext.AspNetRoles.ToList();
        }

        public List<AspNetUserRole> GetAllUserRoles()
        {
            return _repositoryContext.AspNetUserRoles.ToList();
        }

        public List<AspNetUser> GetAllUsers()
        {
            return _repositoryContext.AspNetUsers.OrderBy(x => x.UserName).ToList();
        }

        public IList<AspNetRole> GetListRoles(Expression<Func<AspNetRole, bool>> filter = null)
        {
            return _repositoryContext.AspNetRoles.Where(filter).ToList();
        }

        public IList<AspNetUser> GetListUsers(Expression<Func<AspNetUser, bool>> filter = null)
        {
            return _repositoryContext.AspNetUsers.Where(filter).ToList();
        }
        public IList<AspNetUser> GetList_All()
        {
            throw new NotImplementedException();
        }

        public Task<IList<AspNetUser>> GetList_All_Async()
        {
            throw new NotImplementedException();
        }

        public void Update(AspNetUserRole entity)
        {
            _repositoryContext.AspNetUserRoles.Update(entity);
        }

        public void UpdateList(IList<AspNetUserRole> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateList_Async(IList<AspNetUserRole> entities)
        {
            throw new NotImplementedException();
        }

        public void Update_Async(AspNetUserRole entity)
        {
            throw new NotImplementedException();
        }

        IList<AspNetUserRole> IServiceRepository<AspNetUserRole>.GetList_All()
        {
            throw new NotImplementedException();
        }

        Task<IList<AspNetUserRole>> IServiceRepository<AspNetUserRole>.GetList_All_Async()
        {
            throw new NotImplementedException();
        }


        // ***********************************
    }
}