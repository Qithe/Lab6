using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab6
{
    public class AgentClass : ItemContainerClass
    {
        private string Name { get; set; }
        public ConcurrentQueue<string> nameList = new ConcurrentQueue<string>();
        public ConcurrentQueue<PatronClass> outsideQueue = new ConcurrentQueue<PatronClass>();
        public ConcurrentQueue<PatronClass> barQueue = new ConcurrentQueue<PatronClass>();
        Random rnd = new Random();
        

        public AgentClass(ushort id = 0,string name="") : base(id)
        {
            this.Name = getRandomName();
        }

        public void RunTask(Action run)
        {

        }

        public void GenerateNameList()
        {
            nameList.Enqueue("Samuel");
            nameList.Enqueue("Oscar");
            nameList.Enqueue("Lars");
            nameList.Enqueue("Emma");
            nameList.Enqueue("Johan");
            nameList.Enqueue("Rickard");
            nameList.Enqueue("Herbert");
            nameList.Enqueue("Jimmy");
            nameList.Enqueue("Rutger");
            nameList.Enqueue("Nils-Erik");
            nameList.Enqueue("Bruno");
            nameList.Enqueue("Emil");
            nameList.Enqueue("Lars-Erik");
            nameList.Enqueue("Steve");
            nameList.Enqueue("Bill");
            nameList.Enqueue("Elon");
        }

        public string getRandomName()
        {
            int x = rnd.Next(nameList.Count);
            return nameList.ElementAt(x);
        }
    }
}
