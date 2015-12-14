#ifndef PATH_H
#define PATH_H

#include <iostream>
#include <iomanip>
#include <cstdlib>
#include "3D_Matrix.h"

class path
{
	public:
		path(char*);					//Constructor
		path(void);						//Constructor
		bool selectPath(char*);			//Change the path to a different
		void addTic(void);				//called each tic
		int getTic(void);				//get the tic count
		void setTicCount(int);			//set speed of movement
		int getToc(void);
		Matrix currentMatrix(void);		//gets the current Matrix
		int Rand(void);				//puts the path at a random spot


	private:
		bool pathSet;	//has the path been set
		char* filepath;			//pathname of the file containing the path
		int pathTime;		//index of the current path matrix
		int tic;			//tics once per swap
		int ticsPerToc;		//each toc, advance pathTime
		int len;			//length of array
		Matrix direction[10];	//the actual path	

};

path::path(void)
{	pathSet = false;	//has the path been set
	pathTime = 0;		//index of the current path matrix
	tic = 0;			//tics once per swap
	ticsPerToc = 10;	//each toc, advance pathTime
	len = 10;			//lenght of all paths
	
}

path::path(char* fp)
{	filepath = fp;
	pathSet = false;	//has the path been set
	pathTime = 0;		//index of the current path matrix
	tic = 0;			//tics once per swap
	ticsPerToc = 10;	//each toc, advance pathTime
	len = 10;		//lenght of all paths
	pathSet = selectPath(filepath);
}

bool path::selectPath(char* fp)	//read in from file and set matix using input
{ ifstream input;
  filepath = fp;
  input.open(fp);
  char inNumber[256];
  float Xtemp, Ytemp, Ztemp;
  int index = 0;

  if (!input.is_open()) {
	cout << "could not open " << fp << endl;
	system("pause");
    return false; }

  while(!input.eof())
  {	input.getline(inNumber, 256);
	Xtemp = atof(inNumber);

	input.getline(inNumber, 256);
	Ytemp = atof(inNumber);

	input.getline(inNumber, 256);
	Ztemp = atof(inNumber);

	direction[index].translation(Xtemp,Ytemp,Ztemp);
	index++;
  }

  return true;
}

void path::addTic(void)
{	tic++;
	if (tic > ticsPerToc)
	{	tic = 0;
		if (pathTime < len - 1)
			{	pathTime++;
			}
			else 
				pathTime = 0;
	}
}

int path::getTic(void)
{	return tic;}

void path::setTicCount(int tpc)
{	ticsPerToc = tpc;
}

int path::getToc(void)
{	return ticsPerToc;}


Matrix path::currentMatrix(void)
{	if (pathSet)
		return direction[pathTime];
	else
	{
		Matrix trash;
		trash.identity();
		return trash;
	}
}

int path::Rand(void)
{
	int randomInt = rand();
	pathTime = randomInt % 10;
	return pathTime;
}

#endif