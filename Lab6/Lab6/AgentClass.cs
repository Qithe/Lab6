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
        public string AgentName { get; set; }
        public const int sek = 1000;
        public static int ElapsedTime { get; set; }
        public Action<int, string, int> AddToListBox;
        public static BlockingCollection<PatronClass> outsideQueue = new BlockingCollection<PatronClass>();
        public static BlockingCollection<PatronClass> barQueue = new BlockingCollection<PatronClass>();
        public static BlockingCollection<PatronClass> chairQueue = new BlockingCollection<PatronClass>();
        public Queue<string> nameList = new Queue<string>();
        //public ConcurrentQueue<PatronClass> outsideQueue = new ConcurrentQueue<PatronClass>();
        //public ConcurrentQueue<PatronClass> barQueue = new ConcurrentQueue<PatronClass>();
        public Random rnd = new Random();
        

        public AgentClass(Action<int, string, int> AddToListBox)
        {
            AgentName = GetRandomName();
            this.AddToListBox = AddToListBox;
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

        public string GetRandomName()
        {
            GenerateNameList();
            int x = rnd.Next(nameList.Count);
            return nameList.ElementAt(x);
        }
    }
}
