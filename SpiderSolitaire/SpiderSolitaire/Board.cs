using System.Collections.Generic;

namespace SpiderSolitaire
{
    public class Board
    {
        public List<Pile> Flops { get; set; }
        public List<Pile> Columns { get; set; }

        public Board(List<Card> allCards)
        {
            Flops = new List<Pile>();
            Columns = new List<Pile>();

            createColumns();

            dealToColumns(allCards, 10, false);
            dealToColumns(allCards, 10, false);
            dealToColumns(allCards, 10, false);
            dealToColumns(allCards, 10, false);
            dealToColumns(allCards, 4, false);
            dealToColumns(allCards, 10, true);

            createFlops();

            dealToFlopPiles(allCards);
        }

        private void createColumns()
        {
            for (int i = 0; i < 10; i++)
            {
                Columns.Add(new Pile());
            }
        }

        private void createFlops()
        {
            for (int i=0; i<5; i++)
            {
                Flops.Add(new Pile());
            }
        }

        private void dealToColumns(List<Card> allCards, int count, bool faceUp)
        {
            for (int i=0; i<count; i++)
            {
                var card = allCards[0];
                card.setFaceUp(faceUp);
                allCards.RemoveAt(0);
                Columns[i].AddCard(card);
            }
        }

        private void dealToFlopPiles(List<Card> allCards)
        {
            for (int i=0; i<5; i++)
            {
                for (int j=0; j<10; j++)
                {
                    var card = allCards[0];
                    card.setFaceUp(false);
                    allCards.RemoveAt(0);
                    Flops[i].AddCard(card);
                }
            }
        }
    }
}
