using System.Collections.Generic;

namespace SpiderSolitaire
{
    class Program
    {
        static void Main(string[] args)
        {
            var allCards = new List<Card>();
            allCards.AddRange(new Deck().Shuffle().Cards);
            allCards.AddRange(new Deck().Shuffle().Cards);
            Board board = new Board(allCards);
        }
    }
}