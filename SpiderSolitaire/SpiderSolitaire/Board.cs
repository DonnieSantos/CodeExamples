using System.Collections.Generic;

namespace SpiderSolitaire
{
    public class Board
    {
        public List<Column> Columns { get; set; }

        public Board()
        {
            this.Columns = new List<Column>();
        }

        public void InitalizeColumns()
        {
            for (int i = 0; i < 10; i++)
            {
                this.Columns.Add(new Column());
            }
        }
    }
}
