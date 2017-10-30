using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab6
{
    class BouncerClass:AgentClass
    {
        BouncerClass(string name) : base(name)
        {

        }

        public void LetInPatrons()
        {
            barQueue.Enqueue(outsideQueue.ElementAt(0));
        }
    }
    
}
