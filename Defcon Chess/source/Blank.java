class Blank extends Piece

{
  Blank() { }

  Blank(int x, int y, char c, Board B)

  {
    super(x,y,c,B);
    id = ' ';
  }

  boolean move(int x, int y) { return false; }
}