using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class BeerJugClass
    {
        public bool IsClean { get; set; }
        public bool IsEmpty { get; set; }
        private ushort Id { get; set; }
        public BeerJugClass(ushort id)
        {
            Id = id;
        }
    }
}
