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
        BouncerClass(ushort id, string name) : base()
        {

        }

        public void LetInPatrons()
        {
            barQueue.Enqueue(outsideQueue.ElementAt(0));
            PatronClass P = outsideQueue.ElementAt(0);
            outsideQueue.TryDequeue(out P);
        }

        public void BouncerControler()
        {
            //creates all patrons
            //Checks if the bar is closed
                
                //Checks id for x sec and prints a message
                //print message he is waiting
                //Goes to sleep for 3-7 sec
            //if not, prints message that gone home and is disabled
        }
    }
    
}
