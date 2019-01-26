using System.Collections.Generic;

namespace SpiderSolitaire
{
    public class Column
    {
        public List<Card> Cards { get; set; }

        public Column()
        {
            this.Cards = new List<Card>();
        }

        public bool isEmpty()
        {
            return this.Cards.Count == 0;
        }
    }
}