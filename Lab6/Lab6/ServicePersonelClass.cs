using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    class ServicePersonelClass : AgentClass
    {
        private static ushort ServiceID = 0;
        public ushort ThisServiceID;
        public static int ServiceSpeed = 1;
        BlockingCollection<BeerJugClass> WashList = new BlockingCollection<BeerJugClass>();
        public ServicePersonelClass(Action<string, int> AddToListBox, Action<int, int> UpdateQueueValues) : base(AddToListBox, UpdateQueueValues)
        {
            ServiceID++;
            ThisServiceID = ServiceID;
        }
        public void ServicePersonelController()
        {
            while (BouncerClass.bouncerTime < OpenTime + 20 || ShelfClass.ShelfList.Count != ShelfClass.ShelfSize)
            {
                if (ShelfClass.ShelfList.Count < ShelfClass.ShelfSize)
                {
                    GetJugs();
                    WashJugs();
                    PutJugsOnShelf();
                }
                Thread.Sleep(sek / ServiceSpeed);
            }
        }

        public void GetJugs()
        {
            while (WashList.Count == 0)
            {
                for (int i = 0; i < ChairClass.ChairList.Count; i++)
                {
                    if (ChairClass.ChairList.ElementAt(i).JugAtChair.IsClean == false)
                    {
                        WashList.Add(ChairClass.ChairList.ElementAt(i).JugAtChair);
                        ChairClass.ChairList.ElementAt(i).JugAtChair.IsClean = true;
                        Thread.Sleep(sek / 5 / ServiceSpeed);
                    }
                }
                Thread.Sleep(sek / ServiceSpeed);
            }
            AddToListBox($"{WashList.Count}", 7);
            Thread.Sleep(3* sek / ServiceSpeed);
        }

        public void WashJugs()
        {
            for(int i = 0; i < WashList.Count; i++)
            {
                WashList.ElementAt(i).IsClean = true;
                AddToListBox($"{WashList.ElementAt(i).Id}", 3);
            }
            Thread.Sleep(15 * sek / ServiceSpeed);
        }

        public void PutJugsOnShelf()
        {
            int size = WashList.Count;
            for(int i = size; i > 0; i--)
            {
                ShelfClass.ShelfList.Add(WashList.ElementAt(i-1));
            }
            for(int i = 0; i < size; i++)
            {
                WashList.Take();
            }
            Thread.Sleep(sek / ServiceSpeed);
        }
    }
}
