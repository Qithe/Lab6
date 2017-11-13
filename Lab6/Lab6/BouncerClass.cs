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
        
        private static ushort BouncerID = 0;
        public ushort ThisBouncerID;

        public BouncerClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            BouncerID++;
            ThisBouncerID = BouncerID;
        }

        public void LetInPatrons()
        {
            //barQueue.Enqueue(outsideQueue.ElementAt(0));
            //PatronClass P = outsideQueue.ElementAt(0);
            //outsideQueue.TryDequeue(out P);
            barQueue.Add(outsideQueue.Take());
            AddToListBox(ElapsedTime, $"{barQueue.Last().AgentName} [{barQueue.Last().ThisPatronID}]", 1);
            ElapsedTime += 3;
            Thread.Sleep(3 * sek);
        }

        public void Arrive()
        {
            outsideQueue.Add(new PatronClass(AddToListBox));
            Task.Run(() => outsideQueue.Last().PatronController());
            //outsideQueue.Enqueue(new PatronClass(AddToListBox));
            int delay = rnd.Next(1, 6);
            AddToListBox(ElapsedTime, $"{outsideQueue.Last().AgentName} [{outsideQueue.Last().ThisPatronID}]", 0);
            ElapsedTime += delay;
            Thread.Sleep(delay * sek);
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
            AddToListBox(ElapsedTime, $"Bouncer [{ThisBouncerID}]", 4);
            while(outsideQueue.Count > 0)
            {
                AddToListBox(ElapsedTime, $"{outsideQueue.First().AgentName} [{outsideQueue.Take().ThisPatronID}]", 5);
                Thread.Sleep(sek);
                ElapsedTime++;
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
