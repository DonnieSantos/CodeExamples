class Copier

{
  Copier() { }

  Board Copy(Board B)

  {
    Board C = new Board();

    if (B.get_turn() == 2)
      C.change_turn();

    C.set_enpassante(B.get_EProw(),B.get_EPcol());
    
    C.set_C1L(B.get_C1L());
    C.set_C1R(B.get_C1R());
    C.set_C2L(B.get_C2L());
    C.set_C2R(B.get_C2R());
    C.set_inmate(B.get_inmate());

    for (int i = 0; i <= 9; i++)
    for (int j = 0; j <= 9; j++)

    {
      if (B.get_piece(i,j).get_id() == ' ')
        C.set_piece(i,j,new Blank(i,j,'X',C));
      if (B.get_piece(i,j).get_id() == 'X')
        C.set_piece(i,j,new Pawn(i,j,'X',C));

      if (B.get_piece(i,j).get_id() == 'P')
        C.set_piece(i,j,new Pawn(i,j,'W',C));
      if (B.get_piece(i,j).get_id() == 'N')
        C.set_piece(i,j,new Knight(i,j,'W',C));
      if (B.get_piece(i,j).get_id() == 'R')
        C.set_piece(i,j,new Rook(i,j,'W',C));
      if (B.get_piece(i,j).get_id() == 'B')
        C.set_piece(i,j,new Bishop(i,j,'W',C));
      if (B.get_piece(i,j).get_id() == 'Q')
        C.set_piece(i,j,new Queen(i,j,'W',C));
      if (B.get_piece(i,j).get_id() == 'K')
        C.set_piece(i,j,new King(i,j,'W',C));

      if (B.get_piece(i,j).get_id() == 'p')
        C.set_piece(i,j,new Pawn(i,j,'B',C));
      if (B.get_piece(i,j).get_id() == 'n')
        C.set_piece(i,j,new Knight(i,j,'B',C));
      if (B.get_piece(i,j).get_id() == 'r')
        C.set_piece(i,j,new Rook(i,j,'B',C));
      if (B.get_piece(i,j).get_id() == 'b')
        C.set_piece(i,j,new Bishop(i,j,'B',C));
      if (B.get_piece(i,j).get_id() == 'q')
        C.set_piece(i,j,new Queen(i,j,'B',C));
      if (B.get_piece(i,j).get_id() == 'k')
        C.set_piece(i,j,new King(i,j,'B',C));

      C.get_piece(i,j).set_prow(B.get_piece(i,j).get_prow());
      C.get_piece(i,j).set_pcol(B.get_piece(i,j).get_pcol());
    }

    return C;
  }
}