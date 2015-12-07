class SmartComputer

{
  int AI_RECURSIVE_DEPTH;
  String name;

  SmartComputer()
  
  {
    AI_RECURSIVE_DEPTH = 1;
    name = "Vince";
  }

  SmartComputer(int Intelligence)

  { 
    AI_RECURSIVE_DEPTH = Intelligence;
    if (Intelligence == 1) name = "Vince";
    if (Intelligence == 2) name = "Palmer";
    if (Intelligence == 3) name = "Fuglister";
    if (Intelligence == 4) name = "Kirschenbaum";
    if (Intelligence == 5) name = "Donnie";
  }

  int[] CPUmove(Board B)

  {  
    int str[], size, MAX_MIN = -1000000;
    int moves[][], x, y, a, b, score;
    
    str = new int [4];
    moves = possible_moves(B);
    size = moves[0][0];
    
    // Initially, size should be 20.  (16 pawn moves, 4 knight moves)

    str[0] = 0;  str[1] = 0;  str[2] = 0;  str[3] = 0;

    for (int i = 1; i <= size; i++)

    {
      x = moves[i][1];  y = moves[i][2];
      a = moves[i][3];  b = moves[i][4];

      score = worst_score(B,x,y,a,b,AI_RECURSIVE_DEPTH);

      // *BANG*

      if (score > MAX_MIN) {
        str[0] = x;
        str[1] = y;
        str[2] = a;
        str[3] = b;
        MAX_MIN = score; }
    }

    return str;
  }

  int evaluate(Board B, int depth)

  {
    char c;
    int turn, score = 0;

    turn = B.get_turn();

    if (turn == 1)
    for(int i = 0; i <= 8; i++)
    for(int j = 0; j <= 8; j++)
       
    {
      c = B.get_piece(i,j).get_id();

      if (c == 'P') score = score + 1;             
      if (c == 'N') score = score + 3;
      if (c == 'B') score = score + 3;
      if (c == 'R') score = score + 5;
      if (c == 'Q') score = score + 10;
      if (c == 'p') score = score - 1;
      if (c == 'n') score = score - 3;
      if (c == 'b') score = score - 3;
      if (c == 'r') score = score - 5;
      if (c == 'q') score = score - 10;
  
      //if (B.check() == true) score = score - 2;
      //if (B.mate() == true) score = ((depth*10000)-1000000);
    }

    if (turn == 2)
    for(int i = 0; i <= 8; i++)
    for(int j = 0; j <= 8; j++)
      
    {
      c = B.get_piece(i,j).get_id();

      if (c == 'P') score = score - 1;             
      if (c == 'N') score = score - 3;
      if (c == 'B') score = score - 3;
      if (c == 'R') score = score - 5;
      if (c == 'Q') score = score - 10;
      if (c == 'p') score = score + 1;
      if (c == 'n') score = score + 3;
      if (c == 'b') score = score + 3;
      if (c == 'r') score = score + 5;
      if (c == 'q') score = score + 10;

      //if (B.check() == true) score = score - 2;
      //if (B.mate() == true) score = ((depth*100000)-1000000);
    }

    return score;
  }

  int[][] possible_moves(Board B)
  
  {
    int moves[][], size = 0;
    int allmoves[][];
  
    moves = new int [1000][5];
  
    for (int x = 1; x <= 8; x++)
    for (int y = 1; y <= 8; y++)
    for (int i = 1; i <= 8; i++)
    for (int j = 1; j <= 8; j++)
  
    {
      if (B.get_piece(x,y).move(i,j) == true)
     
      {
        if (B.check() == false) {       
        size++;
        moves[size][1] = x;
        moves[size][2] = y;
        moves[size][3] = i;
        moves[size][4] = j; }

        B.get_piece(i,j).unmove();
      }          
    }
  
    allmoves = new int [size+1][5];
    allmoves[0][0] = size;
  
    for (int i = 1; i <= size; i++)
    for (int j = 1; j <= 4; j++)
      allmoves[i][j] = moves[i][j];
  
    return allmoves;
  }

  int worst_score(Board TheBoard, int x, int y, int a, int b, int d)

  {
    Copier C;
    Board B;
    int M[][], N[][];
    int size, size2;
    int MIN_SCORE = 1000000, score;
    int RECURSIVE_DEPTH = d;

    C = new Copier();
    B = C.Copy(TheBoard);

    B.get_piece(x,y).go(a,b);
    B.change_turn();

    M = possible_moves(B);
    size = M[0][0];

    for (int i = 1; i <= size; i++)
  
    {
      B.get_piece(M[i][1],M[i][2] ).go(M[i][3],M[i][4]);
      B.change_turn();

      score = evaluate(B,d);

      if (score < MIN_SCORE)
        MIN_SCORE = score;

      if (RECURSIVE_DEPTH > 1)
  
      {
        N = possible_moves(B);
        size2 = N[0][0];
  
        for (int j = 1; j <= size2; j++)
    
        { 
          score = worst_score(B, N[j][1], N[j][2], N[j][3], N[j][4], d-1);
       
          if (score < MIN_SCORE)
            MIN_SCORE = score;
        }
      }
  
      B.change_turn();
      B.get_piece(a,b).unmove();
    }

    if ((size == 0) && (B.check() == true))
      MIN_SCORE = 1000000;
    if ((size == 0) && (B.check() == false))
      MIN_SCORE = -1000000;
 
    return MIN_SCORE;
  }
}
