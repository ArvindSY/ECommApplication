using ECommerceDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDemo.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ECommerceDemoContext RepositoryPatternDemoContext;

        public Repository(ECommerceDemoContext repositoryPatternDemoContext)
        {
            RepositoryPatternDemoContext = repositoryPatternDemoContext;
        }

        public IQueryable<TEntity> GetAllProduct()
        {
            try
            {
                return RepositoryPatternDemoContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
