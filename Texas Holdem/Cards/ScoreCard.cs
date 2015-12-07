using System;

namespace Cards
{
    public class ScoreCard
    {
        private string _ownerName;
        private int _countHands = 0;
        private int _countWins = 0;
        private int _countStraightFlush = 0;
        private int _countQuads = 0;
        private int _countBoats = 0;
        private int _countFlush = 0;
        private int _countStraight = 0;
        private int _countTrips = 0;
        private int _countTwoPair = 0;
        private int _countPair = 0;
        private int _countNothing = 0;

        public ScoreCard(string ownerName)
        {
            _ownerName = ownerName;
        }

        public void RecordWin()
        {
            _countWins++;
        }

        public void RecordHand(Player.HandValue handValue)
        {
            _countHands++;

            switch (handValue)
            {
                case Player.HandValue.StFlush: _countStraightFlush++; break;
                case Player.HandValue.Quads: _countQuads++; break;
                case Player.HandValue.FullBoat: _countBoats++; break;
                case Player.HandValue.Flush: _countFlush++; break;
                case Player.HandValue.Straight: _countStraight++; break;
                case Player.HandValue.Trips: _countTrips++; break;
                case Player.HandValue.TwoPair: _countTwoPair++; break;
                case Player.HandValue.OnePair: _countPair++; break;
                default: _countNothing++; break;
            }
        }

        public void Print()
        {
            int padRight = 9;
            Console.WriteLine(" +----------------------+");
            Console.WriteLine(" | PLAYER    : " + _ownerName.PadRight(padRight) + "|");
            Console.WriteLine(" | StFlush   : " + _countStraightFlush.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | Quads     : " + _countQuads.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | Boats     : " + _countBoats.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | Flushes   : " + _countFlush.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | Straights : " + _countStraight.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | Trips     : " + _countTrips.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | TwoPairs  : " + _countTwoPair.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | Pairs     : " + _countPair.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | Nothing   : " + _countNothing.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | HANDS     : " + _countHands.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" | WINS      : " + _countWins.ToString("0,000").PadRight(padRight) + "|");
            Console.WriteLine(" +----------------------+");
            Console.WriteLine("");
        }
    }
}