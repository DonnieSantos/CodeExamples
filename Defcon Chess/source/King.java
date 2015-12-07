class King extends Piece
{
  King() { }

  King(int x, int y, char c, Board B)

  {
    super(x,y,c,B);
    if (c == 'W') id = 'K';
    else id = 'k';
  }

  boolean move(int x, int y)

  {
    boolean legal = true;
    char direction = 'X';

    if (((x == lrow)   && (y == lcol+1)) || ((x == lrow)   && (y == lcol-1))
     || ((x == lrow+1) && (y == lcol+1)) || ((x == lrow+1) && (y == lcol-1))
     || ((x == lrow+1) && (y == lcol))   || ((x == lrow-1) && (y == lcol+1))
     || ((x == lrow-1) && (y == lcol-1)) || ((x == lrow-1) && (y == lcol)))
       direction = 'K';

    legal = check_basics(x,y,direction);

    if (legal == true)
   
    {
      go(x,y);

      if (brd.check() == true) {
        unmove();
        legal = false; }
    }

    if ((brd.get_C1L() == true) && (brd.get_turn() == 1)
    && (brd.get_piece(8,2).get_id() == ' ')
    && (brd.get_piece(8,3).get_id() == ' ')
    && (brd.get_piece(8,4).get_id() == ' ')
    && (lrow == 8) && (lcol == 5)
    && (x == 8) && (y == 3) && (brd.check() == false))

    {                
      legal = true;
      go(x,y);

      if (brd.check() == true) {
        unmove();
        legal = false; }

      else if (brd.get_inmate() == false)
        brd.get_piece(8,1).go(8,4);
    }

    if ((brd.get_C1L() == true) && (brd.get_turn() == 1)
    && (brd.get_piece(8,6).get_id() == ' ')
    && (brd.get_piece(8,7).get_id() == ' ')
    && (lrow == 8) && (lcol == 5)
    && (x == 8) && (y == 7) && (brd.check() == false))

    {                
      legal = true;
      go(x,y);

      if (brd.check() == true) {
        unmove();
        legal = false; }

      else if (brd.get_inmate() == false)
        brd.get_piece(8,8).go(8,6);
    }

    if ((brd.get_C2L() == true) && (brd.get_turn() == 2)
    && (brd.get_piece(1,2).get_id() == ' ')
    && (brd.get_piece(1,3).get_id() == ' ')
    && (brd.get_piece(1,4).get_id() == ' ')
    && (lrow == 1) && (lcol == 5)
    && (x == 1) && (y == 3) && (brd.check() == false))

    {                
      legal = true;
      go(x,y);

      if (brd.check() == true) {
        unmove();
        legal = false; }

      else if (brd.get_inmate() == false)
        brd.get_piece(1,1).go(1,4);   
    }

    if ((brd.get_C2R() == true) && (brd.get_turn() == 2)
    && (brd.get_piece(1,6).get_id() == ' ')
    && (brd.get_piece(1,7).get_id() == ' ')
    && (lrow == 1) && (lcol == 5)
    && (x == 1) && (y == 7) && (brd.check() == false))

    {                
      legal = true;
      go(x,y);

      if (brd.check() == true) {
        unmove();
        legal = false; }

      else if (brd.get_inmate() == false)
        brd.get_piece(1,8).go(1,6);
    }

    return legal;
  }
}
