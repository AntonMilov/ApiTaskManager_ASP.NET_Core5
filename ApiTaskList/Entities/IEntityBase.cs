using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList2.Entities
{
    public interface IEntityBase
    {
        public Guid Id { get; set; }
    }
}
