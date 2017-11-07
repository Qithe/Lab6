using System;
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
        ServicePersonelClass(Action<int, string, int> AddToListBox) : base(AddToListBox)
        {
            ServiceID++;
            ThisServiceID = ServiceID;
        }
    }
}
