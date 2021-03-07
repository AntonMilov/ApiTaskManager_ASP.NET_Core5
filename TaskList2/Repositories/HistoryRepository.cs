using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Repositories.Abstract;

namespace TaskList2.Repositories
{
    public class HistoryRepository : BaseRepository<Entities.HistoryTask>, IHistoryTaskRepository
    {
        public HistoryRepository(Context.DataBaseContext context)
            : base(context)
        {
        }
        public override Guid Create(Entities.HistoryTask HistoryTask)
        {

            context.HistoryTasks.Add(HistoryTask);
            var task = context.Tasks.Where(p => p.Id == HistoryTask.Id).FirstOrDefault();
            task.Status = HistoryTask.Status;
            context.SaveChanges();
            return (HistoryTask.Id);
        }
    }
}

