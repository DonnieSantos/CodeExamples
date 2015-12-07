using System;

namespace Circles
{
    class Board
    {
        public char[][] Cells { get; set; }
        public int Size { get { return Cells.Length; } }

        public Board(int size, char blankValue)
        {
            Cells = new char[size][];

            for (int i = 0; i < size; i++)
            {
                Cells[i] = new char[size];

                for (int j = 0; j < size; j++)
                {
                    Cells[i][j] = blankValue;
                }
            }
        }

        public void FillCircle(int X, int Y, int radius, char markValue)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    double dx = (double) Math.Abs(j - X);
                    double dy = (double) Math.Abs(i - Y);
                    double distance = Math.Sqrt((dx * dx) + (dy * dy));

                    if (radius <= distance)
                    {
                        Cells[i][j] = markValue;
                    }
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(Cells[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}