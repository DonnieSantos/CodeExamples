abstract class Piece

{
  protected int lrow, lcol, prow, pcol;
  protected char id, color;
  protected Board brd;
  
  Piece() { }

  Piece(int x, int y, char c, Board B)

  {
    lrow = x;  lcol = y;
    prow = x;  pcol = y;
    color = c;
    brd = B;
  }

  abstract boolean move(int x, int y);

  void unmove()

  { 
    brd.set_piece(prow,pcol,brd.get_piece(lrow,lcol));
    brd.set_piece(lrow,lcol,brd.get_piece(0,0));
    brd.set_piece(0,0,new Boundry(0,0,'X',brd));

    lrow = prow;
    lcol = pcol;
    
  }

  void go(int x, int y)

  {
    brd.set_piece(0,0,brd.get_piece(x,y));
    brd.set_piece(x,y,brd.get_piece(lrow,lcol));
    brd.set_piece(lrow,lcol,new Blank(lrow,lcol,'X',brd));

    prow = lrow;
    pcol = lcol;
    lrow = x;
    lcol = y;
  }

  boolean check_basics(int x, int y, char d)

  {
    boolean legal = true;

    if ((color == 'X')
    || ((color == 'W') && (brd.get_turn() == 2))
    || ((color == 'B') && (brd.get_turn() == 1)))
      legal = false;

    if (brd.get_piece(x,y).get_color() == color)
      legal = false;

    if ((x > 8) || (x < 1) || (lrow > 8) || (lrow < 1)
     || (y > 8) || (y < 1) || (lcol > 8) || (lcol < 1))
       legal = false;

    if (d == 'X')
      legal = false;

    return legal;
  }

  boolean can_move() 

  {
    boolean canmove = false;

    brd.set_inmate(true);
  
    for (int i = 1; i <= 8; i++)
    for (int j = 1; j <= 8; j++)

    { 
      if (move(i,j) == true) { 
        canmove = true;
        unmove(); } 
    } 
    
    brd.set_inmate(false);

    return canmove;
  }

  void set_prow(int x) { prow = x; }
  void set_pcol(int x) { pcol = x; }
  int get_lrow() { return lrow; }
  int get_lcol() { return lcol; }
  int get_prow() { return prow; }
  int get_pcol() { return pcol; }
  char get_id() { return id; }
  char get_color() { return color; }
}
