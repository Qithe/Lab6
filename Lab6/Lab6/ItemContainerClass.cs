using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class ItemContainerClass
    {
        private ushort Id { get; set; }
        //public BlockingCollection<ItemsClass> ItemList = new BlockingCollection<ItemsClass>();
        public ItemContainerClass(ushort id = 0)
        {
            Id = id;
        }
    }
}
