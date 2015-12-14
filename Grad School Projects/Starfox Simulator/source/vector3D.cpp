//Matthew Geer
//EECS 466
//vector3D.cpp
//Implements vector3D model

#ifndef VECTOR3D_CPP
#define VECTOR3D_CPP

#include "vector3D.h"
#include <math.h>

	//Constructors
	vector3D::vector3D(float initX, float initY, float initZ)
	{
		x=initX;
		y=initY;
		z=initZ;
	}

	vector3D::vector3D(const point p)
	{
		x=p.x;
		y=p.y;
		z=p.z;
	}

	vector3D::vector3D()
	{
	}
	
	//Vector addition and subtraction
	vector3D vector3D::operator+(const vector3D& v2) const
	{
		float newX, newY, newZ;
		newX=x+v2.x;
		newY=y+v2.y;
		newZ=z+v2.z;
		return vector3D(newX, newY, newZ);
	}

	vector3D vector3D::operator-(const vector3D& v2) const
	{
		float newX, newY, newZ;
		newX=x-v2.x;
		newY=y-v2.y;
		newZ=z-v2.z;
		return vector3D(newX, newY, newZ);
	}
	vector3D vector3D::operator +=(const vector3D& v2)
	{
		x+=v2.x;
		y+=v2.y;
		z+=v2.z;
		return *this;
	}

	vector3D vector3D::operator-=(const vector3D& v2)
	{
		x-=v2.x;
		y-=v2.y;
		z-=v2.z;
		return *this;
	}

	//scalling functions
	vector3D vector3D::operator*(const float scalar) const
	{
		return vector3D(scalar*x, scalar*y, scalar*z);
	}

	vector3D vector3D::operator*(const vector3D& scalar) const
	{
		return vector3D(scalar.x*x, scalar.y*y,scalar.z*z);
	}

	vector3D vector3D::operator*=(const float scalar)
	{
		x*=scalar;
		y*=scalar;
		z*=scalar;
		return *this;
	}
	vector3D vector3D::operator*=(const vector3D& scalar)
	{
		x*=scalar.x;
		y*=scalar.y;
		z*=scalar.z;
		return *this;
	}

	vector3D vector3D::operator/(const float scalar) const
	{
		return vector3D(x/scalar, y/scalar, z/scalar);
	}

	vector3D vector3D::operator/(const vector3D& scalar) const
	{
		return vector3D(x/scalar.x, y/scalar.y, z/scalar.z);
	}

	vector3D vector3D::operator/=(const float scalar)
	{
		x/=scalar;
		y/=scalar;
		z/=scalar;
		return *this;
	}
	vector3D vector3D::operator/=(const vector3D& scalar)
	{
		x/=scalar.x;
		y/=scalar.y;
		z/=scalar.z;
		return *this;
	}

	//Negation
	vector3D vector3D::operator-() const
	{
		return vector3D(-x, -y, -z);
	}

	//Vector Products
	vector3D vector3D::crossP(vector3D v2) const
	{
		return vector3D(y*v2.z-z*v2.y,z*v2.x-x*v2.z,x*v2.y-y*v2.x);
	}

	float vector3D::dotP(vector3D v2) const
	{
		return x*v2.x+y*v2.y+z*v2.z;
	}

	//calculate the lenth of the vector
	float vector3D::mag() const
	{
		return sqrtf(x*x+y*y+z*z);
	}

	//The unit vector pointing in the same direction of this vector
	vector3D vector3D::unitV() const
	{
		float len=mag();
		return vector3D(x/len, y/len,z/len);
	}

	point vector3D::toPoint() const
	{
		point p;
		p.x=x;
		p.y=y;
		p.z=z;
		return p;
	}

#endif