class Rook extends Piece
{
  Rook() { }

  Rook(int x, int y, char c, Board B)

  {
    super(x,y,c,B);
    if (c == 'W') id = 'R';
    else id = 'r';
  }

  boolean move(int x, int y)
 
  {
    boolean legal = true;
    char direction = 'X';
    int distance = 0;

    if ((y == lcol) && (x < lrow)) direction = 'U';
    if ((y == lcol) && (x > lrow)) direction = 'D';
    if ((x == lrow) && (y < lcol)) direction = 'L';
    if ((x == lrow) && (y > lcol)) direction = 'R';

    legal = check_basics(x,y,direction);

    if (direction == 'U')
  
    {
      distance = lrow-x;
      for (int i = 1; i < distance; i++)
      if (brd.get_piece(lrow-i,y).get_id() != ' ') legal = false;
    }

    if (direction == 'D')

    {
      distance = x-lrow;
      for (int i = 1; i < distance; i++)
      if (brd.get_piece(lrow+i,y).get_id() != ' ') legal = false;
    }

    if (direction == 'L')

    {
      distance = lcol-y;
      for (int i = 1; i < distance; i++)
      if (brd.get_piece(x,lcol-i).get_id() != ' ') legal = false;
    }

    if (direction == 'R')

    {
      distance = y-lcol;
      for (int i = 1; i < distance; i++)
      if (brd.get_piece(x,lcol+i).get_id() != ' ') legal = false;
    }

    if (legal == true)
   
    {
      go(x,y);

      if (brd.check() == true) {
        unmove();
        legal = false; }
    }

    return legal;
  }
}
