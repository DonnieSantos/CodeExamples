using System;
using System.Collections.Generic;

namespace TheOffice
{
    public class Map
    {
        public void Display(List<List<Room>> rooms)
        {
            Console.Clear();
            Console.WriteLine();
            printHorizontalDivider();
            printRooms(rooms);
        }

        private void printRooms(List<List<Room>> rooms)
        {
            for (int i = 0; i < 5; i++)
            {
                printAisle(rooms[i]);
            }
        }

        private void printAisle(List<Room> aisle)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write(" ");

                for (int j = 0; j < 5; j++)
                {
                    Room room = aisle[j];
                    List<Worker> workers = room.Workers;

                    if (i < workers.Count)
                    {
                        Console.Write("| " + workers[i].Name.PadRight(7) + " ");
                    }
                    else
                    {
                        Console.Write("|         ");
                    }
                }

                Console.WriteLine("|");
            }

            printHorizontalDivider();
        }

        private void printHorizontalDivider()
        {
            Console.WriteLine(" +---------+---------+---------+---------+---------+");
        }
    }
}