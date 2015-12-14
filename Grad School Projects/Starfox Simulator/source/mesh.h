#ifndef MESH_OBJECT_H
#define MESH_OBJECT_H

#include "path.h"
#include "orientation.h"

// The Mesh Object contains the vertices for an object,
// and the vertices of its bounding box and local axes.

Matrix gravity;

class subSection
{
public:
	int start, end;
	point centroid;
	Matrix *MT;
	Matrix *velocity;
	Matrix *rotation;
	Matrix *netRot;
};

class mesh_object

{
  public:
    mesh_object(char*);                // Constructor.
	mesh_object(char*, char*, char*, int);  // Constructor that takes fpath
	mesh_object(mesh_object&);         // Copy Consructor;
    void meshReader(char*, int);       // Mesh Reader.
	void materialReader(char*);       // Reads .mtl files for material definitions
	void calculate_box();              // Bounding Box.
	void update_box(Matrix *VT);       // Pre-Collision Test.
	bool box_collision(mesh_object*);  // Collision Detection.
	void draw(Matrix*, int);           // Draw Object.
	void drawBB();                     // Draw Bounding Box.
	void draw_square(point*);          // Draw Square.
	void calculate_midpoint();         // Calculate Object Midpoint.
	point get_midpoint();              // Return Object Midpoint.
	point get_midpoint(Matrix*);       // Return Object Midpoint.
	void blowUp();

    int verts, faces, norms;           // Array Size.
    point *vertList, *normList;        // Vertices & Normals.
	point *worldC;                     // World Coordinates.
	point *faceNormals;                // Face Normals.
    faceStruct *faceList;              // All Faces.
	materialList materials;	           // All materials.
	vector3D velocity;                 // Velocity.

	int sections;
	subSection* sectionList;
	bool exploded;                     // Object has been broken into its subcomponents.
	bool destroyed;                    // Object has reached the end of it's lifetime,
	                                   // and needs to be garbage collected.

    point lax;  point LAX;             // Local X Axis.
    point lay;  point LAY;             // Local Y Axis.
    point laz;  point LAZ;             // Local Z Axis.
    Matrix *MT;                        // Model Matrix.

	point midpoint;                    // Object Midpoint.
	point *top, *bot;                  // Bounding Box Points.
	point *left, *right;               // Bounding Box Points.
	point *front, *back;               // Bounding Box Points.
	point Top[4], Bot[4];              // Temporary BB Points.
	point Left[4], Right[4];           // Temporary BB Points.
	point Front[4], Back[4];           // Temporary BB Points.
	float max_x, max_y, max_z;         // Max Coordinates.
	float min_x, min_y, min_z;         // Min Coordinates.
	float Max_X, Max_Y, Max_Z;         // Updated Max Coords.
	float Min_X, Min_Y, Min_Z;         // Updated Min Coords.
	point MAX_X, MAX_Y, MAX_Z;         // Points for Max Coords.
	point MIN_X, MIN_Y, MIN_Z;         // Points for Min Coords.
	bool collision;                    // Collision Detection.

	// Overloaded Draw for a constant color or texture.
	void draw(Matrix*, int, float, float, float, float);
	void draw(Matrix*, int, GLuint *texture);

	// Transformations.
	void local_translation(float, float, float);
	void translate(float, float, float);
	void translate_x(float);
	void translate_y(float);
	void translate_z(float);
	void rotate_x(float);
	void rotate_y(float);
	void rotate_z(float);
	void scale(float, float, float);
	void scale(float);

	int *normCount;

	path movement;
	orientation rotation;
	void move(void);
};

mesh_object::mesh_object(char *filename)

{
  MT = new Matrix();  // Create model matrix.
  MT->identity();     // Model matrix identity.

  movement = path();
  rotation = orientation();

  // Initialize local axes.
  lax.x = 0.0;  lax.y = 0.0;  lax.z = 0.0;
  lay.x = 0.0;  lay.y = 0.0;  lay.z = 0.0;
  laz.x = 0.0;  laz.y = 0.0;  laz.z = 0.0;
  LAX.x = 1.0;  LAX.y = 0.0;  LAX.z = 0.0;
  LAY.x = 0.0;  LAY.y = 1.0;  LAY.z = 0.0;
  LAZ.x = 0.0;  LAZ.y = 0.0;  LAZ.z = 1.0;

  meshReader(filename, 1);    // Read the object.

  calculate_box();            // Calculate bounding box.
  calculate_midpoint();       // Calculate the object midpoint.
  velocity=vector3D(0,0,0);   // Initialize Velocity.
  exploded=false;
  destroyed=false;
}

mesh_object::mesh_object(char *filename, char *fpathname, char *frotname, int nc)

