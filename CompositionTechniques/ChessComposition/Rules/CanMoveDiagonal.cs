using System;

namespace ChessComposition.Rules
{
    public class CanMoveDiagonal : IRule
    {
        public bool IsLegalMove(int x, int y, int dx, int dy)
        {
            int horizontalDistance = Math.Abs(x - dx);
            int verticalDistance = Math.Abs(y - dy);
            return horizontalDistance == verticalDistance;
        }

        public bool IsIllegalMove(int x, int y, int dx, int dy)
        {
            return false;
        }
    }
}