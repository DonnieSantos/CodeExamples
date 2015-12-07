using System;
using System.Collections.Generic;

namespace Cards
{
    public class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();

            foreach (Card.SuitValue suitValue in Enum.GetValues(typeof(Card.SuitValue)))
            {
                foreach (Card.FaceValue faceValue in Enum.GetValues(typeof(Card.FaceValue)))
                {
                    _cards.Add(new Card(faceValue, suitValue));
                }
            }

            _cards.Shuffle();
        }

        public Card GetCard()
        {
            return _cards.GetCard();
        }
    }
}