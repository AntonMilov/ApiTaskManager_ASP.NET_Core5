using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList2.Models
{
    public class ListTaskModel :IModel
    {
        public Guid UserId { get; set; }
        public string Title  { get; set; }
        public string Description { get; set; }
    }
}
