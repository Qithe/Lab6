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
        public BeerJugClass Jug = new BeerJugClass(0);
        private int chairID;

        public PatronClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            PatronID++;
            ThisPatronID = PatronID;
        }

        public void PatronController()
        {
            while (Jug.IsEmpty == true)
            {
                Thread.Sleep(sek);
            }
            
            while (Jug.IsEmpty == false)
            {
                Thread.Sleep(3 * sek);
                //Look for free chair
                while (!LookForChair())
                {
                    Thread.Sleep(sek);
                }
                Thread.Sleep(rnd.Next(10, 20) * sek);
                Drink();
            }
        }
        
        public void Drink()
        {
            AddToListBox(ElapsedTime, $"{AgentName} [{ThisPatronID}]", 2);
            Thread.Sleep(rnd.Next(10, 20)*sek);
            Jug.IsEmpty = true;
            Jug.IsClean = false;
            ChairClass.ChairList.ElementAt(chairID).JugAtChair = Jug;
            // Jug.isFull = false;
            //Jug.IsClean = false;
            //Chair.GlassList.Add(Jug);
            // NumberOfPatrons--;
        }

        public bool LookForChair()
        {
            for(int i = 0; i < ChairClass.ChairList.Count; i++)
            {
                if(!ChairClass.ChairList.ElementAt(i).PatronAtChair && ChairClass.ChairList.ElementAt(i).JugAtChair.IsClean)
                {
                    ChairClass.ChairList.ElementAt(i).PatronAtChair = true;
                    chairID = i;
                    return true;
                } 
            }
            return false;
        }
    }
}
