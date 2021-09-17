using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EFCore
{
    public static class Extensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,
            params Expression<Func<T, object>>[] includes) where T : class, IEntity, new()
        {
            if (includes != null)
                query = includes.Aggregate(query, (current, include)
                    => current.Include(include));

            return query;
        }
    }
}