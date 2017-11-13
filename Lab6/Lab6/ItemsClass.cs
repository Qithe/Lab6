using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class ItemsClass
    {
        private bool IsClean { get; set; }
        private bool IsEmpty { get; set; }
        private ushort Id { get; set; }

        public ItemsClass(ushort id)
        {
            this.IsClean = true;
            this.IsEmpty = true;
            this.Id = id;
        }
    }
}
