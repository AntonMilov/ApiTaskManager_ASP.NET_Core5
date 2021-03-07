using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList2.Entities
{
    public class HistoryTask: IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
    }
}
