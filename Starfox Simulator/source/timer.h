#ifndef TIMER_H
#define TIMER_H
#include <time.h>
#include <windows.h>

class timer

{
  public:

	timer();
	bool update();
	void predraw();
	void postdraw();

    clock_t previous;
    clock_t updated;
    double elapsed;
    double time_passed;
    double command_lock;
	double sound_lock;
    int frames_passed;
};

timer::timer()

{
  previous = clock();
  command_lock = 0;
  sound_lock = 0;
  time_passed = 0;
  frames_passed = 0;
}

bool timer::update()

{
  Sleep(1);

  updated = clock();
  elapsed = (double)(updated - previous);
  previous = updated;

  if (command_lock > 0) command_lock -= elapsed;
  if (command_lock < 0) command_lock = 0;

  if (sound_lock > 0) sound_lock -= elapsed;
  if (sound_lock < 0) sound_lock = 0;

  time_passed += elapsed;

  if (time_passed > FRAME_LENGTH_MS) return true;
  return false;
}

void timer::predraw()

{
  frames_passed = (time_passed / FRAME_LENGTH_MS);
}

void timer::postdraw()

{
  time_passed -= (FRAME_LENGTH_MS * (double)frames_passed);
}

#endif