{
  MT = new Matrix();  // Create model matrix.
  MT->identity();     // Model matrix identity.

  int pos = 0;
  movement = path(fpathname);
  movement.setTicCount(nc);
  //pos = movement.Rand();

  rotation = orientation(frotname);
  rotation.setTicCount(nc);
  //rotation.Rand();
  //rotation.setTime(pos);

  // Initialize local axes.
  lax.x = 0.0;  lax.y = 0.0;  lax.z = 0.0;
  lay.x = 0.0;  lay.y = 0.0;  lay.z = 0.0;
  laz.x = 0.0;  laz.y = 0.0;  laz.z = 0.0;
  LAX.x = 1.0;  LAX.y = 0.0;  LAX.z = 0.0;
  LAY.x = 0.0;  LAY.y = 1.0;  LAY.z = 0.0;
  LAZ.x = 0.0;  LAZ.y = 0.0;  LAZ.z = 1.0;

  meshReader(filename, 1);    // Read the object.

  calculate_box();            // Calculate bounding box.
  calculate_midpoint();       // Calculate the object midpoint.
  velocity=vector3D(0,0,0);   // Initialize Velocity.
  exploded=false;
  destroyed=false;

  
}

void mesh_object::move(void)

{
  movement.addTic();
  rotation.addTic();

  rotate_x(rotation.Xro() );
  rotate_y(rotation.Yro() );
  rotate_z(rotation.Zro() );
  
  translate(movement.currentMatrix().M[1][4],
	        movement.currentMatrix().M[2][4],
			movement.currentMatrix().M[3][4]);
}

mesh_object::mesh_object(mesh_object &original)

{
   // Copy consructor.

  MT = new Matrix();
  *MT = *(original.MT);
  lax = original.lax;
  lay = original.lay;
  laz = original.laz;
  LAX = original.LAX;
  LAY = original.LAY;
  LAZ = original.LAZ;
  verts = original.verts;
  faces = original.faces;
  norms = original.norms;
  vertList = original.vertList;
  normList = original.normList;
  faceNormals = original.faceNormals;
  faceList = original.faceList;
  velocity = original.velocity;
  worldC = new point[verts];
  calculate_box();
  calculate_midpoint();
  exploded=original.exploded;
  destroyed=original.destroyed;  
}

void mesh_object::meshReader(char *filename, int sign)

