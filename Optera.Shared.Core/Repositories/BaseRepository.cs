using Microsoft.EntityFrameworkCore;
using Optera.Shared.Core.Domain;
using Optera.Shared.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Core.Repositories
{
    /// <summary>
    /// Base repository implementation for common CRUD operations
    /// </summary>
    /// <typeparam name="TModel">Entity type that inherits from BaseModel</typeparam>
    /// <typeparam name="TContext">DbContext type</typeparam>
    public class BaseRepository<TModel, TContext> : IBaseRepository<TModel>
        where TModel : BaseModel
        where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TModel> DbSet;
        private readonly ICurrentUserContext currentUserContext;

        public BaseRepository(TContext context,
            ICurrentUserContext currentUserContext)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = Context.Set<TModel>();
            this.currentUserContext = currentUserContext;
        }

        #region Query Operations

        /// <summary>
        /// Gets all entities without tracking (read-only)
        /// </summary>
        public virtual IQueryable<TModel> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        /// <summary>
        /// Gets all entities with tracking enabled (for updates)
        /// </summary>
        public virtual IQueryable<TModel> GetAllTracked()
        {
            return DbSet.AsQueryable();
        }

        /// <summary>
        /// Gets entity by auto-increment Id
        /// </summary>
        public virtual async Task<TModel?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <summary>
        /// Gets entity by RowKey (ULID)
        /// </summary>
        public virtual async Task<TModel?> GetByRowKeyAsync(Ulid rowKey, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RowKey == rowKey, cancellationToken);
        }

        /// <summary>
        /// Finds entities matching the predicate
        /// </summary>
        public virtual async Task<IEnumerable<TModel>> FindAsync(
            Expression<Func<TModel, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await DbSet
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets first entity matching the predicate or null
        /// </summary>
        public virtual async Task<TModel?> FirstOrDefaultAsync(
            Expression<Func<TModel, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// Checks if any entity matches the predicate
        /// </summary>
        public virtual async Task<bool> AnyAsync(
            Expression<Func<TModel, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await DbSet.AnyAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// Counts entities matching the predicate (or all if predicate is null)
        /// </summary>
        public virtual async Task<int> CountAsync(
            Expression<Func<TModel, bool>>? predicate = null,
            CancellationToken cancellationToken = default)
        {
            return predicate == null
                ? await DbSet.CountAsync(cancellationToken)
                : await DbSet.CountAsync(predicate, cancellationToken);
        }

        #endregion

        #region Command Operations

        /// <summary>
        /// Adds a new entity
        /// </summary>
        public virtual async Task AddAsync(TModel entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.Creator = currentUserContext.UserName;
            entity.Updater = currentUserContext.UserName;

            await DbSet.AddAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Adds multiple entities
        /// </summary>
        public virtual async Task AddRangeAsync(IEnumerable<TModel> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                entity.Creator = currentUserContext.UserName;
                entity.Updater = currentUserContext.UserName;
            }

            await DbSet.AddRangeAsync(entities, cancellationToken);
        }

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        public virtual void Update(TModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.Updater = currentUserContext.UserName;
            DbSet.Update(entity);
        }

        /// <summary>
        /// Updates multiple entities
        /// </summary>
        public virtual void UpdateRange(IEnumerable<TModel> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                entity.Updater = currentUserContext.UserName;
            }

            DbSet.UpdateRange(entities);
        }

        /// <summary>
        /// Hard deletes an entity from database
        /// </summary>
        public virtual void Remove(TModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbSet.Remove(entity);
        }

        /// <summary>
        /// Hard deletes multiple entities from database
        /// </summary>
        public virtual void RemoveRange(IEnumerable<TModel> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Soft deletes an entity by changing its Status
        /// </summary>
        public virtual void SoftDelete(TModel entity, string status = "Closed")
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.Status = status;
            entity.Updater = currentUserContext.UserName;
            Update(entity);
        }

        /// <summary>
        /// Soft deletes multiple entities by changing their Status
        /// </summary>
        public virtual void SoftDeleteRange(IEnumerable<TModel> entities, string status = "Closed")
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                entity.Status = status;
                entity.Updater = currentUserContext.UserName;
            }
            UpdateRange(entities);
        }

        #endregion

        #region Save Operations

        /// <summary>
        /// Saves changes and returns true if any rows were affected
        /// </summary>
        public virtual async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await Context.SaveChangesAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Saves changes and returns the number of rows affected
        /// </summary>
        public virtual async Task<int> SaveChangesCountAsync(CancellationToken cancellationToken = default)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
