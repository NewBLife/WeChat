using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.Extensions;

namespace Aurore.Framework.Data.Core
{
   public class EfRepository<TEntity>:IRepository<TEntity> where TEntity:class
   {
       
       protected readonly DbContext Context;
       private  DbSet<TEntity> _entities;

       public EfRepository(DbContext context)
       {
           Context = context;	
	   }

       public virtual IQueryable<TEntity> Table => Entities;

       protected DbSet<TEntity> Entities => _entities ?? (_entities = Context.Set<TEntity>());


       public TEntity GetById(object id)
       {
           return Entities.Find(id);
       }

      
       public void Add(TEntity entity)
       {
           if (entity == null)
               throw new ArgumentNullException(nameof(entity));
           Entities.Add(entity);
           Context.SaveChanges();
       }

       public void AddOrUpdate(TEntity entity)
       {
           if (entity == null)
               throw new ArgumentNullException(nameof(entity));
           var entry = Context.Entry(entity);
           if (entry.State == EntityState.Detached)
           {
               entry.State = EntityState.Modified;
           }
           Entities.AddOrUpdate(entity);
           Context.SaveChanges();
       }

       public void AddRange(IList<TEntity> list)
       {
           if (list == null)
               throw new ArgumentNullException(nameof(list));
           //批量操作前 关闭自动检测变化功能
           Context.Configuration.AutoDetectChangesEnabled = false;
           foreach (var e in list)
           {
               Entities.Add(e);
           }
           Context.Configuration.AutoDetectChangesEnabled = true;
           Context.SaveChanges();
       }

       public void Update(TEntity entity)
       {
           var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            Context.SaveChanges();          
       }

       public void Update(Expression<Func<TEntity, bool>> expression,Expression<Func<TEntity, TEntity>> updateExpression)
       {
           Entities.Where(expression).Update(updateExpression);
       }


       public void Delete(TEntity entity)
       {
           if (entity == null)
               throw new ArgumentNullException(nameof(entity));
           Entities.Remove(entity);
           Context.SaveChanges();
       }

       public void Delete(Expression<Func<TEntity, bool>> expression)
       {
           Entities.Where(expression).Delete();
       }

       public void Delete(object id)
       {
           var item = GetById(id);
           if (item != null)
           {
               Context.Entry(item).State = EntityState.Deleted;
           }
           Context.SaveChanges();
       }

   }
}
