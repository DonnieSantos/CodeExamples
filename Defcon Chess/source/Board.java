class Board

{
  Piece grid[][];
  int turn, EProw, EPcol;
  boolean C1L, C1R, C2L, C2R, inmate;
  
  Board()

  {
    turn = 1;
    EProw = 0;   EPcol = 0;
    C1L = true;  C1R = true;
    C2L = true;  C2R = true;
    inmate = false;

    grid = new Piece [10][10];

    for (int i = 0; i <= 9; i++)
    for (int j = 0; j <= 9; j++)

    {
      if ((i == 0) || (i == 9) || (j == 0) || (j == 9))
        grid[i][j] = new Boundry(i,j,'X',this);
      if ((i >=3 ) && (i <= 6) && (j != 0) && (j != 9))
        grid[i][j] = new Blank(i,j,'X',this);
      if ((i == 7) && (j != 0) && (j != 9))
        grid[i][j] = new Pawn(i,j,'W',this);
      if ((i == 2) && (j != 0) && (j != 9))
        grid[i][j] = new Pawn(i,j,'B',this);
    }

    grid[1][1] = new Rook(1,1,'B',this);
    grid[1][2] = new Knight(1,2,'B',this);
    grid[1][3] = new Bishop(1,3,'B',this);
    grid[1][4] = new Queen(1,4,'B',this);
    grid[1][5] = new King(1,5,'B',this);
    grid[1][6] = new Bishop(1,6,'B',this);
    grid[1][7] = new Knight(1,7,'B',this);
    grid[1][8] = new Rook(1,8,'B',this);

    grid[8][1] = new Rook(8,1,'W',this);
    grid[8][2] = new Knight(8,2,'W',this);
    grid[8][3] = new Bishop(8,3,'W',this);
    grid[8][4] = new Queen(8,4,'W',this);
    grid[8][5] = new King(8,5,'W',this);
    grid[8][6] = new Bishop(8,6,'W',this);
    grid[8][7] = new Knight(8,7,'W',this);
    grid[8][8] = new Rook(8,8,'W',this);
  }

  boolean check() 

  {
    Checker c = new Checker();
    return c.check(this);
  }

  boolean mate()

  {
    boolean cantmove = true, canmove = false;
    int P1row[], P1col[], P2row[], P2col[];
    int size1 = 0, size2 = 0;

    P1row = new int [35];  P1col = new int [35];
    P2row = new int [35];  P2col = new int [35];

    for (int i = 1; i <= 8; i++)
    for (int j = 1; j <= 8; j++)

    {
      if (grid[i][j].get_color() == 'W') {
        size1++;
        P1row[size1] = i;
        P1col[size1] = j; } 

      if (grid[i][j].get_color() == 'B') {
        size2++;
        P2row[size2] = i;
        P2col[size2] = j; } 
    }

    if (turn == 1)
    for (int i = 1; i <= size1; i++)
      if (grid[P1row[i]][P1col[i]].can_move() == true)
        canmove = true;

    if (turn == 2)
    for (int i = 1; i <= size2; i++)
      if (grid[P2row[i]][P2col[i]].can_move() == true)
        canmove = true;

    if (canmove == true) cantmove = false;
    if (canmove == false) cantmove = true;

    if ((size1 == 1) && (size2 == 1))
      cantmove = true;

    return cantmove;
  }

  void set_specials(int x, int y, int a, int b)
  
  {
   if (((x == 7) && (a == 5) && (grid[a][b].get_id() == 'P'))
    && ((grid[5][b-1].get_id() == 'p') || (grid[5][b+1].get_id() == 'p'))) 
      set_enpassante(a,b);
    
    else if (((x == 2) && (a == 4) && (grid[a][b].get_id() == 'p'))
    && ((grid[4][b-1].get_id() == 'P') || (grid[4][b+1].get_id() == 'P')))
      set_enpassante(a,b);

    else set_enpassante(0,0);
    
    if (((x == 8) && (y == 1)) || ((x == 8) && (y == 5)))
      set_C1L(false);
    if (((x == 8) && (y == 8)) || ((x == 8) && (y == 5)))
      set_C1R(false);
    
    if (((x == 1) && (y == 1)) || ((x == 1) && (y == 5)))
      set_C2L(false);
    if (((x == 1) && (y == 8)) || ((x == 1) && (y == 5)))
      set_C2R(false);
               
    if ((grid[a][b].get_id() == 'P') && (a == 1))
      grid[a][b] = new Queen(a,b,'W',this);
      
    if ((grid[a][b].get_id() == 'p') && (a == 8))
      grid[a][b] = new Queen(a,b,'B',this);
  }

  void change_turn()   

  { 
    if (turn == 1) turn = 2;
    else if (turn == 2) turn = 1;
    else turn = 1;
  }

  void set_enpassante(int x, int y)

  {
    EProw = x;  
    EPcol = y;
  }

  Piece get_piece(int x, int y) { return grid[x][y]; }
  void set_piece(int x, int y, Piece p) { grid[x][y] = p; }
  int get_turn() { return turn; }
  void set_turn(int x) { turn = x; }
  int get_EProw() { return EProw; }
  int get_EPcol() { return EPcol; }
  boolean get_C1L() { return C1L; }
  boolean get_C1R() { return C1R; }
  boolean get_C2L() { return C2L; }  
  boolean get_C2R() { return C2R; }
  void set_C1L(boolean b) { C1L = b; }
  void set_C1R(boolean b) { C1R = b; }
  void set_C2L(boolean b) { C2L = b; }
  void set_C2R(boolean b) { C2R = b; }
  boolean get_inmate() { return inmate; }
  void set_inmate(boolean b) { inmate = b; }
}
