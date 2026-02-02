using System.Linq.Expressions;

namespace Optera.Shared.Interface
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        public IQueryable<TModel> GetAll();
        public Task<TModel?> GetByIdAsync(Ulid id);
        public Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate);
        public Task AddAsync(TModel entity);
        public void Update(TModel entity);
        public void Remove(TModel entity);
        public Task<bool> SaveChangesAsync();
    }
}
