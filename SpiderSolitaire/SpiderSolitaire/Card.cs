namespace SpiderSolitaire
{
    public enum CardValue
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
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