using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class ServicePersonelClass : AgentClass
    {
        private static ushort ServiceID = 0;
        public ushort ThisServiceID;
        ConcurrentQueue<BeerJugClass> WashList = new ConcurrentQueue<BeerJugClass>();
        public ServicePersonelClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            ServiceID++;
            ThisServiceID = ServiceID;
        }
        public void ServicePersonelController()
        {
            //if shelf not full, check if chairs has empty jugs
            
                //Go get jug(s) jug
                //Go wash jug(s) 15sec
                //Go put jug(s) in shelf
                //Go to start
            //If bar is closed and and no patrons
                //GO HOME WOMAN/MAN!
        }
    }
}
