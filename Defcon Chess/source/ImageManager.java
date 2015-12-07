import java.applet.Applet;
import java.awt.Graphics;
import java.awt.event.*;
import java.awt.Image;
import java.awt.Color;
import java.awt.*;
import java.io.*;
import java.net.*;

class ImageManager

{
  Image chessboard;
  Image wp, wn, wr, wb, wq, wk;
  Image bp, bn, br, bb, bq, bk;
  int row[], col[], map[][][];

  ImageManager() { }

  ImageManager(ChessApplet A)

  {
    row = new int [10];
    col = new int [10];
    map = new int [10][10][3];

    row[1] = 43;   row[2] = 90;   row[3] = 139;  row[4] = 186;
    row[5] = 234;  row[6] = 282;  row[7] = 330;  row[8] = 378;
    col[1] = 39;   col[2] = 86;   col[3] = 135;  col[4] = 182;
    col[5] = 230;  col[6] = 278;  col[7] = 326;  col[8] = 374;

    for (int i = 1; i <= 8; i++)
    for (int j = 1; j <= 8; j++) {
      map[i][j][1] = row[j];
      map[i][j][2] = col[i]; }

    chessboard = A.getImage("images/Board.jpg");
    wp = A.getImage("images/wp.gif");
    wn = A.getImage("images/wn.gif");
    wr = A.getImage("images/wr.gif");
    wb = A.getImage("images/wb.gif");
    wq = A.getImage("images/wq.gif");
    wk = A.getImage("images/wk.gif");
    bp = A.getImage("images/bp.gif");
    bn = A.getImage("images/bn.gif");
    br = A.getImage("images/br.gif");
    bb = A.getImage("images/bb.gif");
    bq = A.getImage("images/bq.gif");
    bk = A.getImage("images/bk.gif");
  }

  Image get_image(char piece)

  {
    if (piece == 'P') return wp;
    if (piece == 'N') return wn;
    if (piece == 'R') return wr;
    if (piece == 'B') return wb;
    if (piece == 'Q') return wq;
    if (piece == 'K') return wk;
    if (piece == 'p') return bp;
    if (piece == 'n') return bn;
    if (piece == 'r') return br;
    if (piece == 'b') return bb;
    if (piece == 'q') return bq;
    if (piece == 'k') return bk;
    return chessboard;
  }

  int getXY(int xy) 

  { 
    if ((xy >= 45)  && (xy <= 92))  return 1;
    if ((xy >= 93)  && (xy <= 140)) return 2;
    if ((xy >= 141) && (xy <= 188)) return 3;
    if ((xy >= 189) && (xy <= 236)) return 4;
    if ((xy >= 237) && (xy <= 284)) return 5;
    if ((xy >= 285) && (xy <= 332)) return 6;
    if ((xy >= 333) && (xy <= 379)) return 7;
    if ((xy >= 380) && (xy <= 425)) return 8;
    return 0;
  }

  char get_column(int col)

  {
    if (col == 1) return 'h';
    if (col == 2) return 'g';
    if (col == 3) return 'f';
    if (col == 4) return 'e';
    if (col == 5) return 'd';
    if (col == 6) return 'c';
    if (col == 7) return 'b';
    if (col == 8) return 'a';
    return 'X';     
  }

  int map(int x, int y, int z) { return map[x][y][z]; }

  Image get_board() { return chessboard; }
  Image get_wp() { return wp; }
  Image get_wn() { return wn; }
  Image get_wr() { return wr; }
  Image get_wb() { return wb; }
  Image get_wq() { return wq; }
  Image get_wk() { return wk; }
  Image get_bp() { return bp; }
  Image get_bn() { return bn; }
  Image get_br() { return br; }
  Image get_bb() { return bb; }
  Image get_bq() { return bq; }
  Image get_bk() { return bk; }
}
