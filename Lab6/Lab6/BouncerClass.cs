using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab6
{
    class BouncerClass:AgentClass
    {
        
        private static ushort BouncerID = 0;
        public ushort ThisBouncerID;
        public static double bouncerTime = 0;
        public static bool couplesNight = false;

        public BouncerClass(Action<string, int> AddToListBox) : base(AddToListBox)
        {
            BouncerID++;
            ThisBouncerID = BouncerID;
        }

        public void LetInPatrons()
        {
            //barQueue.Enqueue(outsideQueue.ElementAt(0));
            //PatronClass P = outsideQueue.ElementAt(0);
            //outsideQueue.TryDequeue(out P);
            barQueue.Add(outsideQueue.Take());
            AddToListBox($"{barQueue.Last().AgentName} [{barQueue.Last().ThisPatronID}]", 1);
            bouncerTime += 3 * sek / 1000;
            Thread.Sleep(3 * sek);
        }

        public void Arrive()
        {
            outsideQueue.Add(new PatronClass(AddToListBox));
            Task.Run(() => outsideQueue.Last().PatronController());
            int delay = rnd.Next(1, 10);
            AddToListBox($"{outsideQueue.Last().AgentName} [{outsideQueue.Last().ThisPatronID}]", 0);
            bouncerTime += delay * sek / 1000;
            Thread.Sleep(delay * sek);
        }

        public void BouncerControler()
        {
            
            for (int i = 0; i < 5; i++)
            {
                Arrive();
            }
            while(bouncerTime < OpenTime)
            {
                Arrive();
                if (couplesNight) { Arrive(); LetInPatrons(); }
                LetInPatrons();
            }
            AddToListBox($"Bouncer [{ThisBouncerID}]", 4);
            while(outsideQueue.Count > 0)
            {
                AddToListBox($"{outsideQueue.First().AgentName} [{outsideQueue.Take().ThisPatronID}]", 5);
                bouncerTime++;
                Thread.Sleep(sek);
            }
        }
    }
    
}
