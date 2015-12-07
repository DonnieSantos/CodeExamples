class Pawn extends Piece

{
  Pawn() { }

  Pawn(int x, int y, char c, Board B)

  {
    super(x,y,c,B);
    if (c == 'W') id = 'P';
    else id = 'p';
  }

  boolean move(int x, int y)

  {
    boolean legal = true;
    char direction = 'X';
 
    if (color == 'W') {
      if ((x == lrow-1) && (y == lcol))   direction = 'M';
      if ((x == lrow-1) && (y == lcol-1)) direction = 'L';
      if ((x == lrow-1) && (y == lcol+1)) direction = 'R';
      if ((x == lrow-2) && (y == lcol))   direction = 'D'; }

    if (color == 'B') {
      if ((x == lrow+1) && (y == lcol))   direction = 'M';
      if ((x == lrow+1) && (y == lcol-1)) direction = 'L';
      if ((x == lrow+1) && (y == lcol+1)) direction = 'R';
      if ((x == lrow+2) && (y == lcol))   direction = 'D'; }

    legal = check_basics(x,y,direction);
   
    if (direction == 'M')
      if (brd.get_piece(x,y).get_id() != ' ')
        legal = false;

    if ((direction == 'L') || (direction == 'R'))
      if (((brd.get_piece(x,y).get_color() != 'B') && (color == 'W'))
       || ((brd.get_piece(x,y).get_color() != 'W') && (color == 'B')))
         legal = false;

    if (direction == 'D')
  
      {
        if (((lrow != 7) && (color == 'W'))
         || ((lrow != 2) && (color == 'B')))
           legal = false;
 
        if (brd.get_piece(x,y).get_id() != ' ')
          legal = false;

        if (((brd.get_piece(x+1,y).get_id() != ' ') && (color == 'W'))
         || ((brd.get_piece(x-1,y).get_id() != ' ') && (color == 'B')))
           legal = false;
      }

    if (legal == true)
   
    {
      go(x,y);

      if (brd.check() == true) {
        unmove();
        legal = false; }
    }

    if ((((lrow == 4) && (x == 3) && (color == 'W'))
      || ((lrow == 5) && (x == 6) && (color == 'B')))
      && (y != 0) && ((y == lcol+1) || (y == lcol-1))
      && (y == brd.get_EPcol()))

    {
      legal = true;
      go(x,y);
 
      if (color == 'W')
        brd.set_piece(4,y,new Blank(4,y,'X',brd));
      else
        brd.set_piece(5,y,new Blank(5,y,'X',brd));
 
      if (brd.check() == true)

      {
        legal = false;

        if (color == 'W')
          brd.set_piece(4,y,new Pawn(4,y,'B',brd));
        else
          brd.set_piece(5,y,new Pawn(5,y,'W',brd));
  
        unmove();
      }

      else if (brd.get_inmate() == true)

      {
        if (color == 'W')
          brd.set_piece(4,y,new Pawn(4,y,'B',brd));
        else
	  brd.set_piece(5,y,new Pawn(5,y,'W',brd));
      }
    }

    return legal;
  }
}
