using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList2
{
    public class KeyGenerator
    {
        public int GenerateKey()
        {
            int key;
            Random rnd = new Random();
            return  key = rnd.Next(101, 999);
        }
    }
}
