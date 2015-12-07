#define EPSILON 0.000001
#define CROSS(dest,v1,v2) dest[0]=v1[1]*v2[2]-v1[2]*v2[1]; dest[1]=v1[2]*v2[0]-v1[0]*v2[2]; dest[2]=v1[0]*v2[1]-v1[1]*v2[0];
#define DOT(v1,v2) (v1[0]*v2[0]+v1[1]*v2[1]+v1[2]*v2[2])
#define SUB(dest,v1,v2) dest[0]=v1[0]-v2[0]; dest[1]=v1[1]-v2[1]; dest[2]=v1[2]-v2[2];
int intersect_triangle(double*, double*, double*, double*, double*, double*, double*, double*);

// ***************************************************************************************** //
// ***************************************************************************************** //
// ***************************************************************************************** //

int shoot_ray(mesh_object *SRC, mesh_object *DST, mesh_object *TRG)

{
  // Return true if TRG is hit by a ray shot from SRC to DST.

  double orig[3], vect[3], v1[3], v2[3], v3[3], t, u, v;

  point Orig = SRC->get_midpoint();
  point Vect = DST->get_midpoint();

  orig[0] = Orig.x;
  orig[1] = Orig.y;
  orig[2] = Orig.z;
  vect[0] = Vect.x;
  vect[1] = Vect.y;
  vect[2] = Vect.z;

  // Top Face.
  v1[0] = TRG->Top[0].x;  v1[1] = TRG->Top[0].y;  v1[2] = TRG->Top[0].z;
  v2[0] = TRG->Top[1].x;  v2[1] = TRG->Top[1].y;  v2[2] = TRG->Top[1].z;
  v3[0] = TRG->Top[2].x;  v3[1] = TRG->Top[2].y;  v3[2] = TRG->Top[2].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;
  v1[0] = TRG->Top[2].x;  v1[1] = TRG->Top[2].y;  v1[2] = TRG->Top[2].z;
  v2[0] = TRG->Top[3].x;  v2[1] = TRG->Top[3].y;  v2[2] = TRG->Top[3].z;
  v3[0] = TRG->Top[0].x;  v3[1] = TRG->Top[0].y;  v3[2] = TRG->Top[0].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;

  // Bottom Face.
  v1[0] = TRG->Bot[0].x;  v1[1] = TRG->Bot[0].y;  v1[2] = TRG->Bot[0].z;
  v2[0] = TRG->Bot[1].x;  v2[1] = TRG->Bot[1].y;  v2[2] = TRG->Bot[1].z;
  v3[0] = TRG->Bot[2].x;  v3[1] = TRG->Bot[2].y;  v3[2] = TRG->Bot[2].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;
  v1[0] = TRG->Bot[2].x;  v1[1] = TRG->Bot[2].y;  v1[2] = TRG->Bot[2].z;
  v2[0] = TRG->Bot[3].x;  v2[1] = TRG->Bot[3].y;  v2[2] = TRG->Bot[3].z;
  v3[0] = TRG->Bot[0].x;  v3[1] = TRG->Bot[0].y;  v3[2] = TRG->Bot[0].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;

  // Left Face.
  v1[0] = TRG->Left[0].x;  v1[1] = TRG->Left[0].y;  v1[2] = TRG->Left[0].z;
  v2[0] = TRG->Left[1].x;  v2[1] = TRG->Left[1].y;  v2[2] = TRG->Left[1].z;
  v3[0] = TRG->Left[2].x;  v3[1] = TRG->Left[2].y;  v3[2] = TRG->Left[2].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;
  v1[0] = TRG->Left[2].x;  v1[1] = TRG->Left[2].y;  v1[2] = TRG->Left[2].z;
  v2[0] = TRG->Left[3].x;  v2[1] = TRG->Left[3].y;  v2[2] = TRG->Left[3].z;
  v3[0] = TRG->Left[0].x;  v3[1] = TRG->Left[0].y;  v3[2] = TRG->Left[0].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;

  // Right Face.
  v1[0] = TRG->Right[0].x;  v1[1] = TRG->Right[0].y;  v1[2] = TRG->Right[0].z;
  v2[0] = TRG->Right[1].x;  v2[1] = TRG->Right[1].y;  v2[2] = TRG->Right[1].z;
  v3[0] = TRG->Right[2].x;  v3[1] = TRG->Right[2].y;  v3[2] = TRG->Right[2].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;
  v1[0] = TRG->Right[2].x;  v1[1] = TRG->Right[2].y;  v1[2] = TRG->Right[2].z;
  v2[0] = TRG->Right[3].x;  v2[1] = TRG->Right[3].y;  v2[2] = TRG->Right[3].z;
  v3[0] = TRG->Right[0].x;  v3[1] = TRG->Right[0].y;  v3[2] = TRG->Right[0].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;

  // Front Face.
  v1[0] = TRG->Front[0].x;  v1[1] = TRG->Front[0].y;  v1[2] = TRG->Front[0].z;
  v2[0] = TRG->Front[1].x;  v2[1] = TRG->Front[1].y;  v2[2] = TRG->Front[1].z;
  v3[0] = TRG->Front[2].x;  v3[1] = TRG->Front[2].y;  v3[2] = TRG->Front[2].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;
  v1[0] = TRG->Front[2].x;  v1[1] = TRG->Front[2].y;  v1[2] = TRG->Front[2].z;
  v2[0] = TRG->Front[3].x;  v2[1] = TRG->Front[3].y;  v2[2] = TRG->Front[3].z;
  v3[0] = TRG->Front[0].x;  v3[1] = TRG->Front[0].y;  v3[2] = TRG->Front[0].z;
  if (intersect_triangle(orig, vect, v1, v2, v3, &t, &u, &v)) return 1;

  return 0;
}

