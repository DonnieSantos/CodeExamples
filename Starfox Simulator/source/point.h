#ifndef POINT_H
#define POINT_H
#include "materials.h"

class point {
public:
  float x,y,z;
};

class faceStruct {
public:
  int v1,v2,v3;
  int n1,n2,n3;
  material* m;
};

#endif