class Knight extends Piece

{
  Knight() { }

  Knight(int x, int y, char c, Board B)

  {
    super(x,y,c,B);
    if (c == 'W') id = 'N';
    else id = 'n';
  }

  boolean move(int x, int y)

  { 
    boolean legal = true;
    char direction = 'X';

    if (((x == lrow+1) && (y == lcol+2)) || ((x == lrow+1) && (y == lcol-2))
     || ((x == lrow+2) && (y == lcol+1)) || ((x == lrow+2) && (y == lcol-1))
     || ((x == lrow-1) && (y == lcol+2)) || ((x == lrow-1) && (y == lcol-2))
     || ((x == lrow-2) && (y == lcol+1)) || ((x == lrow-2) && (y == lcol-1)))
       direction = 'N';
                             
    legal = check_basics(x,y,direction);

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