{
  // Read the object from the filename.

  int i;
  float x,y,z,len;
  char s[1024];
  point v1,v2,crossP;
  int ix,iy,iz;
  ifstream input;
  char fpath[1024];

  strcpy(fpath, filename);
  char* slashPos=strrchr(fpath, '/');
  if(slashPos!=NULL)
	*(slashPos+1)='\0';

  input.open(filename);

  if (!input.is_open()) {
    cout << "Cannot open " << filename << "!\n";
	system("pause");
	exit(1); }

  verts = 0;
  faces = 0;
  norms = 0;
  sections=0;

  // Count the number of vertices and faces.
  while(!input.eof())

  {
    input.getline(s, 1023,' ');
    if(!strcmp(s, "v")) verts++;
	else if(!strcmp(s, "f")) faces++;
	else if(!strcmp(s, "o")) sections++;
	else if(!strcmp(s, "mtllib"))
	{
		input.getline(s, 1023,'\n');
		input.putback('\n');
		char mtlfn[1024];
		strcpy(mtlfn, fpath);
		strcat(mtlfn, s);
		materialReader(mtlfn);
	}
	for(char c=0;!input.eof() && c !='\n';c=input.get());
  }

  // Dynamic allocation of vertex and face lists
  faceList = new faceStruct[faces];
  vertList = new point[verts];
  normList = new point[verts];
  faceNormals = new point[faces];
  if(sections>0)
	sectionList = new subSection[sections];

  faces=0;
  verts=0;
  sections=0;
  input.close();
  input.clear();
  input.open(filename);
	
  if (!input.is_open()) {
    std::cout<<"Cannot open "<<filename<<"!\n";
	exit(0); }

  material* currentMaterial=NULL;
  while(!input.eof())

  {
    input.getline(s, 1023,' ');

	if(!strcmp(s, "v"))

	{
	  input >> x >> y >> z;
	  vertList[verts].x = x;
	  vertList[verts].y = y;
	  vertList[verts].z = z;
	  verts++;
	}

	else if(!strcmp(s, "f"))

	{
	  input >> ix;
	  while(input.peek()!=' ') input.get();
	  input >> iy;
	  while(input.peek()!=' ') input.get();
	  input >> iz;
	  faceList[faces].v1 = ix - 1;
	  faceList[faces].v2 = iy - 1;
	  faceList[faces].v3 = iz - 1;
	  faceList[faces].m  = currentMaterial;
	  faces++;
	}

	else if(!strcmp(s, "o"))
	{
		if(sections==0)
			sectionList[0].start=0;
		else
		{
			sectionList[sections-1].end=verts-1;
			sectionList[sections].start=verts;
		}
		sections++;
	}

	else if(!strcmp(s, "usemtl"))
	{
		input.getline(s, 1023,'\n');
		input.putback('\n');
		currentMaterial=materials.find(s);
	}

	for(char c=0;!input.eof() && c !='\n';c=input.get());
  }
  if(sections>0)
    sectionList[sections-1].end=verts-1;
  input.close();

  //calculate section centers
  for(i=0;i<sections;i++)
  {
	  vector3D centroid=vector3D(0,0,0);
	  for(int j=sectionList[i].start;j<=sectionList[i].end;j++)
		centroid+=vector3D(vertList[j].x, vertList[j].y, vertList[j].z);
	  centroid/=(float)(sectionList[i].end-sectionList[i].start+1);
	  sectionList[i].centroid=centroid.toPoint();
  }

  normCount = new int[verts];

  for(i = 0;i < verts;i++)

  {
	normList[i].x = normList[i].y = normList[i].z = 0.0;
	normCount[i] = 0;
  }

  for(i = 0;i < faces;i++)

  {
	v1.x = vertList[faceList[i].v2].x - vertList[faceList[i].v1].x;
	v1.y = vertList[faceList[i].v2].y - vertList[faceList[i].v1].y;
	v1.z = vertList[faceList[i].v2].z - vertList[faceList[i].v1].z;
	v2.x = vertList[faceList[i].v3].x - vertList[faceList[i].v2].x;
	v2.y = vertList[faceList[i].v3].y - vertList[faceList[i].v2].y;
	v2.z = vertList[faceList[i].v3].z - vertList[faceList[i].v2].z;

	crossP.x = v1.y*v2.z - v1.z*v2.y;
	crossP.y = v1.z*v2.x - v1.x*v2.z;
	crossP.z = v1.x*v2.y - v1.y*v2.x;

	len = sqrt(crossP.x*crossP.x + crossP.y*crossP.y + crossP.z*crossP.z);

	crossP.x = -crossP.x/len;
	crossP.y = -crossP.y/len;
	crossP.z = -crossP.z/len;

	faceNormals[i]=crossP;

	normList[faceList[i].v1].x = normList[faceList[i].v1].x + crossP.x;
	normList[faceList[i].v1].y = normList[faceList[i].v1].y + crossP.y;
	normList[faceList[i].v1].z = normList[faceList[i].v1].z + crossP.z;
	normList[faceList[i].v2].x = normList[faceList[i].v2].x + crossP.x;
	normList[faceList[i].v2].y = normList[faceList[i].v2].y + crossP.y;
	normList[faceList[i].v2].z = normList[faceList[i].v2].z + crossP.z;
	normList[faceList[i].v3].x = normList[faceList[i].v3].x + crossP.x;
	normList[faceList[i].v3].y = normList[faceList[i].v3].y + crossP.y;
	normList[faceList[i].v3].z = normList[faceList[i].v3].z + crossP.z;
	normCount[faceList[i].v1]++;
	normCount[faceList[i].v2]++;
	normCount[faceList[i].v3]++;
  }

  worldC=new point[verts];

  for (i = 0;i < verts;i++)

  {
	normList[i].x = (float)sign*normList[i].x / (float)normCount[i];
	normList[i].y = (float)sign*normList[i].y / (float)normCount[i];
	normList[i].z = (float)sign*normList[i].z / (float)normCount[i];

	worldC[i]=vertList[i];
  }
}

void mesh_object::materialReader(char* fn)

{
	ifstream input;
	input.open(fn);

	if(!input.is_open())

	{
		cout << "Cannot open " << fn << "!\n";
		system("pause");
		exit(1);
	}

	material* currentMaterial=NULL;

	while(!input.eof())

	{
		char s[1024];
		input >> s;

		if(!strcmp(s, "newmtl"))

		{
			if(currentMaterial!=NULL)
				materials.add(currentMaterial);
			currentMaterial=new material;
			input.get();
			input.getline(s, 1023,'\n');
			strcpy(currentMaterial->name, s);
		}

		else if(!strcmp(s, "Ns"))
			input >> currentMaterial->ns;
		else if(!strcmp(s, "d") || !strcmp(s, "Tr"))
			input >> currentMaterial->alpha;
		else if(!strcmp(s, "Kd"))
			input >> currentMaterial->kdr >> currentMaterial->kdg >> currentMaterial->kdb;
		else if(!strcmp(s, "Ka"))
			input >> currentMaterial->kar >> currentMaterial->kag >> currentMaterial->kab;
		else if(!strcmp(s, "Ks"))
			input >> currentMaterial->ksr >> currentMaterial->ksg >> currentMaterial->ksb;
		else if(!strcmp(s, "illum"))
			input >> currentMaterial->illum;

		for(char c=0;!input.eof() && c !='\n';c=input.get());
	}

	if(currentMaterial!=NULL)
		materials.add(currentMaterial);

	input.close();
}

void mesh_object::calculate_box()

