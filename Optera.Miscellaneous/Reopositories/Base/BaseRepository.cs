using Microsoft.EntityFrameworkCore;
using Optera.Miscellaneous.Models.Base;
using Optera.Shared.Identity;
using Optera.Shared.Interface;
using System.Linq.Expressions;

namespace Optera.Miscellaneous.Reopositories.Base
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        private readonly AppDbContext appDbContext;
        private readonly DbSet<TModel> dbSet;
        private readonly ICurrentUserContext currentUserContext;

        public BaseRepository(AppDbContext appDbContext, ICurrentUserContext currentUserContext)
        {
            this.appDbContext = appDbContext;
            this.dbSet = this.appDbContext.Set<TModel>();
            this.currentUserContext = currentUserContext;
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
            entity.Creator = entity.Updater = currentUserContext.UserId;
            await dbSet.AddAsync(entity);
        }

        public virtual void Update(TModel entity)
        {
            entity.Updater = currentUserContext.UserId;
            entity.UpdatedAt = DateTime.UtcNow;
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
