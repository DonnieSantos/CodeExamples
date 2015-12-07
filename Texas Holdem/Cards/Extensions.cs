using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cards
{
    public static class Extensions
    {
        public static string ToFormattedString(this List<Card> cards)
        {
            StringBuilder output = new StringBuilder("");

            foreach (Card card in cards)
            {
                output.Append(card.ToString() + " ");
            }

            return output.ToString();
        }

        public static Card GetCard(this List<Card> cards, Card.FaceValue faceValue, Card.SuitValue suitValue)
        {
            foreach (Card card in cards)
            {
                if (card.Face == faceValue && card.Suit == suitValue)
                {
                    return card;
                }
            }

            return null;
        }

        public static bool HetSuit(this List<Card> cards, Card.SuitValue suitValue)
        {
            foreach (Card card in cards)
            {
                if (card.Suit == suitValue)
                {
                    return true;
                }
            }

            return false;
        }

        public static Card GetCard(this List<Card> cards)
        {
            Card firstCard = cards[0];
            cards.RemoveAt(0);
            return firstCard;
        }

        public static List<Card> GetCards(this List<Card> cards, int count)
        {
            List<Card> firstCards = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                firstCards.Add(cards.GetCard());
            }

            return firstCards;
        }

        public static Dictionary<Card.FaceValue, List<Card>> HashByFaceValue(this List<Card> cards)
        {
            var hash = new Dictionary<Card.FaceValue, List<Card>>();

            foreach (Card.FaceValue faceValue in Card.FaceValuesDesceding)
            {
                hash[faceValue] = new List<Card>();
            }

            foreach (Card card in cards)
            {
                hash[card.Face].Add(card);
            }

            foreach (Card.FaceValue faceValue in Card.FaceValuesDesceding)
            {
                hash[faceValue].Sort();
                hash[faceValue].Reverse();
            }

            return hash;
        }

        public static Dictionary<Card.SuitValue, List<Card>> HashBySuitValue(this List<Card> cards)
        {
            var hash = new Dictionary<Card.SuitValue, List<Card>>();

            foreach (Card.SuitValue suitValue in Card.SuitValues)
            {
                hash[suitValue] = new List<Card>();
            }

            foreach (Card card in cards)
            {
                hash[card.Suit].Add(card);
            }

            foreach (Card.SuitValue suitValue in Card.SuitValues)
            {
                hash[suitValue].Sort();
                hash[suitValue].Reverse();
            }

            return hash;
        }

        public static List<Card> GetHighestCards(this Dictionary<Card.FaceValue, List<Card>> hash, int count)
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                cards.Add(hash.GetHighestCard());
            }

            return cards;
        }

        public static Card GetHighestCard(this Dictionary<Card.FaceValue, List<Card>> hash)
        {
            return hash.GetHighestPair(1)[0];
        }

        public static List<Card> GetHighestPair(this Dictionary<Card.FaceValue, List<Card>> hash, int count)
        {
            foreach (Card.FaceValue faceValue in Card.FaceValuesDesceding)
            {
                if (hash[faceValue].Count >= count)
                {
                    return hash[faceValue].GetCards(count);
                }
            }

            return null;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            int n = list.Count;

            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}