{
  // This function calculates the vertices of the bounding box
  // by simply calculating the maximum X/Y vertices in the normal
  // vertex list, then applying those to the 6 faces of the box.

  max_x = -10000; min_x = 10000;
  max_y = -10000; min_y = 10000;
  max_z = -10000; min_z = 10000;

  for (int i=0; i<verts; i++)

  {
	// Calculate max_x and min_x.

    if (vertList[i].x > max_x) max_x = vertList[i].x;
    if (vertList[i].y > max_y) max_y = vertList[i].y;
	if (vertList[i].z > max_z) max_z = vertList[i].z;
	if (vertList[i].x < min_x) min_x = vertList[i].x;
    if (vertList[i].y < min_y) min_y = vertList[i].y;
	if (vertList[i].z < min_z) min_z = vertList[i].z;
  }

  top   = new point [4];
  bot   = new point [4];
  left  = new point [4];
  right = new point [4];
  front = new point [4];
  back  = new point [4];

  // Assign vertex coorindates of the bounding box faces
  // based on the minumum and maximum X/Y coordinates.

  top[0].x = min_x;  top[0].y = max_y;  top[0].z = min_z;
  top[1].x = max_x;  top[1].y = max_y;  top[1].z = min_z;
  top[2].x = min_x;  top[2].y = max_y;  top[2].z = max_z;
  top[3].x = max_x;  top[3].y = max_y;  top[3].z = max_z;

  bot[0].x = min_x;  bot[0].y = min_y;  bot[0].z = min_z;
  bot[1].x = max_x;  bot[1].y = min_y;  bot[1].z = min_z;
  bot[2].x = min_x;  bot[2].y = min_y;  bot[2].z = max_z;
  bot[3].x = max_x;  bot[3].y = min_y;  bot[3].z = max_z;

  left[0].x = min_x;  left[0].y = min_y;  left[0].z = min_z;
  left[1].x = min_x;  left[1].y = min_y;  left[1].z = max_z;
  left[2].x = min_x;  left[2].y = max_y;  left[2].z = min_z;
  left[3].x = min_x;  left[3].y = max_y;  left[3].z = max_z;

  right[0].x = max_x;  right[0].y = min_y;  right[0].z = min_z;
  right[1].x = max_x;  right[1].y = min_y;  right[1].z = max_z;
  right[2].x = max_x;  right[2].y = max_y;  right[2].z = min_z;
  right[3].x = max_x;  right[3].y = max_y;  right[3].z = max_z;

  front[0].x = min_x;  front[0].y = min_y;  front[0].z = min_z;
  front[1].x = max_x;  front[1].y = min_y;  front[1].z = min_z;
  front[2].x = min_x;  front[2].y = max_y;  front[2].z = min_z;
  front[3].x = max_x;  front[3].y = max_y;  front[3].z = min_z;

  back[0].x = min_x;  back[0].y = min_y;  back[0].z = max_z;
  back[1].x = max_x;  back[1].y = min_y;  back[1].z = max_z;
  back[2].x = min_x;  back[2].y = max_y;  back[2].z = max_z;
  back[3].x = max_x;  back[3].y = max_y;  back[3].z = max_z;
}

void mesh_object::calculate_midpoint()

{
  midpoint.x = 0;
  midpoint.y = 0;
  midpoint.z = 0;

  for (int i=0; i<4; i++)
  
  {
    midpoint.x += top[i].x;
	midpoint.x += bot[i].x;
    midpoint.y += top[i].y;
	midpoint.y += bot[i].y;
    midpoint.z += top[i].z;
	midpoint.z += bot[i].z;
  }

  midpoint.x = midpoint.x / 8;
  midpoint.y = midpoint.y / 8;
  midpoint.z = midpoint.z / 8;
}

point mesh_object::get_midpoint()

{
  point Midpoint;

  Midpoint.x = midpoint.x;
  Midpoint.y = midpoint.y;
  Midpoint.z = midpoint.z;

  MT->transform(&Midpoint.x, &Midpoint.y, &Midpoint.z);

  return Midpoint;
}

point mesh_object::get_midpoint(Matrix *VT)

{
  point Midpoint;
  Matrix *MV = new Matrix();
  MV->mult(VT, MT);

  Midpoint.x = midpoint.x;
  Midpoint.y = midpoint.y;
  Midpoint.z = midpoint.z;

  MV->transform(&Midpoint.x, &Midpoint.y, &Midpoint.z);

  return Midpoint;
}

void mesh_object::draw(Matrix* viewMatrix, int fill)

