using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab6
{
    class PatronClass : AgentClass
    {
        private static ushort PatronID = 0;
        public ushort ThisPatronID;

        public PatronClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            PatronID++;
            ThisPatronID = PatronID;
        }
        
    }
}
