namespace SpiderSolitaire
{
    public enum CardValue
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }

    public class Card
    {
        public CardValue Value { get; set; }
        public Card(CardValue value)
        {
            this.Value = value;
        }
    }
}