class Queen extends Piece

{
  Queen() { }

  Queen(int x, int y, char c, Board B)

  {
    super(x,y,c,B);
    if (c == 'W') id = 'Q';
    else id = 'q';
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

    for (int i = 1; i < 8; i++)

    {
      if ((x == lrow+i) && (y == lcol+i)) direction = 'M';
      if ((x == lrow+i) && (y == lcol-i)) direction = 'N';
      if ((x == lrow-i) && (y == lcol+i)) direction = 'K';
      if ((x == lrow-i) && (y == lcol-i)) direction = 'J';
    }

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

    if (direction == 'M')

    {
      distance = y-lcol;
      for (int i = 1; i < distance; i++)
      if (brd.get_piece(lrow+i,lcol+i).get_id() != ' ') legal = false;
    }

    if (direction == 'N')

    {
      distance = lcol-y;
      for (int i = 1; i < distance; i++)
      if (brd.get_piece(lrow+i,lcol-i).get_id() != ' ') legal = false;
    }
 
    if (direction == 'K')

    {
      distance = y-lcol;
      for (int i = 1; i < distance; i++)
      if (brd.get_piece(lrow-i,lcol+i).get_id() != ' ') legal = false;
    }

    if (direction == 'J')

    {
      distance = lcol-y;
      for (int i = 1; i < distance; i++)
      if (brd.get_piece(lrow-i,lcol-i).get_id() != ' ') legal = false;
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
