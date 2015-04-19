// ----- Headers ----- //
#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <sstream>
#include <thread>

#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>

// ----- Constants ------ //
const int WINDOW_WIDTH = 240;
const int WINDOW_HEIGHT = 160;

// ----- Variables/Resources ------ //
SDL_Event e;
SDL_Window* w = nullptr;
SDL_Renderer* r = nullptr;

SDL_Texture* tFont = nullptr;
SDL_Texture* tTile = nullptr;
SDL_Texture* tBg = nullptr;
SDL_Texture* tFlash = nullptr;
SDL_Texture* tMob = nullptr;

SDL_Thread* threadRenderer = nullptr;
SDL_Thread* threadEvent = nullptr;
SDL_Thread* threadAI = nullptr;

Uint32 eventMobMove;
Uint32 eventMobAttack;
Uint32 eventMobDefend;
Uint32 eventMobLoot;
Uint32 eventMobPick;

// ----- Enumrations ----- //
enum eEffect{ // TODO: Add more effect types
	EFF_UNUSED = 0,
	EFF_HEALING,
	EFF_DAMAGEING,
	EFF_INSTANT_HEAL,
	EFF_INSTANT_DMG
};

enum eDirection{
	D_NORTH = 0, // ^
	D_SOUTH, // v
	D_WEST, // <
	D_EAST // >
};

// ----- Structures/Classes ----- //
struct location;
struct effect;
struct item;
struct key;

class vector;
class renderable;
class container;
class chest;
class mob;
class npc;
class player;
class sRender;

struct location{
	unsigned short int unitWidth;
	unsigned short int unitHeight;
	unsigned long int x;
	unsigned long int y;
	unsigned int w;
	unsigned int h;
};

struct effect{
	eEffect type;
	unsigned short int duration;
	int data;
};

struct item{
	char name[16];
	char description[256];
	effect e[4];
	short int weight;
};

struct key{
	unsigned long int UID;
};

class vector{
	public:
		void set(float x, float y);
		vector get();
		void print();

	private:
		float x, y;
};

class renderable{
	public:
		SDL_Texture* getTexture();
		void setTexture(const char* path);
		location getLocation();
		void setLocation();

	private:
		SDL_Texture* texture;
		location loc;
};

class container{
	public:
		void put(item* i);
		void get(item* i);
	
	private:
		item* inv;
};

class chest : public container{
	public:
		void place(location l);
		void take();
		void lock(key k);
		void unlock();

	private:
		location loc;
		key* k;
};

class mob : public renderable{
	public:
		void attack(mob target);
		void defend();

		void give(item i);
		void get(item i);

		void sell(item i);
		void buy(item i);

		void talk();

		void walk(eDirection dirc, short int speed);

		unsigned short int getType();
		void setType();

		SDL_Texture* getTexture();
		void setTexture(SDL_Texture* texture);
		
	protected:
		location loc;
		unsigned short int type;
		char* name;
		char* description;
		container* inv;
		effect eff[10];
		SDL_Texture* texture;
};

class npc : public mob{
	
};

class player : public mob{
	public:
		void setSpeed(vector v);
		void getSpeed(vector v);
		void halt();
};

class sRenderer{
	public:
		sRenderer();
		~sRenderer();
		bool assign(renderable* ren);
		void render(SDL_Renderer* renderer);
	
	private:
		
};

