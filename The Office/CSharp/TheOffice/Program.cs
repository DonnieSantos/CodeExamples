using System.Timers;

namespace TheOffice
{
    public class Program
    {
        public static Map Map;
        public static Timer Timer;
        public static Office Office;

        public static void Main(string[] args)
        {
            Map = new Map();
            Office = new Office();
            Timer = new Timer();
            Timer.AutoReset = true;
            Timer.Interval = 1000;
            Timer.Elapsed += new ElapsedEventHandler(TickTock);
            Timer.Start();
            while (true) { }
        }

        public static void TickTock(object o, ElapsedEventArgs e)
        {
            Office.MoveWorkers();
            Map.Display(Office.Rooms);
        }
    }
}