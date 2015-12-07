using System;
using System.Collections.Generic;

namespace Cards
{
    public class Card : IComparable
    {
        public static List<FaceValue> FaceValuesDesceding = new List<FaceValue>() { FaceValue.Ace, FaceValue.King, FaceValue.Queen, FaceValue.Jack, FaceValue.Ten, FaceValue.Nine, FaceValue.Eight, FaceValue.Seven, FaceValue.Six, FaceValue.Five, FaceValue.Four, FaceValue.Three, FaceValue.Two };
        public static List<SuitValue> SuitValues = new List<SuitValue>() { SuitValue.Spades, SuitValue.Clubs, SuitValue.Hearts, SuitValue.Diamonds };

        public enum FaceValue { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
        public enum SuitValue { Spades, Clubs, Hearts, Diamonds }

        public FaceValue Face { get; set; }
        public SuitValue Suit { get; set; }

        public Card(FaceValue face, SuitValue suit)
        {
            Face = face;
            Suit = suit;
        }

        public static bool operator >(Card arg1, Card arg2)
        {
            return arg1.Face > arg2.Face;
        }

        public static bool operator <(Card arg1, Card arg2)
        {
            return arg1.Face < arg2.Face;
        }

        public override string ToString()
        {
            string padRight = Face == FaceValue.Ten ? "" : " ";

            return "[" +
                (Face.ToString() + Suit.ToString())
                .Replace("Spades", "s")
                .Replace("Clubs", "c")
                .Replace("Hearts", "h")
                .Replace("Diamonds", "d")
                .Replace("Two", "2")
                .Replace("Three", "3")
                .Replace("Four", "4")
                .Replace("Five", "5")
                .Replace("Six", "6")
                .Replace("Seven", "7")
                .Replace("Eight", "8")
                .Replace("Nine", "9")
                .Replace("Ten", "10")
                .Replace("Jack", "J")
                .Replace("Queen", "Q")
                .Replace("King", "K")
                .Replace("Ace", "A")
                + "]" + padRight;
        }

        public int CompareTo(object obj)
        {
            Card card = obj as Card;
            return Face.CompareTo(card.Face);
        }
    }
}