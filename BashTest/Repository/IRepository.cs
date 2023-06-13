using BashTest.Model;
using System.Linq.Expressions;

namespace BashTest.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> Save();
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter = null,
                              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                              int? top = null,
                              int? skip = null,
                              params string[] includeProperties);
    }
}
