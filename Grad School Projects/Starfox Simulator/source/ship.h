#ifndef SHIP_H
#define SHIP_H

#define NUM_SHIPS   4
#define PLAYER_SHIP 0
#define ENEMY1_SHIP 2
#define ENEMY2_SHIP 3
#define ENEMY3_SHIP 4

// Just a starter class to associate a ship object
// with a mesh object and add some extra variables.
// (Could use inheritance, but it's not really necessary
// for a small program like this.)

class ship

{
  public:
    ship();

    mesh_object *mesh;

    int hp;
    int ammo;
    int shields;
    int hostile;
};

ship::ship()

{
  mesh = NULL;

  hp       =  10;
  ammo     =  10;
  shields  =  10;
  hostile  =  0;
}

#endif