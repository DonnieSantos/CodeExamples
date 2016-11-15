using System.Collections.Generic;

namespace TheOffice
{
    public class Office
    {
        public List<List<Room>> Rooms { get; set; }
        private List<Worker> Workers { get; set; }        

        public Office()
        {
            createRooms();
            connectRooms();
            addWorkers();
        }

        private void createRooms()
        {
            Rooms = new List<List<Room>>();

            for (int i = 0; i < 5; i++)
            {
                List<Room> aisle = new List<Room>();

                for (int j = 0; j < 5; j++)
                {
                    aisle.Add(new Room());
                }

                Rooms.Add(aisle);
            }
        }

        private void connectRooms()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i > 0) Rooms[i][j].North = Rooms[i - 1][j];
                    if (j > 0) Rooms[i][j].West = Rooms[i][j - 1];
                    if (i < 4) Rooms[i][j].South = Rooms[i + 1][j];
                    if (j < 4) Rooms[i][j].East = Rooms[i][j + 1];
                }
            }
        }

        private void addWorkers()
        {
            Workers = new List<Worker>();
            Workers.Add(Rooms[0][0].CreateNewWorker("Michael"));
            Workers.Add(Rooms[0][0].CreateNewWorker("Dwight"));
            Workers.Add(Rooms[0][0].CreateNewWorker("Jim"));
            Workers.Add(Rooms[0][0].CreateNewWorker("Pam"));
        }

        public void MoveWorkers()
        {
            foreach (Worker worker in Workers)
            {
                worker.Move();
            }
        }
    }
}