{
  // Draw the Object.

  if (!exploded)

  {
    int i;
    Matrix *finalMatrix = new Matrix();
    finalMatrix->mult(viewMatrix, MT);

    for (i=0; i<verts; i++)

	{
      worldC[i] = vertList[i];
	  finalMatrix->transform(&worldC[i].x, &worldC[i].y, &worldC[i].z);
	}

    for (i=0; i<4; i++)

	{
      Top[i] = top[i];
	  Bot[i] = bot[i];
	  Left[i] = left[i];
	  Right[i] = right[i];
	  Front[i] = front[i];
	  Back[i] = back[i];
	  finalMatrix->transform(&Top[i].x, &Top[i].y, &Top[i].z);
	  finalMatrix->transform(&Bot[i].x, &Bot[i].y, &Bot[i].z);
	  finalMatrix->transform(&Left[i].x, &Left[i].y, &Left[i].z);
	  finalMatrix->transform(&Right[i].x, &Right[i].y, &Right[i].z);
	  finalMatrix->transform(&Front[i].x, &Front[i].y, &Front[i].z);
	  finalMatrix->transform(&Back[i].x, &Back[i].y, &Back[i].z);
	}

    material* lastMaterial = NULL;

    glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
    glBegin(GL_TRIANGLES);
    for (i=0; i<faces; i++)
  
	{ 
      if(faceList[i].m != lastMaterial)

	  { 
        if (faceList[i].m != NULL) 
          glColor4f(faceList[i].m->kar, faceList[i].m->kag,
		            faceList[i].m->kab, faceList[i].m->alpha);

        lastMaterial=faceList[i].m; 
	  }

      point v1 = worldC[faceList[i].v1];
	  point v2 = worldC[faceList[i].v2];
	  point v3 = worldC[faceList[i].v3];
	  glVertex3f(v1.x, v1.y, v1.z);
	  glVertex3f(v2.x, v2.y, v2.z);
	  glVertex3f(v3.x, v3.y, v3.z);
	}
    glEnd();

    if (!fill) return;

    ////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////
    // Fill Mode.

    lastMaterial = NULL;

    glPolygonMode(GL_FRONT, GL_FILL);
    glBegin(GL_TRIANGLES);
    for (i=0; i<faces; i++) 
  
	{ 
      if(faceList[i].m != lastMaterial)

	  { 
        if (faceList[i].m != NULL) 
          glColor4f(faceList[i].m->kar+.1, faceList[i].m->kag+.1,
		            faceList[i].m->kab+.1, faceList[i].m->alpha+.1);

        lastMaterial=faceList[i].m; 
	  }

      point v1 = worldC[faceList[i].v1];
	  point v2 = worldC[faceList[i].v2];
	  point v3 = worldC[faceList[i].v3];
	  glVertex3f(v1.x, v1.y, v1.z);
	  glVertex3f(v2.x, v2.y, v2.z);
	  glVertex3f(v3.x, v3.y, v3.z);
	}
    glEnd();
  }

  else
	{
		for(int i=0;i<sections;i++)
		{
			Matrix finalMatrix;
			//sectionList[i].netRot->mult(sectionList[i].rotation, sectionList[i].netRot);
			sectionList[i].MT->mult( sectionList[i].velocity, sectionList[i].MT);
			sectionList[i].velocity->mult(&gravity, sectionList[i].velocity);
			finalMatrix.mult(viewMatrix, sectionList[i].MT);
			for(int j=sectionList[i].start;j<=sectionList[i].end;j++)
			{
				worldC[j] = vertList[j];
			//	sectionList[i].rotation->transform(&worldC[j].x, &worldC[j].y, &worldC[j].z);
				finalMatrix.transform(&worldC[j].x, &worldC[j].y, &worldC[j].z);
			}
		}

		material* lastMaterial = NULL;

		glPolygonMode(GL_FRONT, GL_FILL);
		glBegin(GL_TRIANGLES);
		for (i=0; i<faces; i++) 
		{ 
			if(faceList[i].m != lastMaterial)
			{ 
				if (faceList[i].m != NULL) 
					glColor4f(faceList[i].m->kar, faceList[i].m->kag, faceList[i].m->kab, faceList[i].m->alpha);
				lastMaterial=faceList[i].m; 
			}

			point v1 = worldC[faceList[i].v1];
			point v2 = worldC[faceList[i].v2];
			point v3 = worldC[faceList[i].v3];
			glVertex3f(v1.x, v1.y, v1.z);
			glVertex3f(v2.x, v2.y, v2.z);
			glVertex3f(v3.x, v3.y, v3.z);
		}
		glEnd();
	}

  ////////////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////
}

void mesh_object::draw(Matrix* viewMatrix, int fill, GLuint *texture)

