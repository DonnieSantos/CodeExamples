#include "stdafx.h"
#include "includes.h"

////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////

int CAMERA_BACK = 475;              // Negative Z Translation.
int window_width, window_height;    // Window dimensions.
int PERSPECTIVE = ON;               // Perspective Projection on.
int TEXTURES_ON = 0;                // Textures Initially Off.
int first = 1;                      // First iteration of display.
int lastx = 0;                      // Last recorded mouse x.
int lasty = 0;                      // Last recorded mouse y.
int DRAW_BOXES = 0;                 // Draw Bounding Boxes.
int DRAW_FILL = 1;                  // Draw Polygon Fills.
int MOUSE_ON = 0;                   // Draw Mouse.
int SABER_ON = 0;                   // Light Saber Weapon.
int BURNER_ON = 0;                  // After Burner.
float BSPEED = 3.0;                 // After Burner Boost.
float LEFT_BOUND = -7;              // Boundary for ship movement.
float RIGHT_BOUND = 25;             // Boundary for ship movement.
float SABER_LENGTH = 0;             // Light Saber Length.
float SABER_MAX = 35;               // Light Saber Max Length.
float SABER_SPEED = 3.0;            // Light Saber Speed.
double DENSITY = 0.0005;            // Fog Density.
int GLOBAL_FOG = 0;                 // Global Fog.
bool B1_PRESSED = false;            // If mouse button 1 is pressed.
bool B2_PRESSED = false;            // If mouse button 2 is pressed.
bool B3_PRESSED = false;            // If mouse button 3 is pressed.
bool first_spin = true;             // First Iteration of Spin.
bool bounced = false;               // Bounce off the Ground.
float mx = -600, my = -600;         // Mouse location.
timer *Timer;                       // Global Timer.
point wax;  point WAX;              // World Axes.
point way;  point WAY;              // World Axes.
point waz;  point WAZ;              // World Axes.
point bg1, bg2, bg3, bg4;           // Background Coordinates.
Matrix *VT;                         // View Transformation Matrix.
Matrix **MV;                        // Modelview Matrix.
Matrix TM;                          // Translation Matrix.
Matrix RM;                          // Rotation Matrix.
Matrix SM;                          // Scaling Matrix.
GLdouble PM[16];                    // OpenGL Projection Matrix.
GLdouble MM[16];                    // OpenGL Modelview Matrix.
GLint VP[4];                        // OpenGL Viewport.

/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////

GLuint tritexture[1];   // Ship Skin.
GLuint texture[9];      // Textures. (NUM_FLOORS + 1)
int NUM_FLOORS = 8;     // How many textures for the floor.
int current_floor = 1;  // The current floor texture.
int num_objects;        // How many total objects.
int selected_object;    // Index of the selected object.
mesh_object** Object;   // The list of all objects.

ship** Ship;
ship playership;
ship playersaber;
ship playerburner;
mesh_object shadow("./objects/Raptor.obj");
mesh_object laserBoltBase("./objects/laserbolt.obj");
mesh_object crosshair("./objects/Reticle.obj");
mesh_object Floor("./objects/huge_floor.obj");
MeshList laserbolts;
ShotList enemy_shots;
shot missile;
int gunCount=2;

vector3D ship_velocity = vector3D(0,0,SHIP_SPEED);
static float xAngle = 0;
static float yAngle = 0;
float XSPEED = 2.0;
float YSPEED = 2.0;
float ZSPEED = 1.5;

/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////

void read_layout()

{
  cout << "Reading Layout..." << endl;

  // Loads the initial object information from the input file.
  // The input file is defined in the macro LAYOUT_FILENAME.

  char str[100];
  char *d;
  char c = 'X', s[1024], p[1024], r[1024];
  int mag;

  float sx, rx, ry, rz, tx, ty, tz;

  FILE *file_ptr = fopen(LAYOUT_FILENAME, "r");

  if (file_ptr == NULL) {
    cout << "Error opening layout file " << LAYOUT_FILENAME << "." << endl;
	exit(1); }

  fscanf(file_ptr, "%d", &num_objects);
  fgets(str, sizeof(str), file_ptr);

  cout << "Number of Objects = " << num_objects << "." << endl;
  Object = new mesh_object * [num_objects];
  selected_object = 0;

  // Go through all object and instanciate them.
  // Then scale, rotate and translate them as specified in the layout.

  for (int i=0; i<num_objects; i++)

  {

	fscanf(file_ptr, "%s %s %s %d %s %f %s %f %s %f %s %f %s %f %s %f %s %f",
		             &s, &p, &r, &mag, &d, &sx, &d, &rx, &d, &ry, &d, &rz, &d, &tx, &d, &ty, &d, &tz);

	fgets(str, sizeof(str), file_ptr);

	Object[i] = new mesh_object(s,p,r,mag);// "./Paths/Translation/Null.pah","./Paths/Rotation/Null.rot", 10); //,p,r,mag);//"./Paths/Translation/TankPatrol.pah","./Paths/Rotation/TankPatrol.rot", 10); 

	Object[i]->scale(sx);
	Object[i]->rotate_x(rx);
	Object[i]->rotate_y(ry);
	Object[i]->rotate_z(rz);
	Object[i]->translate_x(tx);
	Object[i]->translate_y(ty);
	Object[i]->translate_z(tz);
  }

  fclose(file_ptr);
}

