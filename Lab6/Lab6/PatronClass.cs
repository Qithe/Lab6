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
        private bool wannaGoHome = false;

        public PatronClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            PatronID++;
            ThisPatronID = PatronID;
        }

        public void PatronController()
        {
            while (!wannaGoHome)
            {
                Thread.Sleep(sek);
                if (chairQueue.Count > 0)
                {
                    if (ThisPatronID == chairQueue.First().ThisPatronID)
                    {
                        Jug = chairQueue.Take().Jug;
                        Thread.Sleep(3 * sek);

                        //Look for free chair
                        while (!LookForChair())
                        {
                            Thread.Sleep(sek);
                        }
                        Drink();
                        ChairClass.ChairList.ElementAt(chairID).PatronAtChair = false;
                        wannaGoHome = true;
                        AddToListBox(ElapsedTime, $"{AgentName} [{ThisPatronID}]", 5);
                    }
                }
                
            }
        }
        
        public void Drink()
        {
            AddToListBox(ElapsedTime, $"{AgentName} [{ThisPatronID}]", 2);
            Thread.Sleep(rnd.Next(10, 20)*sek);
            Jug.IsEmpty = true;
            Jug.IsClean = false;
            ChairClass.ChairList.ElementAt(chairID).JugAtChair = Jug;
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
