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
        public BeerJugClass Jug;

        public PatronClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            PatronID++;
            ThisPatronID = PatronID;
        }

        public void PatronController()
        {
            while (!Jug.isFull)
            {
                Thread.Sleep(1000);
            }
            //Look for free chair
            //Chair.IsOccupied = true;
            Drink();
        }
        
        public void Drink()
        {
            Thread.Sleep(rnd.Next(10000, 20000));
            Jug.isFull = false;
            //Jug.IsClean = false;
            //Chair.GlassList.Add(Jug);
            // NumberOfPatrons--;
        }
    }
}
