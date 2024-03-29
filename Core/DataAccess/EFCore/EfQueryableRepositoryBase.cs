﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DataAccess.EFCore
{
    public class EfQueryableRepositoryBase<T> : IQueryableRepository<T>
        where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _entities;

        public EfQueryableRepositoryBase(DbContext dbContext, DbSet<T> entities)
        {
            _dbContext = dbContext;
            _entities = entities;
        }

        public IQueryable<T> Table => Entities;

        public Task<IQueryable<T>> TableAsync => EntitiesAsync;

        protected virtual DbSet<T> Entities => _entities ??= _dbContext.Set<T>();

        protected virtual Task<IQueryable<T>> EntitiesAsync =>
            Task.FromResult<IQueryable<T>>(_entities ??= _dbContext.Set<T>());
    }
}