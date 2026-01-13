using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces.Base
{
    public interface IBaseRepository<TModel>
    {
        public void Add(TModel entity);
        public void AddRange(ICollection<TModel> entities);
        public void Update(TModel entity);
        public void Delete(TModel entity);
        public IQueryable<TModel> Get();
        public IQueryable<TModel> GetByStatus(string status);
        public IQueryable<TModel> GetById(long Id);
        public Task<ICollection<TModel>> GetAsync();
        public Task<ICollection<TModel>> GetByStatusAsync(string status);
        public Task<TModel> GetByIdAsync(long id);
        public Task<ServiceResponse<bool>> SaveChangesAsync();
    }
}
