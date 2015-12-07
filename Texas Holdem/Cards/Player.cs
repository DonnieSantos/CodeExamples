using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public class Player
    {
        public enum HandValue { Nothing, OnePair, TwoPair, Trips, Straight, Flush, FullBoat, Quads, StFlush }
        public static List<HandValue> HandValuesAscending = new List<HandValue>() { HandValue.Nothing, HandValue.OnePair, HandValue.TwoPair, HandValue.Trips, HandValue.Straight, HandValue.Flush, HandValue.FullBoat, HandValue.Quads, HandValue.StFlush };

        private string _name;
        private ScoreCard _scoreCard;
        private List<Card> _allCards;
        private List<Card> _usedCards;
        private HandValue _handValue;

        public string GetName() { return _name; }
        public HandValue GetHandValue() { return _handValue; }
        public string GetUsedCards() { return _usedCards.ToFormattedString(); }
        public void RecordWin() { _scoreCard.RecordWin(); }
        public void RecordHand() { _scoreCard.RecordHand(_handValue); }
        public void PrintScore() { _scoreCard.Print(); }

        public Player(string name)
        {
            _name = name;
            _usedCards = new List<Card>();
            _scoreCard = new ScoreCard(name);
            _allCards = new List<Card>();
        }

        public string GetPocketName()
        {
            Card card1 = _allCards[0];
            Card card2 = _allCards[1];

            if (card1.Face < card2.Face)
            {
                card1 = _allCards[1];
                card2 = _allCards[0];
            }

            bool suited = card1.Suit == card2.Suit;
            StringBuilder pocketName = new StringBuilder("");
            pocketName.Append(card1.Face);
            pocketName.Append("-");
            pocketName.Append(card2.Face);
            //pocketName.Append(suited ? "_Suited" : "");
            return pocketName.ToString();
        }

        public void AddCard(Card card)
        {
            _allCards.Add(card);

            if (_allCards.Count == 7)
            {
                if (hasStraightFlush()) return;
                if (hasMulti(4)) return;
                if (hasBoat()) return;
                if (hasFlush()) return;
                if (hasStraight()) return;
                if (hasMulti(3)) return;
                if (hasTwoPair()) return;
                if (hasMulti(2)) return;
                hasNothing();
            }
        }

        public void Clear()
        {
            _allCards.Clear();
            _usedCards.Clear();
            _handValue = HandValue.Nothing;
        }

        private bool hasMulti(int n)
        {
            var hash = _allCards.HashByFaceValue();
            List<Card> Pair = hash.GetHighestPair(n);
            if (Pair == null) return false;

            switch (n)
            {
                case 2: _handValue = HandValue.OnePair; break;
                case 3: _handValue = HandValue.Trips; break;
                case 4: _handValue = HandValue.Quads; break;
                default: break;
            }

            _usedCards.AddRange(Pair);
            _usedCards.AddRange(hash.GetHighestCards(5 - n));
            return true;
        }

        private bool hasBoat()
        {
            var hash = _allCards.HashByFaceValue();
            List<Card> Trips = hash.GetHighestPair(3);
            if (Trips == null) return false;
            List<Card> Pair = hash.GetHighestPair(2);
            if (Pair == null) return false;

            _handValue = HandValue.FullBoat;
            _usedCards.AddRange(Trips);
            _usedCards.AddRange(Pair);
            return true;
        }

        private bool hasTwoPair()
        {
            var hash = _allCards.HashByFaceValue();
            List<Card> TopPair = hash.GetHighestPair(2);
            if (TopPair == null) return false;
            List<Card> BottomPair = hash.GetHighestPair(2);
            if (BottomPair == null) return false;

            _handValue = HandValue.TwoPair;
            _usedCards.AddRange(TopPair);
            _usedCards.AddRange(BottomPair);
            _usedCards.Add(hash.GetHighestCard());
            return true;
        }

        private bool hasFlush()
        {
            var hash = _allCards.HashBySuitValue();

            foreach (Card.SuitValue suitValue in Card.SuitValues)
            {
                if (hash[suitValue].Count >= 5)
                {
                    _handValue = HandValue.Flush;
                    _usedCards.AddRange(hash[suitValue].GetCards(5));
                    return true;
                }
            }

            return false;
        }

        private bool hasStraightFlush()
        {
            foreach (Card.SuitValue suitValue in Card.SuitValues)
            {
                if (hasStraightFlushForSuit(suitValue))
                {
                    return true;
                }
            }

            return false;
        }

        private bool hasStraightFlushForSuit(Card.SuitValue suitValue)
        {
            var hash = _allCards.HashByFaceValue();

            int count = 0;

            foreach (Card.FaceValue faceValue in Card.FaceValuesDesceding)
            {
                count = hash[faceValue].HetSuit(suitValue) ? count + 1 : 0;

                if (count == 5)
                {
                    _handValue = HandValue.StFlush;
                    _usedCards.Add(_allCards.GetCard(faceValue + 4, suitValue));
                    _usedCards.Add(_allCards.GetCard(faceValue + 3, suitValue));
                    _usedCards.Add(_allCards.GetCard(faceValue + 2, suitValue));
                    _usedCards.Add(_allCards.GetCard(faceValue + 1, suitValue));
                    _usedCards.Add(_allCards.GetCard(faceValue + 0, suitValue));
                    return true;
                }
            }

            return false;
        }

        private bool hasStraight()
        {
            var hash = _allCards.HashByFaceValue();

            int count = 0;

            foreach (Card.FaceValue faceValue in Card.FaceValuesDesceding)
            {
                count = (hash[faceValue].Count > 0) ? count + 1 : 0;

                if (count == 5)
                {
                    _handValue = HandValue.Straight;
                    _usedCards.Add(hash[faceValue].GetCard());
                    _usedCards.Add(hash[faceValue + 1].GetCard());
                    _usedCards.Add(hash[faceValue + 2].GetCard());
                    _usedCards.Add(hash[faceValue + 3].GetCard());
                    _usedCards.Add(hash[faceValue + 4].GetCard());
                    return true;
                }
            }

            return false;
        }

        private void hasNothing()
        {
            _handValue = HandValue.Nothing;

            _usedCards.Add(_allCards[0]);
            _usedCards.Add(_allCards[1]);
            _usedCards.Add(_allCards[2]);
            _usedCards.Add(_allCards[3]);
            _usedCards.Add(_allCards[4]);
        }
    }
}