using System;
using System.Linq;
using System.Collections.Generic;

namespace SpiderSolitaire
{
    class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            this.Cards = new List<Card>();

            for (int i=0; i<4; i++)
            {
                this.Cards.Add(new Card(CardValue.sA));
                this.Cards.Add(new Card(CardValue.s2));
                this.Cards.Add(new Card(CardValue.s3));
                this.Cards.Add(new Card(CardValue.s4));
                this.Cards.Add(new Card(CardValue.s5));
                this.Cards.Add(new Card(CardValue.s6));
                this.Cards.Add(new Card(CardValue.s7));
                this.Cards.Add(new Card(CardValue.s8));
                this.Cards.Add(new Card(CardValue.s9));
                this.Cards.Add(new Card(CardValue.sT));
                this.Cards.Add(new Card(CardValue.sJ));
                this.Cards.Add(new Card(CardValue.sQ));
                this.Cards.Add(new Card(CardValue.sK));
            }
        }

        public bool isEmpty()
        {
            return this.Cards.Count == 0;
        }

        public Deck Shuffle()
        {
            this.Cards = this.Cards.OrderBy(a => Guid.NewGuid()).ToList();
            return this;
        }

        public void Print()
        {
            foreach (Card card in Cards)
            {
                // card.print();
                Console.Write(card.Value + " ");
            }
        }
    }
}