void switch_floor()

{
  current_floor++;

  if (current_floor > NUM_FLOORS)
    current_floor = 1;
}

void initialize_matrices()

{
  // Create a modelview matrix for each object.
  MV = new Matrix * [num_objects];


  for (int i=0; i<num_objects; i++) {
	cout << "Initializing MV " << i << "." << endl;
    MV[i] = new Matrix();
	MV[i]->identity(); }

  VT = new Matrix();         // Create view matrix.
  VT->identity();            // View matrix identity.

  // Initialize the view plane.
  TM.translation(-9.3, -5.0, -CAMERA_BACK);   // Negative Z translation.
  VT->mult(&TM, VT);                          // Apply Tz to view matrix.

  // Initialize world and local axes.
  wax.x = 0.0;  wax.y = 0.0;  wax.z = 0.0;
  way.x = 0.0;  way.y = 0.0;  way.z = 0.0;
  waz.x = 0.0;  waz.y = 0.0;  waz.z = 0.0;

  WAX.x = 1.0;  WAX.y = 0.0;  WAX.z = 0.0;
  WAY.x = 0.0;  WAY.y = 1.0;  WAY.z = 0.0;
  WAZ.x = 0.0;  WAZ.y = 0.0;  WAZ.z = 1.0;

  // Initialize background coordinates.
  bg1.x = -470;  bg1.y = -420;  bg1.z = -500;
  bg2.x = 470;   bg2.y = -420;  bg2.z = -500;
  bg3.x = 470;   bg3.y = 420;   bg3.z = -500;
  bg4.x = -470;  bg4.y = 420;   bg4.z = -500;
}

void detect_collision(mesh_object *Obj)

{
  Obj->collision = false;

  // Check against all other objects.
  for (int i=0; i<num_objects; i++)
  if (Obj != Object[i])

  {
	if (Obj->box_collision(Object[i]))
	  Obj->collision = true;
  }

  // Check against all laser bolts.
  if (Obj != playership.mesh)
  for(laserbolts.reset(); laserbolts.currentItem()!=NULL; laserbolts.next())
  
  {
	if (Obj->box_collision(laserbolts.currentItem())) {
	Obj->collision = true;
	Obj->blowUp();
	laserbolts.currentItem()->destroyed=true;
	PlaySound("./audio/Explosion.wav", NULL, SND_ASYNC); }
  }

  // Check against the player ship.
  if (Obj != playership.mesh)
  if (Obj->box_collision(playership.mesh))
    Obj->collision = true;

  // Check against the saber.
  if (Obj != playership.mesh)
  if (Obj != playersaber.mesh)
  if (Obj->box_collision(playersaber.mesh)) {
    Obj->collision = true;
	Obj->blowUp();
	PlaySound("./audio/Explosion.wav", NULL, SND_ASYNC); }
}

// *************************************************************************** //
// ******************************** Textures ********************************* //
// *************************************************************************** //

AUX_RGBImageRec *LoadBMP(char *filename)

{
  FILE *file_ptr = fopen(filename, "r");

  if (file_ptr == NULL) return NULL;

  fclose(file_ptr);

  return auxDIBImageLoad(filename);
}

void LoadTexture(char *filename, int num)

{

  AUX_RGBImageRec *TextureImage[1];

  memset(TextureImage, 1, sizeof(void *)*1);

  if (TextureImage[0]=LoadBMP(filename))

  {
	float h = TextureImage[0]->sizeY;
	float w = TextureImage[0]->sizeX;
	glGenTextures(1, &texture[num]);
	glBindTexture(GL_TEXTURE_2D, texture[num]);
	glTexImage2D(GL_TEXTURE_2D, 0, 3, w, h, 0, GL_RGB, GL_UNSIGNED_BYTE, TextureImage[0]->data);
	glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MIN_FILTER,GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MAG_FILTER,GL_LINEAR);
  }

  if (TextureImage[0])

  {
	if (TextureImage[0]->data)
      free(TextureImage[0]->data);

	free(TextureImage[0]);
  }
}

