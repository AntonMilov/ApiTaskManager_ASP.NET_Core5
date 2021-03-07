using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList2.Models
{
    public class HistoryTaskModel: IModel
    {
        public Guid TaskId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
