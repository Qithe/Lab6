using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class ChairClass : ItemContainerClass
    {
        public static BlockingCollection<ChairClass> ChairList = new BlockingCollection<ChairClass>();
        public BeerJugClass JugAtChair = new BeerJugClass(0);
        public bool PatronAtChair = false;
        public static int NumbOfChairs = 9;

        public ChairClass(ushort id = 0) : base(id)
        {

        }

        public static int OccupiedChairs()
        {
            int busyChairs = 0;
            for(int i = 0; i < NumbOfChairs; i++)
            {
                if (ChairList.ElementAt(i).PatronAtChair) { busyChairs++; }
            }
            return busyChairs;
        }

        public static void GenerateChairs()
        {
            for(int i = 0; i < NumbOfChairs; i++)
            {
                ChairList.Add(new ChairClass((ushort)i));
            }
        }

    }
}
