using System;
using System.Collections.Generic;
using System.Linq;

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
                this.Cards.Add(new Card(CardValue.Ace));
                this.Cards.Add(new Card(CardValue.Two));
                this.Cards.Add(new Card(CardValue.Three));
                this.Cards.Add(new Card(CardValue.Four));
                this.Cards.Add(new Card(CardValue.Five));
                this.Cards.Add(new Card(CardValue.Six));
                this.Cards.Add(new Card(CardValue.Seven));
                this.Cards.Add(new Card(CardValue.Eight));
                this.Cards.Add(new Card(CardValue.Nine));
                this.Cards.Add(new Card(CardValue.Ten));
                this.Cards.Add(new Card(CardValue.Jack));
                this.Cards.Add(new Card(CardValue.Queen));
                this.Cards.Add(new Card(CardValue.King));
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
                System.Console.Write(card.Value + " ");
            }
        }
    }
}