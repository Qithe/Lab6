using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class ChairClass : ItemContainerClass
    {
        
        public ChairClass(ushort id) : base(id)
        {
            ConcurrentQueue<PatronClass> PatronList = new ConcurrentQueue<PatronClass>();
        }
    }
}