void LoadTriangleTexture(char *filename, int num)

{
  AUX_RGBImageRec *TextureImage[1];

  memset(TextureImage, 1, sizeof(void *)*1);

  if (TextureImage[0]=LoadBMP(filename))

  {
	float h = TextureImage[0]->sizeY;
	float w = TextureImage[0]->sizeX;
	glGenTextures(1, &tritexture[num]);
	glBindTexture(GL_TEXTURE_2D, tritexture[num]);
	glTexImage2D(GL_TEXTURE_2D, 0, 3, w, h, 0, GL_RGB, GL_UNSIGNED_BYTE, TextureImage[0]->data);
	glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MIN_FILTER,GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MAG_FILTER,GL_LINEAR);
  }

  if (TextureImage[0])

  {
	if (TextureImage[0]->data)
      free(TextureImage[0]->data);

	free(TextureImage[0]);
  }
}

void draw_background()

{
  glColor3f(1,1,1);
  glLoadIdentity();
  glPolygonMode(GL_FRONT, GL_FILL);
  glEnable(GL_TEXTURE_2D);
  glBindTexture(GL_TEXTURE_2D, texture[0]);
  glBegin(GL_QUADS);
    glTexCoord2f(0.0f, 0.0f); glVertex3f(bg1.x, bg1.y,  bg1.z);
	glTexCoord2f(1.0f, 0.0f); glVertex3f(bg2.x, bg2.y,  bg2.z);
	glTexCoord2f(1.0f, 1.0f); glVertex3f(bg3.x, bg3.y,  bg3.z);
	glTexCoord2f(0.0f, 1.0f); glVertex3f(bg4.x, bg4.y,  bg4.z);
  glEnd();
}

void draw_floor()

{
  int i;
  Matrix *FMV = new Matrix();
  FMV->mult(VT, Floor.MT);
  point *worldC = new point [Floor.verts];

  for (i=0; i<Floor.verts; i++) {
    worldC[i] = Floor.vertList[i];
	FMV->transform(&worldC[i].x, &worldC[i].y, &worldC[i].z); }

  glLoadIdentity();
  glBindTexture(GL_TEXTURE_2D, texture[current_floor]);

  glBegin(GL_QUADS);
  point v1 = worldC[Floor.faceList[1].v2];
  point v2 = worldC[Floor.faceList[0].v3];
  point v3 = worldC[Floor.faceList[0].v2];
  point v4 = worldC[Floor.faceList[0].v1];
  glTexCoord2f(0.0f, 0.0f); glVertex3f(v1.x, v1.y, v1.z);
  glTexCoord2f(1.0f, 0.0f); glVertex3f(v2.x, v2.y, v2.z);
  glTexCoord2f(1.0f, 1.0f); glVertex3f(v3.x, v3.y, v3.z);
  glTexCoord2f(0.0f, 1.0f); glVertex3f(v4.x, v4.y, v4.z);
  glEnd();

  glDisable(GL_TEXTURE_2D);
}

// *************************************************************************** //
// ******************************** Crosshair ******************************** //
// *************************************************************************** //

void draw_crosshair()

{
  bool lockon = false;
  double wx, wy, wz;
  double ox, oy, oz;
  float min_x, max_x;
  float min_y, max_y;
  point center = crosshair.get_midpoint(VT);

  glGetDoublev(GL_PROJECTION_MATRIX, PM);
  glGetDoublev(GL_MODELVIEW_MATRIX, MM);
  glGetIntegerv(GL_VIEWPORT, VP);

  gluProject(center.x, center.y, center.z, MM, PM, VP, &wx, &wy, &wz);

  for (int i=0; i<num_objects; i++)

  {
    point minx = Object[i]->MIN_X;
	point maxx = Object[i]->MAX_X;
    point miny = Object[i]->MIN_Y;
	point maxy = Object[i]->MAX_Y;

    gluProject(minx.x, minx.y, minx.z, MM, PM, VP, &ox, &oy, &oz);  min_x = ox;
    gluProject(maxx.x, maxx.y, maxx.z, MM, PM, VP, &ox, &oy, &oz);  max_x = ox;
    gluProject(miny.x, miny.y, miny.z, MM, PM, VP, &ox, &oy, &oz);  min_y = oy;
    gluProject(maxy.x, maxy.y, maxy.z, MM, PM, VP, &ox, &oy, &oz);  max_y = oy;

	if ((wx >= min_x) && (wx <= max_x) && (wy >= min_y) && (wy <= max_y))
	  lockon = true;
  }

  *(crosshair.MT) = *(playership.mesh->MT);
  crosshair.local_translation(0,0,-100);

  if (!lockon) crosshair.draw(VT, DRAW_FILL);
  else crosshair.draw(VT, DRAW_FILL, 1, 0, 0, 0.9);
}

