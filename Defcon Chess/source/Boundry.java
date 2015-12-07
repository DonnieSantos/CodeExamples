class Boundry extends Piece

{
  Boundry() { }

  Boundry(int x, int y, char c, Board B)

  {
    super(x,y,c,B);
    id = 'X';
  }

  boolean move(int x, int y) { return false; }
}