{
  // Draw the Object.

  if (!exploded)

  {
    int i;
    Matrix *finalMatrix = new Matrix();
    finalMatrix->mult(viewMatrix, MT);

    for (i=0; i<verts; i++)

	{
      worldC[i] = vertList[i];
	  finalMatrix->transform(&worldC[i].x, &worldC[i].y, &worldC[i].z);
	}

    for (i=0; i<4; i++)

	{
      Top[i] = top[i];
	  Bot[i] = bot[i];
	  Left[i] = left[i];
	  Right[i] = right[i];
	  Front[i] = front[i];
	  Back[i] = back[i];
	  finalMatrix->transform(&Top[i].x, &Top[i].y, &Top[i].z);
	  finalMatrix->transform(&Bot[i].x, &Bot[i].y, &Bot[i].z);
	  finalMatrix->transform(&Left[i].x, &Left[i].y, &Left[i].z);
	  finalMatrix->transform(&Right[i].x, &Right[i].y, &Right[i].z);
	  finalMatrix->transform(&Front[i].x, &Front[i].y, &Front[i].z);
	  finalMatrix->transform(&Back[i].x, &Back[i].y, &Back[i].z);
	}

    material* lastMaterial = NULL;

	glLoadIdentity();
    glPolygonMode(GL_FRONT, GL_FILL);
    glEnable(GL_TEXTURE_2D);
    glBindTexture(GL_TEXTURE_2D, texture[0]);
    glBegin(GL_TRIANGLES);
    for (i=0; i<faces; i++)
  
	{ 
      if(faceList[i].m != lastMaterial)

	  { 
        if (faceList[i].m != NULL) 
          glColor4f(faceList[i].m->kar, faceList[i].m->kag,
		            faceList[i].m->kab, faceList[i].m->alpha);

        lastMaterial=faceList[i].m; 
	  }

      point v1 = worldC[faceList[i].v1];
	  point v2 = worldC[faceList[i].v2];
	  point v3 = worldC[faceList[i].v3];
	  glTexCoord2f(0.0f, 0.0f); glVertex3f(v1.x, v1.y, v1.z);
	  glTexCoord2f(1.0f, 1.0f); glVertex3f(v2.x, v2.y, v2.z);
	  glTexCoord2f(0.5f, 0.5f); glVertex3f(v3.x, v3.y, v3.z);
	}
    glEnd();
	glDisable(GL_TEXTURE_2D);
  }

  else
	{
		for(int i=0;i<sections;i++)
		{
			Matrix finalMatrix;
			//sectionList[i].netRot->mult(sectionList[i].rotation, sectionList[i].netRot);
			sectionList[i].MT->mult( sectionList[i].velocity, sectionList[i].MT);
			sectionList[i].velocity->mult(&gravity, sectionList[i].velocity);
			finalMatrix.mult(viewMatrix, sectionList[i].MT);
			for(int j=sectionList[i].start;j<=sectionList[i].end;j++)
			{
				worldC[j] = vertList[j];
			//	sectionList[i].rotation->transform(&worldC[j].x, &worldC[j].y, &worldC[j].z);
				finalMatrix.transform(&worldC[j].x, &worldC[j].y, &worldC[j].z);
			}
		}

		material* lastMaterial = NULL;

	    glLoadIdentity();
        glPolygonMode(GL_FRONT, GL_FILL);
        glEnable(GL_TEXTURE_2D);
        glBindTexture(GL_TEXTURE_2D, texture[0]);
        glBegin(GL_TRIANGLES);
		for (i=0; i<faces; i++) 
		{ 
			if(faceList[i].m != lastMaterial)
			{ 
				if (faceList[i].m != NULL) 
					glColor4f(faceList[i].m->kar, faceList[i].m->kag, faceList[i].m->kab, faceList[i].m->alpha);
				lastMaterial=faceList[i].m; 
			}

			point v1 = worldC[faceList[i].v1];
			point v2 = worldC[faceList[i].v2];
			point v3 = worldC[faceList[i].v3];
			glTexCoord2f(0.0f, 0.0f); glVertex3f(v1.x, v1.y, v1.z);
			glTexCoord2f(1.0f, 1.0f); glVertex3f(v2.x, v2.y, v2.z);
			glTexCoord2f(0.5f, 0.5f); glVertex3f(v3.x, v3.y, v3.z);
		}
		glEnd();
		glDisable(GL_TEXTURE_2D);
	}

  ////////////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////
}

void mesh_object::draw(Matrix* viewMatrix, int fill, float R, float G, float B, float alpha)

