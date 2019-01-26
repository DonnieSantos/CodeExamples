namespace SpiderSolitaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.InitalizeColumns();

            Deck deck = new Deck();
            deck.Shuffle();
            deck.Print();

            System.Threading.Thread.Sleep(10000);
        }
    }
}