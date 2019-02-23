using System.Collections.Generic;

namespace SpiderSolitaire
{
    public class Pile
    {
        public List<Card> Cards { get; set; }

        public Pile()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void PrintCard(int index)
        {
            System.Console.Write(Cards[index].Value + " ");
        }
    }
}