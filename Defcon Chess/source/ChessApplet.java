import java.applet.*;
import java.awt.Graphics;
import java.awt.event.*;
import java.awt.Image;
import java.awt.Color;
import java.awt.*;
import java.io.*;
import java.net.*;

public class ChessApplet extends Applet
implements MouseListener, MouseMotionListener

{
  boolean buttonpressed = false, pickup = false;
  boolean check, mate;
  Panel side, bigpanel, blank[];
  int x, y, a, b, str[], count = 0;
  int mx, my, px, py, rx, ry, numplayers;
  RandomComputer one, two;
  Button startbutton;
  ImageManager IM;
  Label checkbox, errorbox, titlebox, otherbox, pturnbox;
  Graphics myg;
  TextArea t;
  Image img;
  Choice options;
  Board B;
  Piece P;
  Font checkfont, errorfont, titlefont, otherfont, pturnfont;
  AudioClip sound1, sound2, sound3, sound4;
  AudioClip sound5, sound6, sound7, sound8;

  public void init()

  {
    B = new Board();
    one = new RandomComputer();
    two = new RandomComputer();
    IM = new ImageManager(this);
    numplayers = 1;

    setLayout(new BorderLayout());
    setBackground(Color.black);

    img = createImage(473,750);
    myg = img.getGraphics();

    side = new Panel();
    side.setLayout(new BorderLayout());
    side.setBackground(Color.black);
    side.setSize(600,600);
    bigpanel = new Panel();
    bigpanel.setLayout(new GridLayout(7,1));
    bigpanel.setBackground(Color.blue);
    t = new TextArea("***  MOVE HISTORY  ***\n" +
    "---------------------------------\n",10,37);
    t.setBackground(Color.green);
    t.setEditable(false);

    blank = new Panel [7];

    for (int i = 0; i < 7; i++) {
      blank[i] = new Panel();
      blank[i].setBackground(Color.blue);
      bigpanel.add(blank[i]); }

    options = new Choice();
    options.addItem("One Player Game");
    options.addItem("Two Player Game");
    options.addMouseListener(this);
    blank[2].add(options);

    startbutton = new Button("     New Game     ");
    startbutton.addMouseListener(this);
    blank[3].add(startbutton, "Center");

    checkfont = new Font("Banana-Font",2,20);
    errorfont = new Font("Apple-Font",12,20);
    titlefont = new Font("BigLime-Font",18,30);
    otherfont = new Font("LilLime-Font",18,20);
    pturnfont = new Font("Nocolor-Font",14,20);
    checkbox = new Label("Game Start !! =)");
    errorbox = new Label("Good Luck. :P");
    titlebox = new Label("Defcon Chess 3.1");
    otherbox = new Label("by: Donnie Santos");
    pturnbox = new Label("White Player Turn");
    checkbox.setSize(300,300);
    errorbox.setSize(300,300);
    titlebox.setSize(300,300);
    otherbox.setSize(300,300);
    pturnbox.setSize(300,300);
    checkbox.setForeground(Color.yellow);
    errorbox.setForeground(Color.red);
    titlebox.setForeground(Color.green);
    otherbox.setForeground(Color.green);
    pturnbox.setForeground(Color.white);
    checkbox.setFont(checkfont);
    errorbox.setFont(errorfont);
    titlebox.setFont(titlefont);
    otherbox.setFont(otherfont);
    pturnbox.setFont(pturnfont);
    blank[5].add(checkbox, "Center");
    blank[6].add(errorbox, "Center");
    blank[0].add(titlebox, "Center");
    blank[1].add(otherbox, "Center");
    blank[4].add(pturnbox, "Center");

    side.add(t, "South");
    side.add(bigpanel, "Center");

    add(side,"East");
    addMouseListener(this);
    addMouseMotionListener(this);

    sound1 = getAudioClip("audio/chess.au");
    sound2 = getAudioClip("audio/play.au");
    sound3 = getAudioClip("audio/side.au");
    sound4 = getAudioClip("audio/drop.au");
    sound5 = getAudioClip("audio/bad.au");
    sound6 = getAudioClip("audio/sorry.au");
    sound7 = getAudioClip("audio/excelent.au");
    sound8 = getAudioClip("audio/excelent.au");

    sound1.play();  sound1.stop();  sound8.play();  sound8.stop();
    sound7.play();  sound7.stop();  sound6.play();  sound6.stop();
    sound5.play();  sound5.stop();  sound4.play();  sound4.stop();
    sound3.play();  sound3.stop();  sound2.play();  sound2.stop();
    sound1.play();
  }

  public void mousePressed(MouseEvent me)

  {
    Component c = (Component)me.getSource();
    px = me.getX();
    py = me.getY();

    if (c instanceof Choice)
    
    {
      sound3.play();
    }

    if (c instanceof Button)
      buttonpressed = true;

    else

    {				
      x = IM.getXY(py);
      y = IM.getXY(px);       

      if (((x > 0) && (y > 0) && (B.get_piece(x,y).get_id() != ' '))
        && (((B.get_piece(x,y).get_color() == 'W') && (B.get_turn() == 1))
         || ((B.get_piece(x,y).get_color() == 'B') && (B.get_turn() == 2))))    
           pickup = true;		
    }

    if (pickup == true)

    {
      P = B.get_piece(x,y);
      B.set_piece(x,y,new Blank(x,y,'X',B));
    }
  }		

  public void mouseReleased(MouseEvent me)

  {
    Component c = (Component)me.getSource();
    rx = me.getX();
    ry = me.getY();

    if ((c instanceof Button) && (buttonpressed == true))

    {
      B = new Board();
      pturnbox.setText("");
      pturnbox.setForeground(Color.white);
      pturnbox.setText("White Player Turn");
      checkbox.setText("Game Start !! =)");
      errorbox.setText("Good Luck. :P");
      sound2.play();

      if (options.getSelectedItem() == "One Player Game")
        numplayers = 1;
      if (options.getSelectedItem() == "Two Player Game")
        numplayers = 2;
      if (options.getSelectedItem() == "Computer vs Computer")
        numplayers = 0;

      count = 0;
      t.setText("*** MOVE HISTORY ***\n" +
      "---------------------------------\n");
    }

    if (pickup == true)

    {
      a = IM.getXY(ry);
      b = IM.getXY(rx);
      B.set_piece(x,y,P);

      if (B.get_piece(x,y).move(a,b))

      {
        count++;
        B.set_specials(x,y,a,b);
        B.change_turn();
        errorbox.setText("");

        if (B.get_turn() == 1) {
          pturnbox.setText("");
          pturnbox.setForeground(Color.white);
          pturnbox.setText("White Player Turn"); }
        else {
          pturnbox.setText("");
          pturnbox.setForeground(Color.black);
          pturnbox.setText("Black Player Turn"); }
                
        check = B.check();
        mate = B.mate();

        if ((check == false) && (mate == false)) {
          sound4.play();
          checkbox.setText(""); }

        if ((check == true) && (mate == false)) {
          sound8.play();
          checkbox.setText("     CHECK !!"); }

        if ((mate == true) && (check == true)) {
          sound7.play();
          B.set_turn(3);
          pturnbox.setText("");
          checkbox.setText("CHECKMATE !!!"); }  
       
        if ((mate == true) && (check == false)) {         
          sound6.play();
          B.set_turn(3);
          pturnbox.setText("");
          checkbox.setText("  STALEMATE"); }

        t.appendText(count + ".)   <" + B.get_piece(a,b).get_id() 
        + ">   [" + x + "," + IM.get_column(y) + "]   to   ["
        + a + "," + IM.get_column(b) + "]\n");

        if ((numplayers == 1) && (B.get_turn() == 2))
          
          {
            str = two.CPUmove(B);

            x = str[0];  y = str[1];
            a = str[2];  b = str[3];

            B.get_piece(x,y).move(a,b);

	    count++;
            B.change_turn();
            B.set_specials(x,y,a,b);
	    errorbox.setText("");

            pturnbox.setText("");
            pturnbox.setForeground(Color.white);
            pturnbox.setText("White Player Turn");

            check = B.check();
            mate = B.mate();

            if ((check == false) && (mate == false)) {
              sound4.play();
              checkbox.setText(""); }

            if ((check == true) && (mate == false)) {
              sound8.play();
              checkbox.setText("     CHECK !!"); }

            if ((mate == true) && (check == true)) {
              sound7.play();
              B.set_turn(3);
              pturnbox.setText("");
              checkbox.setText("CHECKMATE !!!"); }  
       
            if ((mate == true) && (check == false)) {         
              sound6.play();
              B.set_turn(3);
              pturnbox.setText("");
              checkbox.setText("  STALEMATE"); }

            t.appendText(count + ".)   <" + B.get_piece(a,b).get_id() 
            + ">   [" + x + "," + IM.get_column(y) + "]   to   ["
            + a + "," + IM.get_column(b) + "]\n");
          }
      } 

      else
 
      {
        if ((x == a) && (y == b))
          errorbox.setText("");
        else {
          sound5.play();
          errorbox.setText("   Illegal Move!"); }                  

        if (B.check() == true) checkbox.setText("     CHECK !!");
          else checkbox.setText("");
      }
    }

    pickup = false;
    buttonpressed = false;
  }

  public void mouseEntered(MouseEvent me)

  {
    buttonpressed = false;
  }

  public void mouseExited(MouseEvent me)

  {
    buttonpressed = false;
  }

  public void mouseClicked(MouseEvent me) { }

  public void mouseDragged(MouseEvent me)

  { 
    mx = me.getX();
    my = me.getY();
  }

  public void mouseMoved(MouseEvent me)

  {
    mx = me.getX();
    my = me.getY();
  }

  public void update(Graphics g)

  {
    paint(g);
  }

  public void paint(Graphics g)

  {
    g.drawImage(img, 0, 0, this);
    mypaint();
  }

  public void mypaint()

  {
    myg.drawImage(IM.get_board(), 0, 0, this);

    for (int i = 1; i <= 8; i++)
    for (int j = 1; j <= 8; j++)
      if (B.get_piece(i,j).get_id() != ' ')
        myg.drawImage(IM.get_image(B.get_piece(i,j).get_id()),
                      IM.map(i,j,1), IM.map(i,j,2), this);

    if (pickup == true)
      myg.drawImage(IM.get_image(P.get_id()), mx-25, my-30, this);

    repaint();
  }

  public Image getImage(String filename) 

  {
    URL imageURL = getClass().getResource(filename);
    Image img = getImage(imageURL);

    return img;
  }

  public AudioClip getAudioClip(String filename)

  {
    URL audioURL = getClass().getResource(filename);
    AudioClip aud = getAudioClip(audioURL);

    return aud;
  }
}
