#ifndef MATRIX_H
#define MATRIX_H
#include <iostream>
#include <math.h>

// A multi-purpose matrix class.
// It can make itself into a transformation
// matrix by invoking the proper method with
// the given parameter(s).



class Matrix

{
  public:
    Matrix();                                 // Constructor.
    float get(int, int);                      // Return position i/j.
	void transform(float*, float*, float*);   // Apply to a vertex.
	void mult(Matrix*, Matrix*);              // Matrix multiplication.
    void translation(float, float, float);    // Form Translation Matrix.
    void scaling(float, float, float);        // Form Scaling Matrix.
    void rotation_x(float);                   // Form X Rotation Matrix.
    void rotation_y(float);                   // Form Y Rotation Matrix.
    void rotation_z(float);                   // Form Z Rotation Matrix.
	void identity();                          // Set to Identity.
	void copy(Matrix*);                       // Copy a Matrix.

    float M[5][5];  // Matrix contents.
};

Matrix::Matrix()

{
  // Initialize Matrix to 0.
  for (int i=0; i<5; i++)
  for (int j=0; j<5; j++)
    M[i][j] = 0;
}

float Matrix::get(int n, int m)

{
  // Get Matrix row n column m.
  return M[n][m];
}

void Matrix::transform(float *X, float *Y, float *Z)

{
  // Multiply matrix times a vertex.

  float temp[5], M2[5];

  temp[1] = 0;
  temp[2] = 0;
  temp[3] = 0;
  temp[4] = 0;

  M2[1] = *X;
  M2[2] = *Y;
  M2[3] = *Z;
  M2[4] = 1.0;

  for (int row=1; row<=4; row++)

  {
	for (int col=1; col<=4; col++)
      temp[row] += (M[row][col] * M2[col]);
  }

  // Transform X/Y/X.

  *X = temp[1];
  *Y = temp[2];
  *Z = temp[3];
}

void Matrix::mult(Matrix *M1, Matrix *M2)

{
  // Matrix multiplication.  M = M1 * M2.

  float temp[5][5];

  for (int i=1; i<=4; i++)
  for (int j=1; j<=4; j++)
    temp[i][j] = 0;

  for (int row=1; row<=4; row++)
  for (int col=1; col<=4; col++)
  for (int k=1; k<=4; k++)
    temp[row][col] += (M1->get(row, k) * M2->get(k, col));

  for (int n=1; n<=4; n++)
  for (int m=1; m<=4; m++)
    M[n][m] = temp[n][m];
}

void Matrix::rotation_x(float theta)

{
  // Form an X Rotation Matrix for theta degrees.

  for (int row=1; row<=4; row++)
  for (int col=1; col<=4; col++)
    M[row][col] = 0;

  M[4][4] = 1;

  M[2][2] = cos(theta);
  M[3][3] = cos(theta);
  M[3][2] = sin(theta);
  M[2][3] = -sin(theta);
  M[1][1] = 1;
}

void Matrix::rotation_y(float theta)

{
  // Form a Y Rotation Matrix for theta degrees.

  for (int row=1; row<=4; row++)
  for (int col=1; col<=4; col++)
    M[row][col] = 0;

  M[4][4] = 1;

  M[1][1] = cos(theta);
  M[3][3] = cos(theta);
  M[1][3] = sin(theta);
  M[3][1] = -sin(theta);
  M[2][2] = 1;
}

void Matrix::rotation_z(float theta)

{
  // Form a Z Rotation Matrix for theta degrees.

  for (int row=1; row<=4; row++)
  for (int col=1; col<=4; col++)
    M[row][col] = 0;

  M[4][4] = 1;

  M[1][1] = cos(theta);
  M[2][2] = cos(theta);
  M[2][1] = sin(theta);
  M[1][2] = -sin(theta);
  M[3][3] = 1;
}

void Matrix::scaling(float sx, float sy, float sz)

{
  // Form a Scaling Matrix for sx/sy/sz.

  for (int row=1; row<=4; row++)
  for (int col=1; col<=4; col++)
    M[row][col] = 0;

  M[1][1] = sx;
  M[2][2] = sy;
  M[3][3] = sz;
  M[4][4] = 1;
}

void Matrix::translation(float tx, float ty, float tz)

{
  // Form a Translation Matrix for tx/ty/tz.

  for (int row=1; row<=4; row++)
  for (int col=1; col<=4; col++)
    if (row == col) M[row][col] = 1;
    else M[row][col] = 0;

  M[1][4] = tx;
  M[2][4] = ty;
  M[3][4] = tz;
}

void Matrix::identity()

{
  // Set Matrix to identiy.

  for (int row=1; row<5; row++)
  for (int col=1; col<5; col++) {
    if (row == col) M[row][col] = 1;
    else M[row][col] = 0; }
}

void Matrix::copy(Matrix *CP)

{
  for (int row=1; row<=4; row++)
  for (int col=1; col<=4; col++)
    M[row][col] = CP->M[row][col];
}

#endif