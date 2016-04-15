using System;
using System.Linq;
using System.Linq.Expressions;
using Aurore.Framework.Data.Core;

namespace Shop.Framework.Data
{
    public static class IRepositoryExtensions
    {

        public static IQueryable<TEntity> Get<TEntity>(this IRepository<TEntity> _repository, Expression<Func<TEntity, bool>> expression)
        {
            var q = _repository.Table.Where(expression);
            return q;
        }

        public static IQueryable<TEntity> Get<TEntity>(this IRepository<TEntity> _repository, Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order)
        {
            var query = _repository.Table;
            if (expression != null)
                query = query.Where(expression);
            if (order != null)
            {
                query = order(query);
            }

            return query;
        }


        public static long GetCount<TEntity>(this IRepository<TEntity> _repository, Expression<Func<TEntity, bool>> expression)
        {
            var q = _repository.Table;
            if (expression != null)
                q = q.Where(expression);
            long count = q.LongCount();
            return count;
        }

        public static long GetCount<TEntity>(this IRepository<TEntity> _repository)
        {
            return GetCount(_repository,null);
        }
    }
}