void draw_saber()

{
  if ((!SABER_ON) && (SABER_LENGTH <= 0)) return;

  playersaber.mesh->MT->copy(playership.mesh->MT);
  playersaber.mesh->local_translation(0,0,-33);
  playersaber.mesh->rotate_x(1.6);
  playersaber.mesh->scale(3);
  playersaber.mesh->update_box(VT);

  if ((SABER_ON) && (SABER_LENGTH < SABER_MAX)) SABER_LENGTH += SABER_SPEED;
  if ((!SABER_ON) && (SABER_LENGTH > 0)) SABER_LENGTH -= SABER_SPEED/2;
  float amount = (SABER_LENGTH-100);
  crosshair.local_translation(0,0,-amount);
  point m1 = playership.mesh->get_midpoint(VT);
  point m2 = crosshair.get_midpoint(VT);
  crosshair.local_translation(0,0,amount);

  glLineWidth(10);
  glColor4f(0,1,0,0.5);
  glBegin(GL_LINES);
    glVertex3f(m1.x, m1.y, m1.z);
	glVertex3f(m2.x, m2.y, m2.z);
  glEnd();

  glLineWidth(5);
  glColor4f(0,1,0,0.7);
  glBegin(GL_LINES);
    glVertex3f(m1.x, m1.y, m1.z);
	glVertex3f(m2.x, m2.y, m2.z);
  glEnd();

  glLineWidth(4);
  glColor4f(0,1,0,1);
  glBegin(GL_LINES);
    glVertex3f(m1.x, m1.y, m1.z);
	glVertex3f(m2.x, m2.y, m2.z);
  glEnd();

  glLineWidth(2);
}

void draw_shadow()

{
  float down = playership.mesh->get_midpoint().y - Floor.get_midpoint().y - 2.5;
  float ssize = 1 - (down / 20);
  if (down <= 1) return;
  if (ssize < 0.1) ssize = 0.1;

  shadow.MT->copy(playership.mesh->MT);
  shadow.scale(ssize, 0, ssize);
  shadow.translate(0, -down, 0);
  shadow.draw(VT, DRAW_FILL, 0.2, 0.2, 0.2, 1);
  shadow.translate(0, down, 0);
}

void draw_burner()

{
  //glEnable(GL_BLEND);
  playerburner.mesh->MT->copy(playership.mesh->MT);
  playerburner.mesh->draw(VT, DRAW_FILL);
  //glDisable(GL_BLEND);
}

void toggle_burner()

{
  BURNER_ON = 1 - BURNER_ON;
  
  if (BURNER_ON)  { XSPEED += BSPEED;  YSPEED += BSPEED;  ZSPEED += BSPEED; }
  if (!BURNER_ON) { XSPEED -= BSPEED;  YSPEED -= BSPEED;  ZSPEED -= BSPEED; }

  if (BURNER_ON) PlaySound("./audio/Burner.wav", NULL, SND_ASYNC);
}

// *************************************************************************** //
// ******************************** Display ********************************** //
// *************************************************************************** //

void display(void)

{
  for (int i=0; i<num_objects; i++)
  
  {
	MV[i]->identity();                  // Modelview matrix set to identity.
    MV[i]->mult(MV[i], VT);             // Apply viewing transformations.
    MV[i]->mult(MV[i], Object[i]->MT);  // Apply model transformations.
  }

  //////////////////////////////////////////////////
  //////////////////////////////////////////////////
  // Update and Setup.

  glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
  if (!GLOBAL_FOG) glDisable(GL_FOG);
  draw_background();
  draw_floor();
  if (!GLOBAL_FOG) glEnable(GL_FOG);
  glLoadIdentity();
  glPolygonMode(GL_FRONT, GL_LINE);

  for (i=0; i<num_objects; i++) Object[i]->update_box(VT);
  for (laserbolts.reset(); laserbolts.currentItem()!=NULL; laserbolts.next()) laserbolts.currentItem()->update_box(VT);
  for (enemy_shots.reset(); enemy_shots.currentItem()!=NULL; enemy_shots.next()) enemy_shots.currentItem()->m->update_box(VT);
  playership.mesh->update_box(VT);
  Floor.update_box(VT);

  glEnable(GL_BLEND);
  draw_crosshair();
  draw_saber();
  glDisable(GL_BLEND);

  //////////////////////////////////////////////////
  //////////////////////////////////////////////////
  // Render all Objects.

  for (i=0; i<num_objects; i++)
	
  {
    detect_collision(Object[i]);

	if (TEXTURES_ON) Object[i]->draw(VT, DRAW_FILL, tritexture);
	else Object[i]->draw(VT, DRAW_FILL);

	if(Object[i]->collision) glColor3f(1,0,0);
	else glColor3f(0,1,0);
	if (DRAW_BOXES) Object[i]->drawBB();
  }

  if (BURNER_ON) draw_burner();
  else playership.mesh->draw(VT, DRAW_FILL);
  draw_shadow();

  detect_collision(playership.mesh);
  if(playership.mesh->collision) glColor3f(1,0,0);
  else glColor3f(0,1,0);
  if (DRAW_BOXES) playership.mesh->drawBB();

  glColor3f(0,1,0);
  laserbolts.cleanUp();
  for(laserbolts.reset(); laserbolts.currentItem()!=NULL; laserbolts.next())
    laserbolts.currentItem()->draw(VT, DRAW_FILL);
  glColor3f(1,0,0);
  for(enemy_shots.reset();enemy_shots.currentItem()!=NULL;enemy_shots.next())
	enemy_shots.currentItem()->m->draw(VT, DRAW_FILL);

  glutSwapBuffers();
}

