import java.util.*;

class RandomInt

{
  private Random rn = new Random();

  RandomInt() { }

  int rand(int lo, int hi)

  {
    int n = hi - lo + 1;
    int i = rn.nextInt() % n;
    if (i < 0) i = -i;
    return lo+i;
  }
}

class RandomComputer

{ 
  RandomComputer() { }

  int[] CPUmove(Board B)

  {
    int x = 0, y = 0, a = 0, b = 0;
    int turn, str[], rand_int = 1;
    RandomInt R = new RandomInt();

    str = new int [4];
    turn = B.get_turn();

    rand_int = R.rand(1,100);

    for (int i = 1; i <= 8; i++)
    for (int j = 1; j <= 8; j++)

    {
      if (((turn == 1) && (B.get_piece(i,j).get_color() == 'W'))
       || ((turn == 2) && (B.get_piece(i,j).get_color() == 'B')))
         if (B.get_piece(i,j).can_move() == true) {
            x = i;
            y = j; }

      rand_int = R.rand(1,100);
  
      if ((x != 0) && (rand_int > 66))
        break;      
    }

    for (int i = 1; i <= 8; i++)
    for (int j = 1; j <= 8; j++)

    { 
      if (B.get_piece(x,y).move(i,j) == true) {
        a = i;
        b = j;
        B.get_piece(i,j).unmove(); }

      rand_int = R.rand(1,100);
  
      if ((a != 0) && (rand_int > 66))
        break;

      if ((a != 0) && (B.get_piece(a,b).get_id() != ' '))
        break;
    }

    str[0] = x;  str[1] = y;
    str[2] = a;  str[3] = b;

    return str;
  }
}
