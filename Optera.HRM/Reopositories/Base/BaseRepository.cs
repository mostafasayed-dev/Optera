using Microsoft.EntityFrameworkCore;
using Optera.Shared.Domain;
using Optera.Shared.Interface;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Optera.HRM.Reopositories.Base
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        private readonly AppDbContext appDbContext;
        private readonly DbSet<TModel> dbSet;

        public BaseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.dbSet = this.appDbContext.Set<TModel>();
        }

        public virtual IQueryable<TModel> GetAll()
        {
            return dbSet.AsNoTracking();
        }

        public virtual async Task<TModel?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task AddAsync(TModel entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual void Update(TModel entity)
        {
            dbSet.Update(entity);
        }

        public virtual void Remove(TModel entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return await appDbContext.SaveChangesAsync() > 0;
        }
    }
}
