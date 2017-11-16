using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    class BartenderClass : AgentClass
    {
        private static ushort BartenderID = 0;
        public ushort ThisBartenderID;
        BeerJugClass BartenderJug = new BeerJugClass(0);
        public BartenderClass(Action<string, int> AddToListBox, Action<int, int> UpdateQueueValues) : base(AddToListBox, UpdateQueueValues)
        {
            BartenderID++;
            ThisBartenderID = BartenderID;
        }

        public void BartenderController()
        {
            while(barQueue.Count == 0)
            {
                Thread.Sleep(sek);
            }
            while(BouncerClass.bouncerTime < OpenTime)
            {
                if (barQueue.Count > 0)
                {
                    GetBeerJug();
                    PourDrink();
                    ServeDrink();
                }
            }
            while(barQueue.Count > 0)
            {
                GetBeerJug();
                PourDrink();
                ServeDrink();
            }
            AddToListBox("Bartender", 8);
        }

        public void GetBeerJug()
        {
            while(ShelfClass.ShelfList.Count == 0)
            {
                Thread.Sleep(sek);
            }
            BartenderJug = ShelfClass.ShelfList.Take();
            Thread.Sleep(3 * sek);
        }

        public void PourDrink()
        {
            BartenderJug.IsEmpty = false;
            Thread.Sleep(3 * sek);
        }

        public void ServeDrink()
        {
            AddToListBox($"{barQueue.First().AgentName} [{barQueue.First().ThisPatronID}]", 6);
            barQueue.First().Jug = BartenderJug;
            chairQueue.Add(barQueue.Take());
            UpdateQueueValues(barQueue.Count, 3);
            UpdateQueueValues(chairQueue.Count, 4);
            Thread.Sleep(sek);
        }
    }
}
