using Microsoft.EntityFrameworkCore;
using Repository.DataAccess.Concrete.EFCore.DbContexts;

namespace Repository.Business
{
    public class ApplicationContext : RepositoryContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }
    }
}