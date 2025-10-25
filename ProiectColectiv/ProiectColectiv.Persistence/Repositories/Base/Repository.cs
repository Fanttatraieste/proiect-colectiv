using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Domain.Repositories;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProiectColectiv.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ProiectColectivDbContext DbContext;

        public Repository(ProiectColectivDbContext dbContext) => DbContext = dbContext;

        public void Add(T entity) => DbContext.Add(entity);

        public IQueryable<T> Query(Expression<Func<T, bool>> whereFilter = null)
        {
            DbSet<T> query = DbContext.Set<T>();
            return whereFilter != null ? query.Where(whereFilter) : query;
        }

        public void Remove(T entity) => DbContext.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => DbContext.RemoveRange(entities);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await DbContext.SaveChangesAsync(cancellationToken);
    }
}
