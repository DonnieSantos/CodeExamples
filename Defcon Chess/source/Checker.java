class Checker

{
  Checker() { }

  boolean check(Board TheBoard)

  { 
    char B[][];
    int x = 0, y = 0, temp, turn;
    boolean done, incheck = false;
  
    B = new char [61][61];
    turn = TheBoard.get_turn();
					
    for (int i = 0; i <= 60; i++)
    for (int j = 0; j <= 60; j++)
      B[i][j] = 'X';

    for (int i = 1; i <= 8; i++)
    for (int j = 1; j <= 8; j++)
 
    { 
      B[i+20][j+20] = TheBoard.get_piece(i,j).get_id();

      if ((B[i+20][j+20] == 'K') && (turn == 1)) {
        x = i+20;
        y = j+20; }

      if ((B[i+20][j+20] == 'k') && (turn == 2)) {
        x = i+20;
        y = j+20; }
    }
                            
    if (((B[x-1][y+1] == 'p') && (turn == 1))
     || ((B[x-1][y-1] == 'p') && (turn == 1))
     || ((B[x+1][y+1] == 'P') && (turn == 2))
     || ((B[x+1][y-1] == 'P') && (turn == 2)))
       incheck = true;
                                             
    if (((B[x+2][y+1] == 'n') && (turn == 1))
    || ((B[x+1][y+2] == 'n') && (turn == 1))
    || ((B[x+2][y-1] == 'n') && (turn == 1))
    || ((B[x+1][y-2] == 'n') && (turn == 1))
    || ((B[x-2][y+1] == 'n') && (turn == 1))
    || ((B[x-1][y+2] == 'n') && (turn == 1))
    || ((B[x-1][y-2] == 'n') && (turn == 1))
    || ((B[x-2][y-1] == 'n') && (turn == 1))
    || ((B[x+2][y+1] == 'N') && (turn == 2))
    || ((B[x+1][y+2] == 'N') && (turn == 2))
    || ((B[x+2][y-1] == 'N') && (turn == 2))
    || ((B[x+1][y-2] == 'N') && (turn == 2))
    || ((B[x-2][y+1] == 'N') && (turn == 2))
    || ((B[x-1][y+2] == 'N') && (turn == 2))
    || ((B[x-1][y-2] == 'N') && (turn == 2))
    || ((B[x-2][y-1] == 'N') && (turn == 2)))
      incheck = true;
                     				
    temp = 0;
    done = false;

    while (done == false)

    {
      temp++;

      if ((B[x-temp][y] == 'r') && (turn == 1)
       || (B[x-temp][y] == 'q') && (turn == 1)
       || (B[x-temp][y] == 'R') && (turn == 2)
       || (B[x-temp][y] == 'Q') && (turn == 2)) {
         done = true;
         incheck = true;  }

      else if (B[x-temp][y] != ' ')
        done = true;

      if (temp == 7) done = true;
    }
			
    temp = 0;
    done = false;
                                     
    while (done == false)

    {
      temp++;

      if ((B[x+temp][y] == 'r') && (turn == 1)
       || (B[x+temp][y] == 'q') && (turn == 1)
       || (B[x+temp][y] == 'R') && (turn == 2)
       || (B[x+temp][y] == 'Q') && (turn == 2)) {
        done = true;
        incheck = true;  }

      else if (B[x+temp][y] != ' ')
        done = true;

      if (temp == 7) done = true;
    }

    temp = 0;
    done = false;

    while (done == false)

    {
      temp++;

      if ((B[x][y-temp] == 'r') && (turn == 1)
       || (B[x][y-temp] == 'q') && (turn == 1)
       || (B[x][y-temp] == 'R') && (turn == 2)
       || (B[x][y-temp] == 'Q') && (turn == 2)) {
         done = true;
         incheck = true;}

      else if (B[x][y-temp] != ' ')
        done = true;

      if (temp == 7) done = true;
    }

    temp = 0;
    done = false;

    while (done == false)
  
    {
      temp++;
  
      if ((B[x][y+temp] == 'r') && (turn == 1)
       || (B[x][y+temp] == 'q') && (turn == 1)
       || (B[x][y+temp] == 'R') && (turn == 2)
       || (B[x][y+temp] == 'Q') && (turn == 2)) {
         done = true;
         incheck = true; }

      else if (B[x][y+temp] != ' ')
        done = true;

      if (temp == 7) done = true;
    }

    temp = 0;
    done = false;

    while (done == false)

    {
      temp++;

      if ((B[x+temp][y+temp] == 'b') && (turn == 1)
       || (B[x+temp][y+temp] == 'q') && (turn == 1)
       || (B[x+temp][y+temp] == 'B') && (turn == 2)
       || (B[x+temp][y+temp] == 'Q') && (turn == 2)) {
         done = true;
         incheck = true; }

      else if (B[x+temp][y+temp] != ' ')
        done = true;

      if (temp == 7) done = true;
    }

    temp = 0;
    done = false;

    while (done == false)

    {
      temp++;
  
      if ((B[x+temp][y-temp] == 'b') && (turn == 1)
       || (B[x+temp][y-temp] == 'q') && (turn == 1)
       || (B[x+temp][y-temp] == 'B') && (turn == 2)
       || (B[x+temp][y-temp] == 'Q') && (turn == 2)) {
         done = true;
         incheck = true; }
  
      else if (B[x+temp][y-temp] != ' ')
        done = true;
  
      if (temp == 7) done = true;
    }

    temp = 0;
    done = false;
  
    while (done == false)
  
    {
      temp++;
  
      if ((B[x-temp][y+temp] == 'b') && (turn == 1)
       || (B[x-temp][y+temp] == 'q') && (turn == 1)
       || (B[x-temp][y+temp] == 'B') && (turn == 2)
       || (B[x-temp][y+temp] == 'Q') && (turn == 2)) {
         done = true;
         incheck = true; }
  
      else if (B[x-temp][y+temp] != ' ')
        done = true;
  
      if (temp == 7) done = true;
    }

    temp = 0;
    done = false;

    while (done == false)

    {
      temp++;

      if ((B[x-temp][y-temp] == 'b') && (turn == 1)
       || (B[x-temp][y-temp] == 'q') && (turn == 1)
       || (B[x-temp][y-temp] == 'B') && (turn == 2)
       || (B[x-temp][y-temp] == 'Q') && (turn == 2)) {
         done = true;
         incheck = true; }

      else if (B[x-temp][y-temp] != ' ')
        done = true;
					
      if (temp == 7) done = true;
    }

    if (((B[x][y+1] == 'k') && (turn == 1))
    || ((B[x][y-1] == 'k') && (turn == 1))
    || ((B[x+1][y+1] == 'k') && (turn == 1))
    || ((B[x+1][y-1] == 'k') && (turn == 1))
    || ((B[x+1][y] == 'k') && (turn == 1))
    || ((B[x-1][y+1] == 'k') && (turn == 1))
    || ((B[x-1][y-1] == 'k') && (turn == 1))
    || ((B[x-1][y] == 'k') && (turn == 1))
    || ((B[x][y+1] == 'K') && (turn == 2))
    || ((B[x][y-1] == 'K') && (turn == 2))
    || ((B[x+1][y+1] == 'K') && (turn == 2))
    || ((B[x+1][y-1] == 'K') && (turn == 2))
    || ((B[x+1][y] == 'K') && (turn == 2))
    || ((B[x-1][y+1] == 'K') && (turn == 2))
    || ((B[x-1][y-1] == 'K') && (turn == 2))
    || ((B[x-1][y] == 'K') && (turn == 2)))
      incheck = true;
      				
    return incheck;
  }
}
