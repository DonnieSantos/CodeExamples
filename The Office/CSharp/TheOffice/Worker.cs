namespace TheOffice
{
    public class Worker
    {
        public string Name { get; set; }
        public Room Room { get; set; }

        public Worker(string name, Room room)
        {
            this.Name = name;
            this.Room = room;
        }

        public void Move()
        {
            Room destination = this.Room.GetRandomExit();
            this.Room.Workers.Remove(this);
            destination.Workers.Add(this);
            this.Room = destination;
        }
    }
}