// *************************************************************************** //
// *************************************************************************** //
// *************************************************************************** //

void resize(int x,int y)

{
  // This function is called whenever the window is resized. 
  // Parameters are the new dimentions of the window

  glViewport(0,0,x,y);
  window_width = x;
  window_height = y;

  if (PERSPECTIVE)
  
  {
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluPerspective(FOVY, (GLdouble)window_width/window_height, ZNEAR, ZFAR);
    glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
  }
}

void mouseButton(int button, int state, int x, int y)

{
  if (button == 0 && state == 0) B1_PRESSED = true;  else B1_PRESSED = false;
  if (button == 1 && state == 0) B2_PRESSED = true;  else B2_PRESSED = false;
  if (button == 2 && state == 0) B3_PRESSED = true;  else B3_PRESSED = false;

  if (B1_PRESSED)

  {
	if (gunCount == 1)

	{
	  mesh_object* newbolt=new mesh_object(laserBoltBase);
	  *(newbolt->MT)=*(playership.mesh->MT);
	  laserbolts.insert(newbolt);
	  PlaySound("./audio/Laser.wav", NULL, SND_ASYNC);
	}

	else if (gunCount == 2)

	{
	  mesh_object* newbolt=new mesh_object(laserBoltBase);
	  *(newbolt->MT)=*(playership.mesh->MT);
	  TM.translation(-2.7,0,0);
	  newbolt->MT->mult(newbolt->MT, &TM);
	  laserbolts.insert(newbolt);
	  newbolt=new mesh_object(laserBoltBase);
	  *(newbolt->MT)=*(playership.mesh->MT);
	  TM.translation(2.7,0,0);
	  newbolt->MT->mult(newbolt->MT, &TM);
	  laserbolts.insert(newbolt);
	  PlaySound("./audio/Laser.wav", NULL, SND_ASYNC);
	}
  }

  if (B3_PRESSED)

  {
	SABER_ON = 1 - SABER_ON;
    if (SABER_ON) PlaySound("./audio/Saber.wav", NULL, SND_ASYNC);
	if (!SABER_ON) PlaySound("./audio/SaberOff.wav", NULL, SND_ASYNC);
  }
}

void enemy_shoot(mesh_object* source, shot* prototype)

{
  shot* newshot=new shot(*prototype);

  point enemy_location = source->get_midpoint(VT);
  point player_location = playership.mesh->get_midpoint(VT);

  vector3D v = (vector3D(player_location) - vector3D(enemy_location)).unitV();
  float xz = sqrt(v.x*v.x + v.y*v.y);
  float theta = atan( v.y / xz );
  float sigma = asin( v.z / xz );

  //RM.rotation_x(theta);
  //newshot->m->MT->mult(newshot->m->MT, &RM);
  //RM.rotation_y(sigma);
  //newshot->m->MT->mult(newshot->m->MT, &RM);

  enemy_shots.insert(newshot);
}

void strafe(int x, int y)

{
  // A strafe is a translation of the camera in the world.
  // Take the value of the mouse motion X/Y and apply the
  // corresponding translation matrix to the view matrix.

  //Strafe right.
  if (x < lastx) {
    TM.translation(MOVE_SPEED, 0.0, 0.0);
    VT->mult(&TM, VT); }

  //Strafe left.
  if (x > lastx) {
    TM.translation(-MOVE_SPEED, 0.0, 0.0);
    VT->mult(&TM, VT); }

  //Strafe up.
  if (y < lasty) {
    TM.translation(0.0, -MOVE_SPEED, 0.0);
    VT->mult(&TM, VT); }

  //Strafe down.
  if (y > lasty) {
    TM.translation(0.0, MOVE_SPEED, 0.0);
    VT->mult(&TM, VT); }
}

