using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab6
{
    class BouncerClass:AgentClass
    {
        public int ElapsedTime { get; set; }
        private static ushort BouncerID = 0;
        public ushort ThisBouncerID;

        public BouncerClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            BouncerID++;
            ThisBouncerID = BouncerID;
        }

        public void LetInPatrons()
        {
            barQueue.Enqueue(outsideQueue.ElementAt(0));
            PatronClass P = outsideQueue.ElementAt(0);
            outsideQueue.TryDequeue(out P);
            ElapsedTime += 3;
            AddToListBox(ElapsedTime, P.AgentName, 1);
            Thread.Sleep(3 * x);
        }

        public void Arrive()
        {
            outsideQueue.Enqueue(new PatronClass(AddToListBox));
            int delay = rnd.Next(3, 10);
            ElapsedTime += delay;
            AddToListBox(ElapsedTime, outsideQueue.ElementAt(outsideQueue.Count - 1).AgentName, 0);
            Thread.Sleep(delay * x);
        }

        public void BouncerControler()
        {
            for (int i = 0; i < 5; i++)
            {
                Arrive();
            }
            while(ElapsedTime < 100)
            {
                Arrive();
                LetInPatrons();
            }
            //creates all patrons
            //Checks if the bar is closed
                
                //Checks id for x sec and prints a message
                //print message he is waiting
                //Goes to sleep for 3-7 sec
            //if not, prints message that gone home and is disabled
        }
    }
    
}
