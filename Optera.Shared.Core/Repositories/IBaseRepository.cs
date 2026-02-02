using System.Linq.Expressions;

namespace Optera.Shared.Core.Repositories
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        // Query operations (AsNoTracking by default for read operations)
        IQueryable<TModel> GetAll();
        IQueryable<TModel> GetAllTracked();
        Task<TModel?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<TModel?> GetByRowKeyAsync(Ulid rowKey, CancellationToken cancellationToken = default);
        Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TModel?> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TModel, bool>>? predicate = null, CancellationToken cancellationToken = default);
        Task AddAsync(TModel entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TModel> entities, CancellationToken cancellationToken = default);
        void Update(TModel entity);
        void UpdateRange(IEnumerable<TModel> entities);
        void Remove(TModel entity);
        void RemoveRange(IEnumerable<TModel> entities);
        void SoftDelete(TModel entity, string status = "Deleted");
        void SoftDeleteRange(IEnumerable<TModel> entities, string status = "Deleted");
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesCountAsync(CancellationToken cancellationToken = default);
    }
}