void look(int x, int y)

{
  // A look is a rotation of the view plane.
  // Take the value of the mouse motion X/Y and apply the
  // corresponding rotation matrix to the view matrix.

  // Look right.
  if (x < lastx) {
    RM.rotation_y(-ROTATION_SPEED);
    VT->mult(&RM, VT); }
  
  // Look left.
  if (x > lastx) {
    RM.rotation_y(ROTATION_SPEED);
    VT->mult(&RM, VT); }

  // Look up.
  if (y < lasty) {
    RM.rotation_x(-ROTATION_SPEED);
    VT->mult(&RM, VT); }

  // Look down.
  if (y > lasty) {
    RM.rotation_x(ROTATION_SPEED);
    VT->mult(&RM, VT); }
}

void mouseMotion(int x, int y)

{
  if ((!first) && (B1_PRESSED)) strafe(x,y);
  else if ((!first) && (!PERSPECTIVE) && (B1_PRESSED)) look(x,y);
  else if ((!first) && (B3_PRESSED))

  {
    // Right Mouse Button Zooming.
    // This is accoplished by applying a scaling.
	// transformation to the view matrix.

    bool moved = false;
    float amount = 1.0;

	if (y > lasty) { amount -= ZOOM_SPEED;  moved = true; }
	if (y < lasty) { amount += ZOOM_SPEED;  moved = true; }

	if (moved == true) {
      SM.scaling(amount, amount, amount);
      VT->mult(VT, &SM); }
  }

  first = 0;  // First iteration is over.
  lastx = x;  // Remember the last value of x.
  lasty = y;  // Remember the last value of y.
}

void passiveMouseMotion(int x, int y)

{
  if (Timer->command_lock > 0) return;

  static bool beenCalled = false;

  // Light Saber Motion.
  if (((abs(x-lastx) > 30) || (abs(y-lasty) > 20)) && (SABER_ON))
  if (Timer->sound_lock == 0)
  
  {
    PlaySound("./audio/SaberMove.wav", NULL, SND_ASYNC);
	Timer->sound_lock = 500;
  }

  if (beenCalled)

  {
    int deltax = x - lastx;
	int deltay = y - lasty;
	ship_velocity.x -= deltax * MOUSE_SENSITIVITY;
	ship_velocity.y -= deltay * MOUSE_SENSITIVITY;
	
	if(ship_velocity.x>TURN_SPEED_CAP)
	  ship_velocity.x=TURN_SPEED_CAP;
	else if(ship_velocity.x<-TURN_SPEED_CAP)
	  ship_velocity.x=-TURN_SPEED_CAP;
	if(ship_velocity.y>TURN_SPEED_CAP)
	  ship_velocity.y=TURN_SPEED_CAP;
	else if(ship_velocity.y<-TURN_SPEED_CAP)
	  ship_velocity.y=-TURN_SPEED_CAP;

	float SS = SHIP_SPEED * SHIP_SPEED;
	float SX = ship_velocity.x*ship_velocity.x;
    float SY = ship_velocity.y*ship_velocity.y;
	ship_velocity.z = sqrt(SS - SX - SY);
	playership.mesh->rotate_y(-xAngle);
	playership.mesh->rotate_x(yAngle);

	// Tilt.
	RM.rotation_z(xAngle/15);
	VT->mult(&RM, VT);
    RM.rotation_z(xAngle/15);
	RM.transform(&bg1.x, &bg1.y, &bg1.z);
	RM.transform(&bg2.x, &bg2.y, &bg2.z);
	RM.transform(&bg3.x, &bg3.y, &bg3.z);
	RM.transform(&bg4.x, &bg4.y, &bg4.z);

	xAngle=atan(ship_velocity.x/MOVE_SPEED);
	yAngle=atan(ship_velocity.y/MOVE_SPEED);
	playership.mesh->rotate_x(-yAngle);
	playership.mesh->rotate_y(xAngle);

	// Tilt.
	RM.rotation_z(-xAngle/15);
	VT->mult(&RM, VT);
    RM.rotation_z(-xAngle/15);
	RM.transform(&bg1.x, &bg1.y, &bg1.z);
	RM.transform(&bg2.x, &bg2.y, &bg2.z);
	RM.transform(&bg3.x, &bg3.y, &bg3.z);
	RM.transform(&bg4.x, &bg4.y, &bg4.z);
  }

  beenCalled = true;
  lastx = x;          // Remember the last value of X.
  lasty = y;          // Remember the last value of Y.
}

