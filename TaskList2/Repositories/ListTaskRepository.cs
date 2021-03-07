using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Context;
using TaskList2.Entities;
using TaskList2.Repositories.Abstract;

namespace TaskList2.Repositories
{
    public class ListTaskRepository : BaseRepository<ListTask>, IListTaskRepository
    {
        public ListTaskRepository(DataBaseContext context)
             : base(context)
        {
        }
        public override void UpdateById(Guid Id, ListTask newListTask)
        {
            var listTask = context.ListsTask.Where(p => p.Id == Id).FirstOrDefault();
            listTask.Title = newListTask.Title;
            listTask.Description = newListTask.Description;
            SaveChange();
        }
        public override IEnumerable<ListTask> GetAllById(Guid Id)
        {
            IQueryable<ListTask> query = context.ListsTask;
            query = query.Where(p => p.UserId==Id).AsQueryable();
            return query.AsEnumerable();
        }
        public override void DeleteById(Guid Id)
        {
            var listTask = context.ListsTask.Where(u => u.Id == Id).FirstOrDefault();  // подгружаем данные по компаниям   
            context.Entry(listTask).Collection(p => p.Tasks).Load();
            if (listTask.Tasks.Count == 0)
            {
                EntityEntry dbEntityEntry = context.Entry(listTask);
                dbEntityEntry.State = EntityState.Deleted;
                context.SaveChangesAsync();
            }
            else throw new Exception("Список имеет задачи.Удаление не возможно");
        }
    }
}

