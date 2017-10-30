using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab6
{
    class PatronClass : AgentClass
    {
        public PatronClass(string name) : base(name)
        {
            
        }

        public void Arrive()
        {
            outsideQueue.Enqueue(new PatronClass(getRandomName()));
        }
    }
}
