using IBlog.Core.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace IBlog.DataAccess.Repository
{
    public interface IRepositories<TEntity> where TEntity : class, IEntity
    {
        public Task AsyncAdd(TEntity entity);
        public Task AsyncUpdate(TEntity entity);
        public Task AsyncDelete(Expression<Func<TEntity, bool>> where);
        public Task<TEntity> AsyncFirst(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include);

        public Task<TEntity> IncludeMultiple(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        public Task<IList<TEntity>> AsyncGetAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] include);
    }
}
