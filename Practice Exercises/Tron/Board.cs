namespace Tron
{
    public class Board
    {
        int[,] Cells { get; set; }
        public int Size { get { return Cells.GetLength(0); } }

        public Board(int[,] cells)
        {
            Cells = cells;
        }

        public int GetLongestPath(int startX, int startY, int endX, int endY)
        {
            return getLongestPath(startX, startY, endX, endY) - 4;
        }

        public int getLongestPath(int startX, int startY, int endX, int endY)
        {
            int distance = 0;

            if (startX == endX && startY == endY) return 0;

            if (startY < Size - 1 && Cells[startX, startY + 1] != 0)
            {
                distance = getLocalDistance(startX, startY + 1, endX, endY, distance);
            }

            if (startY > 0 && Cells[startX, startY - 1] != 0)
            {
                distance = getLocalDistance(startX, startY - 1, endX, endY, distance);
            }

            if (startX < Size - 1 && Cells[startX + 1, startY] != 0)
            {
                distance = getLocalDistance(startX + 1, startY, endX, endY, distance);
            }

            if (startX > 0 && Cells[startX - 1, startY] != 0)
            {
                distance = getLocalDistance(startX - 1, startY, endX, endY, distance);
            }

            return distance;
        }

        private int getLocalDistance(int startX, int startY, int endX, int endY, int distance)
        {
            Cells[startX, startY] = 0;
            int localDistance = getLongestPath(startX, startY, endX, endY) + 1;
            if (localDistance > distance) distance = localDistance;
            Cells[startX, startY] = 1;
            return distance;
        }
    }
}