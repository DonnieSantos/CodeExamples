using System;

namespace Circles
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(100, 'X');
            board.FillCircle(49, 49, 10, '.');
            board.Print();
            Console.ReadLine();
        }
    }
}