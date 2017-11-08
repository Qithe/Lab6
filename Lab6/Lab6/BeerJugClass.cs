using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class BeerJugClass : ItemsClass
    {
        public bool isFull = false;

        public BeerJugClass(ushort id):base(id)
        {
            
        }
    }
}
