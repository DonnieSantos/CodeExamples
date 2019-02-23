namespace SpiderSolitaire
{
    static class UI
    {
        public static Board board { get; set; }
        public static string input { get; set; }

        public static void PlayerTurn()
        {
            while (!board.isGameOver())
            {
                ClearScreen();
                PrintScreen();
                System.Console.Write(" [x1] [x2] [y?] ---> ");
                input = System.Console.ReadLine();
                board.temp(); // Example of changing board state...

                // 1.) Change Card.cs to Pretty Print
                // 2.) Make UI Input Parser (Figure out what user wants to do)
                // 3.) Implement more methods to change Board State
            }
        }

        public static void ClearScreen()
        {
            System.Console.Clear();
        }

        public static void PrintScreen()
        {
            int maxDepth = board.getDeepestColumn();

            for (int depth = 0; depth < maxDepth; depth++)
            {
                for (int columnIndex = 0; columnIndex < 10; columnIndex++)
                {
                    if (board.Columns[columnIndex].Cards.Count > depth)
                    {
                        board.Columns[columnIndex].PrintCard(depth);
                    }
                }

                System.Console.WriteLine();
            }
        }
    }
}