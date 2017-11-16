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
        public static int BouncerSpeed = 1;
        public static bool groupNight = false;
        private int servedPatrons = 0;

        public BouncerClass(Action<string, int> AddToListBox, Action<int, int> UpdateQueueValues) : base(AddToListBox, UpdateQueueValues)
        {
            BouncerID++;
            ThisBouncerID = BouncerID;
        }

        public void LetInPatrons()
        {
            barQueue.Add(outsideQueue.Take());
            servedPatrons++;
            AddToListBox($"{barQueue.Last().AgentName} [{barQueue.Last().ThisPatronID}]", 1);
            if (couplesNight)
            {
                barQueue.Add(outsideQueue.Take());
                servedPatrons++;
                AddToListBox($"{barQueue.Last().AgentName} [{barQueue.Last().ThisPatronID}]", 1);
            }
            if(groupNight && bouncerTime > 20)
            {
                for(int i = 0; i < 14; i++)
                {
                    barQueue.Add(outsideQueue.Take());
                    servedPatrons++;
                    AddToListBox($"{barQueue.Last().AgentName} [{barQueue.Last().ThisPatronID}]", 1);
                }
                groupNight = false;
            }
            bouncerTime += BouncerSpeed * 3;
            UpdateQueueValues(barQueue.Count + chairQueue.Count + ChairClass.OccupiedChairs(), 1);
            UpdateQueueValues(barQueue.Count, 3);
            UpdateQueueValues(servedPatrons, 5);
            Thread.Sleep(BouncerSpeed * 3 * sek);
        }

        public void Arrive()
        {
            outsideQueue.Add(new PatronClass(AddToListBox, UpdateQueueValues));
            Task.Run(() => outsideQueue.Last().PatronController());
            AddToListBox($"{outsideQueue.Last().AgentName} [{outsideQueue.Last().ThisPatronID}]", 0);
            if (couplesNight)
            {
                outsideQueue.Add(new PatronClass(AddToListBox, UpdateQueueValues));
                Task.Run(() => outsideQueue.Last().PatronController());
                AddToListBox($"{outsideQueue.Last().AgentName} [{outsideQueue.Last().ThisPatronID}]", 0);
            }
            if (groupNight && bouncerTime > 20)
            {
                for(int i = 0; i < 14; i++)
                {
                    outsideQueue.Add(new PatronClass(AddToListBox, UpdateQueueValues));
                    Task.Run(() => outsideQueue.Last().PatronController());
                    AddToListBox($"{outsideQueue.Last().AgentName} [{outsideQueue.Last().ThisPatronID}]", 0);
                }
            }
            UpdateQueueValues(outsideQueue.Count, 2);
            int delay = rnd.Next(1, 10);
            bouncerTime += delay * BouncerSpeed;
            Thread.Sleep(delay * BouncerSpeed * sek);
        }

        public void BouncerControler()
        {
            
            for (int i = 0; i < 4; i++)
            {
                Arrive();
            }
            while(bouncerTime < OpenTime + 5)
            {
                Arrive();
                LetInPatrons();
            }
            AddToListBox($"Bouncer [{ThisBouncerID}]", 4);
            while(outsideQueue.Count > 0)
            {
                AddToListBox($"{outsideQueue.First().AgentName} [{outsideQueue.Take().ThisPatronID}]", 5);
                UpdateQueueValues(outsideQueue.Count, 2);
                bouncerTime++;
                Thread.Sleep(sek);
            }
        }
    }
    
}
