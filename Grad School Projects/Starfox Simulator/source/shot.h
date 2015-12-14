class shot

{
  public:
      shot();
	  shot(shot&);
	  mesh_object *m;
	  int damage;
	  bool hostile;
	  int lifetime; //In frames
	  float velocity;
};

shot::shot()

{
  m = new mesh_object("./objects/missile.obj");
  damage=25;
  hostile=true;
  lifetime=TARGET_FPS*60; //In frames
  velocity=7.5;
}

shot::shot(shot &s)

{
  m = new mesh_object(*s.m);
  damage=s.damage;
  hostile=s.hostile;
  lifetime=s.lifetime;
  velocity=s.velocity;
}