// ***************************************************************************************** //
// ***************************************************************************************** //
// ***************************************************************************************** //

int intersect_triangle(double orig[3], double dir[3],
                       double vert0[3], double vert1[3], double vert2[3],
                       double *t, double *u, double *v)
{
   double edge1[3], edge2[3], tvec[3], pvec[3], qvec[3];
   double det,inv_det;

   /* find vectors for two edges sharing vert0 */
   SUB(edge1, vert1, vert0);
   SUB(edge2, vert2, vert0);

   /* begin calculating determinant - also used to calculate U parameter */
   CROSS(pvec, dir, edge2);

   /* if determinant is near zero, ray lies in plane of triangle */
   det = DOT(edge1, pvec);

   #ifdef TEST_CULL           /* define TEST_CULL if culling is desired */
   if (det < EPSILON)
      return 0;

   /* calculate distance from vert0 to ray origin */
   SUB(tvec, orig, vert0);

   /* calculate U parameter and test bounds */
   *u = DOT(tvec, pvec);
   if (*u < 0.0 || *u > det)
      return 0;

   /* prepare to test V parameter */
   CROSS(qvec, tvec, edge1);

    /* calculate V parameter and test bounds */
   *v = DOT(dir, qvec);
   if (*v < 0.0 || *u + *v > det)
      return 0;

   /* calculate t, scale parameters, ray intersects triangle */
   *t = DOT(edge2, qvec);
   inv_det = 1.0 / det;
   *t *= inv_det;
   *u *= inv_det;
   *v *= inv_det;

   #else                    /* the non-culling branch */
   if (det > -EPSILON && det < EPSILON)
     return 0;
   inv_det = 1.0 / det;

   /* calculate distance from vert0 to ray origin */
   SUB(tvec, orig, vert0);

   /* calculate U parameter and test bounds */
   *u = DOT(tvec, pvec) * inv_det;
   if (*u < 0.0 || *u > 1.0)
     return 0;

   /* prepare to test V parameter */
   CROSS(qvec, tvec, edge1);

   /* calculate V parameter and test bounds */
   *v = DOT(dir, qvec) * inv_det;
   if (*v < 0.0 || *u + *v > 1.0)
     return 0;

   /* calculate t, ray intersects triangle */
   *t = DOT(edge2, qvec) * inv_det;
   #endif

   return 1;
}

// ***************************************************************************************** //
// ***************************************************************************************** //
// ***************************************************************************************** //

float abs(float f)

{
  if (f < 0) return -f;
  return f;
}