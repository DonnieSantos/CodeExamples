using System;

namespace Cards
{
    class Program
    {
        public const int NumPlayers = 5;
        public const int SampleSize = 10000;

        static void Main(string[] args)
        {
            Table table = new Table();

            for (int i = 1; i <= NumPlayers; i++)
            {
                table.AddPlayer(new Player("Player " + i));
            }

            runQuickTest(table);
            //runPocketTest(table);

            Console.Read();
        }

        private static void runQuickTest(Table table)
        {
            table.Deal();
            table.Print();
            table.Deal();
            table.Print();
            table.Deal();
            table.Print();
        }

        private static void runPocketTest(Table table)
        {
            int percent = 0;

            for (int i = 0; i < SampleSize; i++)
            {
                int currentPercent = i / (SampleSize / 100);
                if (percent != currentPercent)
                {
                    percent = currentPercent;
                    Console.Clear();
                    Console.WriteLine(percent + "% complete...");
                }

                table.Deal();
                Player winner = table.GetWinner();

                if (winner != null)
                {
                    winner.RecordWin();
                    table.RecordHands();
                }
            }

            Console.Clear();
            table.PrintWinningPocketData();
            Console.WriteLine();
            table.PrintWinningHandData();
            Console.WriteLine();
            table.ShowPlayerScores();
            Console.WriteLine();
        }
    }
}