void update_window()

{
  if (PERSPECTIVE)
  
  {
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(FOVY, (GLdouble)window_width/window_height, ZNEAR, ZFAR);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glutSetWindowTitle("Perspective Mode");
  }

  else if (!PERSPECTIVE)
  
  {
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(-2.5,2.5,-2.5,2.5,-10000,10000);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glutSetWindowTitle("Orthogonal Mode");
  }
}

void load_fog()

{
  if (DENSITY < 0) DENSITY = 0;

  GLfloat fogcolour[4] = {0.0, 0.0, 0.0, 1.0};	// Black Fog.
  glFogfv(GL_FOG_COLOR,fogcolour);              // Define Color.
  glFogf(GL_FOG_DENSITY,DENSITY);               // Density.
  glFogi(GL_FOG_MODE,GL_EXP);                   // Exponential Decay.
  glFogf(GL_FOG_START,-30.0);                   // Fog Start.
  glFogf(GL_FOG_END,500.0);                     // Fog End.
  glHint(GL_FOG_HINT, GL_FASTEST);              // Compute Per Vertex.
  glEnable(GL_FOG);                             // Enable Fog.
}

void toggle_mouse()

{
  MOUSE_ON = 1 - MOUSE_ON;

  if (MOUSE_ON) ShowCursor(TRUE);
  else ShowCursor(FALSE);
}

void keyboard(unsigned char key, int x, int y)

{
  // This function is called whenever there is a keyboard input
  // key is the ASCII value of the key pressed
  // x and y are the location of the mouse

  switch(key)
  
  {
	case 'd': GLOBAL_FOG = 1 - GLOBAL_FOG; display(); break;
	case 'D': GLOBAL_FOG = 1 - GLOBAL_FOG; display(); break;
	case 'b': DRAW_BOXES = 1 - DRAW_BOXES; display(); break;
	case 'B': DRAW_BOXES = 1 - DRAW_BOXES; display(); break;
	case 'f': DRAW_FILL = 1 - DRAW_FILL; display(); break;
	case 'F': DRAW_FILL = 1 - DRAW_FILL; display(); break;
	case 't': TEXTURES_ON = 1 - TEXTURES_ON; display(); break;
	case 'T': TEXTURES_ON = 1 - TEXTURES_ON; display(); break;
    case 'g': switch_floor(); break;
    case 'G': switch_floor(); break;
    case 'q': exit(0); break;
    case 'Q': exit(0); break;

	case 'a': toggle_burner(); break;
	case 'm': toggle_mouse();  break;

	case 'k': enemy_shoot(Object[10], &missile); break;
	case 's': XSPEED += 0.5;  YSPEED += 0.5;  ZSPEED += 0.5;  break;

	case '=': DENSITY = DENSITY + 0.0001; load_fog(); break;
	case '-': DENSITY = DENSITY - 0.0001; load_fog(); break;

	case '1': gunCount = 1; PlaySound("./audio/Powerup.wav", NULL, SND_ASYNC); break;
	case '2': gunCount = 2; PlaySound("./audio/Powerup.wav", NULL, SND_ASYNC); break;

    default: break;
  }

  glutPostRedisplay();
}

void adjust_camera_horizontal()

{
  playership.mesh->update_box(VT);

  if (playership.mesh->Max_X > RIGHT_BOUND)

  {
    float camera_right = playership.mesh->Max_X - RIGHT_BOUND;
    TM.translation(-camera_right, 0, 0);
	VT->mult(VT, &TM);
	RIGHT_BOUND += camera_right;
	LEFT_BOUND += camera_right;
  }

  if (playership.mesh->Min_X < LEFT_BOUND)

  {
    float camera_left = LEFT_BOUND - playership.mesh->Min_X;
    TM.translation(camera_left, 0, 0);
	VT->mult(VT, &TM);
	LEFT_BOUND -= camera_left;
	RIGHT_BOUND -= camera_left;
  }
}

void bounce()

{
  if (Timer->command_lock > 0) return;

  cout << ship_velocity.y << endl;

  ship_velocity.y -= ship_velocity.y + 0.2;

  if(ship_velocity.y>TURN_SPEED_CAP)
    ship_velocity.y=TURN_SPEED_CAP;
  else if(ship_velocity.y<-TURN_SPEED_CAP)
    ship_velocity.y=-TURN_SPEED_CAP;

  float SS = SHIP_SPEED * SHIP_SPEED;
  float SX = ship_velocity.x*ship_velocity.x;
  float SY = ship_velocity.y*ship_velocity.y;
  ship_velocity.z = sqrt(SS - SX - SY);

  playership.mesh->rotate_y(-xAngle);
  playership.mesh->rotate_x(yAngle);
  xAngle=atan(ship_velocity.x/MOVE_SPEED);
  yAngle=atan(ship_velocity.y/MOVE_SPEED);
  playership.mesh->rotate_x(-yAngle);
  playership.mesh->rotate_y(xAngle);

  PlaySound("./audio/Bounce.wav", NULL, SND_ASYNC);
  Timer->command_lock = 250;
  Timer->sound_lock = 250;
}

