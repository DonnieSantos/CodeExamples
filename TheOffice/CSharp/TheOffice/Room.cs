using System;
using System.Collections.Generic;

namespace TheOffice
{
    public class Room
    {
        private static Random RandomInteger = new Random();

        public Room North { get; set; }
        public Room South { get; set; }
        public Room East { get; set; }
        public Room West { get; set; }
        public List<Worker> Workers { get; set; }

        public Room()
        {
            this.Workers = new List<Worker>();
        }

        public Worker CreateNewWorker(string name)
        {
            Worker worker = new Worker(name, this);
            this.Workers.Add(worker);
            return worker;
        }

        public Room GetRandomExit()
        {
            List<Room> availableExits = new List<Room>();
            if (this.North != null) availableExits.Add(this.North);
            if (this.South != null) availableExits.Add(this.South);
            if (this.East != null) availableExits.Add(this.East);
            if (this.West != null) availableExits.Add(this.West);
            return availableExits[RandomInteger.Next(availableExits.Count)];
        }
    }
}