{
  // Draw the Object with a straight color.

  int i;
  Matrix *finalMatrix = new Matrix();
  finalMatrix->mult(viewMatrix, MT);

  for (i=0; i<verts; i++)

  {
    worldC[i] = vertList[i];
	finalMatrix->transform(&worldC[i].x, &worldC[i].y, &worldC[i].z);
  }

  for (i=0; i<4; i++)

  {
    Top[i] = top[i];
	Bot[i] = bot[i];
	Left[i] = left[i];
	Right[i] = right[i];
	Front[i] = front[i];
	Back[i] = back[i];
	finalMatrix->transform(&Top[i].x, &Top[i].y, &Top[i].z);
	finalMatrix->transform(&Bot[i].x, &Bot[i].y, &Bot[i].z);
	finalMatrix->transform(&Left[i].x, &Left[i].y, &Left[i].z);
	finalMatrix->transform(&Right[i].x, &Right[i].y, &Right[i].z);
	finalMatrix->transform(&Front[i].x, &Front[i].y, &Front[i].z);
	finalMatrix->transform(&Back[i].x, &Back[i].y, &Back[i].z);
  }

  glColor4f(R,G,B,alpha);

  glBegin(GL_TRIANGLES);
  for (i=0; i<faces; i++)

  {
    point v1 = worldC[faceList[i].v1];
	point v2 = worldC[faceList[i].v2];
	point v3 = worldC[faceList[i].v3];
	glVertex3f(v1.x, v1.y, v1.z);
	glVertex3f(v2.x, v2.y, v2.z);
	glVertex3f(v3.x, v3.y, v3.z);
  }
  glEnd();

  if (!fill) return;

  ////////////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////
  // Fill Mode.

  glPolygonMode(GL_FRONT, GL_FILL);

  glBegin(GL_TRIANGLES);
  for (i=0; i<faces; i++)

  {
    point v1 = worldC[faceList[i].v1];
	point v2 = worldC[faceList[i].v2];
	point v3 = worldC[faceList[i].v3];
	glVertex3f(v1.x, v1.y, v1.z);
	glVertex3f(v2.x, v2.y, v2.z);
	glVertex3f(v3.x, v3.y, v3.z);
  }
  glEnd();

  glPolygonMode(GL_FRONT, GL_LINE);

  ////////////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////
}

void mesh_object::drawBB()

{
  // Draw the Bounding Box.

  glPolygonMode(GL_FRONT, GL_LINE);

  draw_square(Top);
  draw_square(Bot);
  draw_square(Left);
  draw_square(Right);
  draw_square(Front);
  draw_square(Back);
}

void mesh_object::draw_square(point *Sq)

{
  // Draw a square with respect to the modelview transformations.

  glBegin(GL_QUADS);
    glVertex3f(Sq[0].x, Sq[0].y, Sq[0].z);
	glVertex3f(Sq[1].x, Sq[1].y, Sq[1].z);
	glVertex3f(Sq[3].x, Sq[3].y, Sq[3].z);
	glVertex3f(Sq[2].x, Sq[2].y, Sq[2].z);
  glEnd();
}

void mesh_object::translate_x(float theta)

{
  // Translation of degree theta across the world X Axis.
  // Apply the translation matrix to the model matrix.
  Matrix TM;
  TM.translation(theta, 0, 0);
  MT->mult(&TM, MT);
}

void mesh_object::translate_y(float theta)

{
  // Translation of degree theta across the world Y Axis.
  // Apply the translation matrix to the model matrix.
  Matrix TM;
  TM.translation(0, theta, 0);
  MT->mult(&TM, MT);
}

void mesh_object::translate_z(float theta)

{
  // Translation of degree theta across the world Z Axis.
  // Apply the translation matrix to the model matrix.
  Matrix TM;
  TM.translation(0, 0, theta);
  MT->mult(&TM, MT);
}

void mesh_object::translate(float trans_x, float trans_y, float trans_z)

{
  // Aribitrary Translation across the world axes.
  Matrix TM;
  TM.translation(trans_x, trans_y, trans_z);
  MT->mult(&TM, MT);
}

void mesh_object::local_translation(float trans_x, float trans_y, float trans_z)

{
  // Aribitrary Translation across the world axes.
  Matrix TM;
  TM.translation(trans_x, trans_y, trans_z);
  MT->mult(MT, &TM);
}

void mesh_object::rotate_x(float theta)

{
  // Rotation of degree theta across the local X Axis.
  // Apply the rotation matrix to the model matrix.
  Matrix RM;
  RM.rotation_x(theta);
  MT->mult(MT, &RM);
}

void mesh_object::rotate_y(float theta)

{
  // Rotation of degree theta across the local Y Axis.
  // Apply the rotation matrix to the model matrix.
  Matrix RM;
  RM.rotation_y(theta);
  MT->mult(MT, &RM);
}

void mesh_object::rotate_z(float theta)

{
  // Rotation of degree theta across the local Z Axis.
  // Apply the rotation matrix to the model matrix.
  Matrix RM;
  RM.rotation_z(theta);
  MT->mult(MT, &RM);
}

void mesh_object::scale(float amount)

{
  // Uniform scaling of amount specified.
  // Apply the scaling matrix to the model matrix.
  Matrix SM;
  SM.scaling(amount, amount, amount);
  MT->mult(MT, &SM);
}

void mesh_object::scale(float sx, float sy, float sz)

{
  // Non-Uniform scaling of amount specified.
  // Apply the scaling matrix to the model matrix.
  Matrix SM;
  SM.scaling(sx, sy, sz);
  MT->mult(MT, &SM);
}

void mesh_object::update_box(Matrix *VT)

