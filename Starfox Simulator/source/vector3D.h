#ifndef _MJG_VECTOR3D_H_
#define _MJG_VECTOR3D_H_

	//I named this vector3D to aviod confusion with the STL vector class.
	class vector3D
	{
	public:
		float x, y, z;

		inline vector3D(float initX, float initY, float initZ);
		inline vector3D(const point p);
		inline vector3D();

		inline vector3D operator+(const vector3D& v2) const;
		inline vector3D operator-(const vector3D& v2) const;
		inline vector3D operator+=(const vector3D& v2);
		inline vector3D operator-=(const vector3D& v2);
		inline vector3D operator*(const float scalar) const;
		inline vector3D operator*(const vector3D& scalar) const;
		inline vector3D operator*=(const float scalar);
		inline vector3D operator*=(const vector3D& scalar);
		inline vector3D operator/(const float scalar) const;
		inline vector3D operator/(const vector3D& scalar) const;
		inline vector3D operator/=(const float scalar);
		inline vector3D operator/=(const vector3D& scalar);
		inline vector3D operator-() const;

		inline vector3D crossP(vector3D v2) const;
		inline float dotP(vector3D v2) const;
		inline float mag() const;
		inline vector3D unitV() const;
		inline point toPoint() const;

	private:
	};

#include "vector3D.cpp"

#endif