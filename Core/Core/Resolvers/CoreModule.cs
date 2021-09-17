using Core.CrossCutting.Caching;
using Core.DataAccess;
using Core.DataAccess.EFCore;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Core.Resolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));
            services.AddScoped(typeof(IQueryableRepository<>), typeof(EfQueryableRepositoryBase<>));
            services.AddScoped(typeof(IViewRepository<>), typeof(EfViewRepositoryBase<,>));

            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}