{
  // Call this before you do bounding box collision detection.

  Min_X = 10000;  Max_X = -10000;
  Min_Y = 10000;  Max_Y = -10000;
  Min_Z = 10000;  Max_Z = -10000;

  Matrix *MV = new Matrix();
  MV->mult(VT, MT);

  for (int i=0; i<4; i++)
  
  {
    Top[i] = top[i];
	Bot[i] = bot[i];
    MT->transform(&Top[i].x, &Top[i].y, &Top[i].z);
	MT->transform(&Bot[i].x, &Bot[i].y, &Bot[i].z);

	if (Top[i].x < Min_X) { Min_X = Top[i].x;  MIN_X = top[i]; }
    if (Bot[i].x < Min_X) { Min_X = Bot[i].x;  MIN_X = bot[i]; }
	if (Top[i].y < Min_Y) { Min_Y = Top[i].y;  MIN_Y = top[i]; }
    if (Bot[i].y < Min_Y) { Min_Y = Bot[i].y;  MIN_Y = bot[i]; }
	if (Top[i].z < Min_Z) { Min_Z = Top[i].z;  MIN_Z = top[i]; }
    if (Bot[i].z < Min_Z) { Min_Z = Bot[i].z;  MIN_Z = bot[i]; }

    if (Top[i].x > Max_X) { Max_X = Top[i].x;  MAX_X = top[i]; }
    if (Bot[i].x > Max_X) { Max_X = Bot[i].x;  MAX_X = bot[i]; }
	if (Top[i].y > Max_Y) { Max_Y = Top[i].y;  MAX_Y = top[i]; }
    if (Bot[i].y > Max_Y) { Max_Y = Bot[i].y;  MAX_Y = bot[i]; }
	if (Top[i].z > Max_Z) { Max_Z = Top[i].z;  MAX_Z = top[i]; }
    if (Bot[i].z > Max_Z) { Max_Z = Bot[i].z;  MAX_Z = bot[i]; }
  }

  MV->transform(&MIN_X.x, &MIN_X.y, &MIN_X.z);
  MV->transform(&MIN_Y.x, &MIN_Y.y, &MIN_Y.z);
  MV->transform(&MIN_Z.x, &MIN_Z.y, &MIN_Z.z);
  MV->transform(&MAX_X.x, &MAX_X.y, &MAX_X.z);
  MV->transform(&MAX_Y.x, &MAX_Y.y, &MAX_Y.z);
  MV->transform(&MAX_Z.x, &MAX_Z.y, &MAX_Z.z);
}

bool mesh_object::box_collision(mesh_object *Obj)

{
  if (exploded) return false;

  return
  ((Min_X <= Obj->Min_X && Obj->Min_X <= Max_X) || (Obj->Min_X <= Min_X && Min_X <= Obj->Max_X)) &&
  ((Min_Y <= Obj->Min_Y && Obj->Min_Y <= Max_Y) || (Obj->Min_Y <= Min_Y && Min_Y <= Obj->Max_Y)) &&
  ((Min_Z <= Obj->Min_Z && Obj->Min_Z <= Max_Z) || (Obj->Min_Z <= Min_Z && Min_Z <= Obj->Max_Z));
}

void mesh_object::blowUp()
{
	point objCenter=midpoint;
	MT->transform(&objCenter.x, &objCenter.y, &objCenter.z);
	if(!exploded)
	{
		for(int i=0;i<sections;i++)
		{
			sectionList[i].MT=new Matrix();
			*sectionList[i].MT=*MT;
			sectionList[i].velocity=new Matrix();
			MT->transform(&sectionList[i].centroid.x, &sectionList[i].centroid.y, &sectionList[i].centroid.z);
			vector3D v=(vector3D(sectionList[i].centroid)-vector3D(objCenter)).unitV()*DEBRIS_SPEED;
			v+=vector3D(0,DEBRIS_SPEED,0);
			sectionList[i].velocity->translation(v.x, v.y, v.z);
/*
			sectionList[i].rotation=new Matrix;
			sectionList[i].rotation->identity();
			Matrix temp;
			float degrees=DEBRIS_MAX_ROTATION + DEBRIS_MAX_ROTATION*2*(rand()/(RAND_MAX + 1.0));
			temp.rotation_x(degrees);
			sectionList[i].rotation->mult(sectionList[i].rotation, &temp);
			
			degrees=DEBRIS_MAX_ROTATION + DEBRIS_MAX_ROTATION*2*(rand()/(RAND_MAX + 1.0));
			temp.rotation_y(degrees);
			sectionList[i].rotation>mult(sectionList[i].rotation, &temp);
			temp=DEBRIS_MAX_ROTATION + DEBRIS_MAX_ROTATION*2*(rand()/(RAND_MAX + 1.0));
			rotation.rotation_z(degrees);
			sectionList[i].rotation->mult(sectionList[i].rotation, &temp);
			*/
			sectionList[i].netRot=new Matrix;
			sectionList[i].netRot->identity();
		}
		exploded=true;
	}
}

#endif