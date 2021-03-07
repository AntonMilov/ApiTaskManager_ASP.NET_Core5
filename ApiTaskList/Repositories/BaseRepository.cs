using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskList2.Context;
using TaskList2.Entities;
using TaskList2.Repositories.Abstract;

namespace TaskList2.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase, new()
    {
        protected DataBaseContext context;
        public BaseRepository(DataBaseContext context)
        {
            this.context = context;
        }
        public virtual IEnumerable<T> GetAllPagination(int Page, int sisePage)
        {
            IQueryable<T> query = context.Set<T>();
            query = query.Skip((Page - 1) * sisePage).Take(sisePage);
            return query.AsEnumerable();
        }
        public virtual IEnumerable<T> GetAllById(Guid Id)
        {
            IQueryable<T> query = context.Set<T>();
            query = query.Where(p => p.Id==Id).AsQueryable();
            return query.AsEnumerable();
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = context.Set<T>();
            query = query.Where(expression).AsQueryable();
            return query.AsEnumerable();
        }
        public T GetSingle(Guid id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }
        public virtual Guid Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return (entity.Id);
        }
        public virtual void UpdateById(Guid Id,T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
           // context.Entry<T>(entity).State = EntityState.Modified;
           // context.SaveChangesAsync();
        }
        public void SaveChange()
        {
           context.SaveChangesAsync();
        }
        public virtual void DeleteById(Guid Id)
        {
            var a = context.Set<T>().Where(p => p.Id==Id).FirstOrDefault();
            EntityEntry dbEntityEntry = context.Entry<T>(a);
            dbEntityEntry.State = EntityState.Deleted;
            context.SaveChangesAsync();
        }
    }
}
