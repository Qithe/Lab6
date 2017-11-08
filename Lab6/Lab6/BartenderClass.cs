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
        BartenderClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            BartenderID++;
            ThisBartenderID = BartenderID;
        }

        public void BartenderControler()
        {

        }

        public void GetBeerJug()
        {

        }

        public void PourDrink()
        {

        }

        public void ServeDrink()
        {

        }
        public void BartenderController()
        {
            //if patrion in queue
                //Take a jug
                //Pour a jug
                //Give Jug to patrion
        }
    }
}
