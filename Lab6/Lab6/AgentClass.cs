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
        public static int sek = 1000;
        public static int OpenTime = 100;
        
        public Action<string, int> AddToListBox;
        public Action<int, int> UpdateQueueValues;
        public static BlockingCollection<PatronClass> outsideQueue = new BlockingCollection<PatronClass>();
        public static BlockingCollection<PatronClass> barQueue = new BlockingCollection<PatronClass>();
        public static BlockingCollection<PatronClass> chairQueue = new BlockingCollection<PatronClass>();
        public Queue<string> nameList = new Queue<string>();
        public Random rnd = new Random();
        

        public AgentClass(Action<string, int> AddToListBox, Action<int, int>UpdateQueueValues)
        {
            AgentName = GetRandomName();
            this.AddToListBox = AddToListBox;
            this.UpdateQueueValues = UpdateQueueValues;
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
