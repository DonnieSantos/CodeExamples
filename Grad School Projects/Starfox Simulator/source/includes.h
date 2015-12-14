#include <cstdlib>
#include <iostream>
#include <fstream>
#include <process.h>
#include <time.h>
#include <math.h>
#include <vector>
#include "string.h"
#include <windows.h>
#include <stdio.h>
#include <stdarg.h>
#include "glut.h"
#include <GL/gl.h>
#include <GL/glu.h>
#include <gl\glaux.h>

// Perspective.
#define FOVY 60
#define ZFAR 2000
#define ZNEAR 0.1

// Movement.
#define ROTATION_SPEED 0.05
#define ZOOM_SPEED 0.05
#define MOVE_SPEED 0.50
#define SHIP_SPEED 0.75
#define TURN_SPEED_CAP 0.5
#define LASER_SPEED 10.0
#define MOUSE_SENSITIVITY 0.002

#define ON 1
#define OFF 0
#define TARGET_FPS          (double)60
#define FRAME_LENGTH_MS     (1000 / TARGET_FPS)
#define DEBRIS_SPEED 3.0
#define DEBRIS_MAX_ROTATION 1.5/TARGET_FPS

#pragma comment(lib, "opengl32.lib")
#pragma comment(lib, "glu32.lib")
#pragma comment(lib, "winmm.lib")

#define LAYOUT_FILENAME "./objects/layout1.dat"

using std::ifstream;
using std::ofstream;
using std::ios;
using std::cout;
using std::endl;
using std::vector;

#include "point.h"
#include "materials.h"
#include "3D_Matrix.h"
#include "vector3D.h"
#include "materials.h"
#include "mesh.h"
#include "ship.h"
#include "timer.h"
#include "intersect.h"
#include "shot.h"
#include "orientation.h"
#include "path.h"
#include "objectList.h"