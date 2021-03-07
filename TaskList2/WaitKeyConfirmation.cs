using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Models;

namespace TaskList2
{
    public class WaitKeyConfirmation
    {
        public int Key { get; set; }
       public Guid UserId { get; set; }
        public WaitKeyConfirmation(Guid UserId, int Key)
        {
            this.UserId = UserId;
            this.Key = Key;
        }

    }
}
