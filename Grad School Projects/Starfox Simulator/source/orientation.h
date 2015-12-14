#ifndef orientation_H
#define orientation_H

#include <iostream>
#include <iomanip>
#include <cstdlib>
#include "3D_Matrix.h"

class orientation
{
	public:
		orientation(char*);					//Constructor
		orientation(void);						//Constructor
		bool selectorientation(char*);			//Change the orientation to a different
		void addTic(void);				//called each tic
		int getTic(void);				//get the tic count
		void setTicCount(int);			//set speed of movement
		int getToc(void);
		void setTime(int);
		Matrix currentMatrix(void);		//gets the current Matrix
		void Rand(void);				//puts the orientation at a random spot
		float Xro(void);
		float Yro(void);
		float Zro(void);
		


	private:
		bool orientationSet;	//has the orientation been set
		char* fileorientation;			//orientationname of the file containing the orientation
		int orientationTime;		//index of the current orientation matrix
		int tic;			//tics once per swap
		int ticsPerToc;		//each toc, advance orientationTime
		int len;			//length of array
		Matrix direction[10];	//the actual orientation	
		float Xrot[10];
		float Yrot[10];
		float Zrot[10];

};

void orientation::setTime(int nt)
{	orientationTime = nt;	}

orientation::orientation(void)
{	orientationSet = false;	//has the orientation been set
	orientationTime = 0;		//index of the current orientation matrix
	tic = 0;			//tics once per swap
	ticsPerToc = 10;	//each toc, advance orientationTime
	len = 10;			//lenght of all orientations
	
	
}

orientation::orientation(char* fp)
{	fileorientation = fp;
	orientationSet = false;	//has the orientation been set
	orientationTime = 0;		//index of the current orientation matrix
	tic = 0;			//tics once per swap
	ticsPerToc = 10;	//each toc, advance orientationTime
	len = 10;		//lenght of all orientations
	orientationSet = selectorientation(fileorientation);
	
}

bool orientation::selectorientation(char* fp)	//read in from file and set matix using input
{ ifstream input;
  fileorientation = fp;
  input.open(fp);
  char inNumber[256];
  float Xtemp, Ytemp, Ztemp;
  Matrix XRtemp, YRtemp, ZRtemp;
  int index = 0;

  if (!input.is_open()) {
	cout << "could not open " << fp << endl;
	system("pause");
    return false; }

  while(!input.eof() && index<10)
  {	input.getline(inNumber, 256);
	Xtemp = atof(inNumber);
	XRtemp.rotation_x(Xtemp);
	Xrot[index] = Xtemp;

	input.getline(inNumber, 256);
	Ytemp = atof(inNumber);
	YRtemp.rotation_y(Ytemp);
	Yrot[index] = Ytemp;

	input.getline(inNumber, 256);
	Ztemp = atof(inNumber);
	ZRtemp.rotation_z(Ztemp);
	Zrot[index] = Ztemp;

	//direction[index].translation(Xtemp,Ytemp,Ztemp);
	direction[index].mult(&XRtemp,&YRtemp);
	direction[index].mult(&direction[index],&ZRtemp);
	
	index++;
  }
  return true;
}

void orientation::addTic(void)
{	tic++;
	if (tic > ticsPerToc)
	{	tic = 0;
		
		if (orientationTime < len - 1)
			{	orientationTime++;
			}
			else 
			{	
				orientationTime = 0;
			}
	}
}

int orientation::getTic(void)
{	return tic;}

void orientation::setTicCount(int tpc)
{	ticsPerToc = tpc;
}

int orientation::getToc(void)
{	return ticsPerToc;}


Matrix orientation::currentMatrix(void)
{	if (orientationSet)
	{	return direction[orientationTime];
	}
	else
	{
		Matrix trash;
		trash.identity();
		return trash;
	}
}

float orientation::Xro(void)
{
	if (orientationSet)
		return Xrot[orientationTime];
	else
		return 0;
}

float orientation::Yro(void)

{
  if (orientationSet) return Yrot[orientationTime];
  else return 0;
}

float orientation::Zro(void)
{
	if (orientationSet)
		return Zrot[orientationTime];
	else
		return 0;
}

void orientation::Rand(void)
{
	int randomInt = rand();
	orientationTime = randomInt % 10;
}

#endif