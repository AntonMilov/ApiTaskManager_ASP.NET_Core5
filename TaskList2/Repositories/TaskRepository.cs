using System;
using System.Collections.Generic;
using System.Linq;
using TaskList2.Context;
using TaskList2.Repositories.Abstract;

namespace TaskList2.Repositories
{
    public class TaskRepository : BaseRepository<Entities.Task>, ITaskRepository
    {
        public TaskRepository(DataBaseContext context)
            : base(context)
        {
        }
        public override Guid Create(Entities.Task entity)
        {
            context.Tasks.Add(entity);
            context.HistoryTasks.Add(new Entities.HistoryTask { Status = entity.Status, Date = entity.DateCreate, TaskId = entity.Id });
            context.SaveChanges(); 
            return (entity.Id);
        }
        public override void UpdateById(Guid Id, Entities.Task taskModel)
        {
            var task = context.Tasks.Where(p => p.Id == Id).FirstOrDefault();
            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.ListTaskId = taskModel.ListTaskId;
            
            context.SaveChanges();
        }
        public override IEnumerable<Entities.Task> GetAllById(Guid Id)
        {
            IQueryable<Entities.Task> query = context.Tasks;
            query = query.Where(p => p.ListTaskId == Id).AsQueryable();
            return query.AsEnumerable();
        }

    }
}
