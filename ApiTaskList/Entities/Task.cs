using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList2.Entities
{
    public class Task: IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; } = "Ожидание";
        public string Title { get; set; }
        public string Description { get; set; }
        public  DateTime DateCreate { get;  set; }
        public Guid ListTaskId { get; set; }
        public  ListTask ListTask { get; set; }
        public List<HistoryTask> HistoryTasks { get; set; }
    }
}
