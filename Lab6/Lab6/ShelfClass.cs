using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class ShelfClass : ItemContainerClass
    {
        public static BlockingCollection<BeerJugClass> ShelfList = new BlockingCollection<BeerJugClass>();
        public static int ShelfSize = 10;

        public ShelfClass(ushort id=0) : base(id)
        {

        }

        public static void GenerateShelf()
        {
            for(int i = 0; i < ShelfSize; i++)
            {
                ShelfList.Add(new BeerJugClass((ushort)i));
            }
        }
    }
}
