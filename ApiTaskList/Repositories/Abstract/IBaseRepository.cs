using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskList2.Entities;

namespace TaskList2.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAllPagination(int Page,int sizePage);
        IEnumerable<T> GetAllById(Guid Id);
        T GetSingle(Guid Id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        Guid Create(T entity); // создание объекта
        void UpdateById(Guid Id, T entity); // обновление объекта
        void DeleteById(Guid Id); // удаление объекта по id
        void SaveChange();
    }
}
