using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab6
{
    class AgentClass
    {
        private string Name { get; set; }
        public ConcurrentQueue<string> nameList = new ConcurrentQueue<string>();
        public ConcurrentQueue<PatronClass> outsideQueue = new ConcurrentQueue<PatronClass>();
        public ConcurrentQueue<PatronClass> barQueue = new ConcurrentQueue<PatronClass>();
        Random rnd = new Random();
        

        public AgentClass(string name)
        {
            Name = getRandomName();
        }

        public void runTask(Action run)
        {

        }

        public void generateNameList()
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
        }

        public string getRandomName()
        {
            int x = rnd.Next(nameList.Count);
            return nameList.ElementAt(x);
        }
    }
}
