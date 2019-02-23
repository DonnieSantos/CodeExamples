namespace SpiderSolitaire
{
    public enum CardValue
    {
        sA, s2, s3, s4, s5, s6, s7, s8, s9, sT, sJ, sQ, sK
    }

    public class Card
    {
        public bool IsFaceUp { get; set; }
        public CardValue Value { get; set; }

        public Card(CardValue value)
        {
            Value = value;
            IsFaceUp = false;
        }

        public void setFaceUp(bool faceUp)
        {
            IsFaceUp = faceUp;
        }
    }
}