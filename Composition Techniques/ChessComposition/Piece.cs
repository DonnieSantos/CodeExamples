using System.Collections.Generic;
using ChessComposition.Rules;

namespace ChessComposition
{
    public class Piece
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<IRule> Rules { get; set; }

        public Piece(int x, int y, List<IRule> rules)
        {
            this.X = x;
            this.Y = y;
            this.Rules = rules;
        }

        public bool Move(int dx, int dy)
        {
            foreach (IRule rule in this.Rules)
            {
                if (rule.IsIllegalMove(this.X, this.Y, dx, dy))
                {
                    return false;
                }
            }

            foreach (IRule rule in this.Rules)
            {
                if (rule.IsLegalMove(this.X, this.Y, dx, dy))
                {
                    this.X = dx;
                    this.Y = dy;
                    return true;
                }
            }

            return false;
        }
    }
}