// *************************************************************************** //
// ********************************** Spin *********************************** //
// *************************************************************************** //

void Spin()

{
  if (Timer->update() == true)

  {
	if (!first_spin)
    if (playership.mesh->Min_Y < -50) bounce();

	playership.mesh->translate(-ship_velocity.x*XSPEED, -ship_velocity.y*YSPEED, -ship_velocity.z*ZSPEED);
	crosshair.translate(-ship_velocity.x*XSPEED, -ship_velocity.y*YSPEED, -ship_velocity.z*ZSPEED);

    adjust_camera_horizontal();
	TM.translation(0, ship_velocity.y*YSPEED, ship_velocity.z*ZSPEED);
	VT->mult(VT, &TM);

	for(laserbolts.reset(); laserbolts.currentItem()!=NULL; laserbolts.next())
      laserbolts.currentItem()->local_translation(0, 0, -LASER_SPEED);
	for (enemy_shots.reset();enemy_shots.currentItem()!=NULL;enemy_shots.next())
	  enemy_shots.currentItem()->m->local_translation(0, 0, LASER_SPEED);

	for (int i=0; i<num_objects; i++)
	  Object[i]->move();

	Timer->predraw();
    display();
	Timer->postdraw();

	first_spin = false;
  }
}

// *************************************************************************** //
// ********************************** Main *********************************** //
// *************************************************************************** //

int main(int argc, char* argv[])

{
  // Initialize GLUT
  glutInit(&argc, argv);
  glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH);
  glutCreateWindow("Orthogonal Mode");
  glutDisplayFunc(display);
  glutReshapeFunc(resize);
  glutMouseFunc(mouseButton);
  //glutMotionFunc(mouseMotion);
  glutKeyboardFunc(keyboard);
  glutPassiveMotionFunc(passiveMouseMotion);

  // Initialize GL
  glMatrixMode(GL_PROJECTION);
  glLoadIdentity();
  glMatrixMode(GL_MODELVIEW);
  glLoadIdentity();
  glShadeModel(GL_SMOOTH);							    // Enable Smooth Shading
  glClearColor(0.0f, 0.0f, 0.0f, 0.5f);			    	// Black Background
  glClearDepth(1.0f);									// Depth Buffer Setup
  glEnable(GL_DEPTH_TEST);							    // Enables Depth Testing
  glDepthFunc(GL_LEQUAL);								// The Type Of Depth Testing To Do
  glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);	// Really Nice Perspective Calculations
  glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);    // Alpha Blending.
  glEnable(GL_LINE_SMOOTH);
  glLineWidth(2);

  read_layout();          // Read the object data from the layout file.
  initialize_matrices();  // Initialize Model & View Matrices.
  load_fog();             // OpenGL Fog stuff.

  playership.mesh = new mesh_object("./objects/Raptor.obj");
  playersaber.mesh = new mesh_object("./objects/Tower.obj");
  playerburner.mesh = new mesh_object("./objects/RaptorAB.obj");
  playership.mesh->translate_z(CAMERA_BACK-40);
  gravity.identity();
  gravity.translation(0,-9.8/TARGET_FPS,0);
  PERSPECTIVE = 1;
  update_window();

  /////////////////////////////////////////////////
  // Read Textures.

  LoadTexture("./images/bg.bmp", 0);
  LoadTexture("./images/star_map.bmp", 1);
  LoadTexture("./images/street.bmp", 2);
  LoadTexture("./images/blue_floor.bmp", 3);
  LoadTexture("./images/tsunami_floor.bmp", 4);
  LoadTexture("./images/red_floor.bmp", 5);
  LoadTexture("./images/weird.bmp", 6);
  LoadTexture("./images/whirlpool.bmp", 7);
  LoadTexture("./images/campus.bmp", 8);
  LoadTriangleTexture("./images/Swirl.bmp", 0);

  /////////////////////////////////////////////////
  // Start Timer and Go.

  Timer = new timer();
  glutIdleFunc(Spin);
  glutFullScreen();
  ShowCursor(FALSE);
  glutMainLoop();
  return 0;
}