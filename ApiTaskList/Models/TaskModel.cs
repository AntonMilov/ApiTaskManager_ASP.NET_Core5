using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList2.Models
{
    public class TaskModel: IModel
    {
        public Guid ListTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public DateTime DateCreate { get; set; }
    }
}
