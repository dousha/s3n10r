#ifndef __HEADER_HPP
#define __HEADER_HPP
// ----- Headers ------- //
#include <vector>

#include <stdio.h>
#include <string.h>
#include <dlfcn.h>

#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>

// ----- Constants ------ //
extern const int WINDOW_WIDTH;
extern const int WINDOW_HEIGHT;

// ----- Variables/Resources ------ //
extern SDL_Event e;
extern SDL_Window* w;
extern SDL_Renderer* r;

extern SDL_Texture* tFont;
extern SDL_Texture* tTile;
extern SDL_Texture* tBg;
extern SDL_Texture* tFlash;
extern SDL_Texture* tMob;

extern SDL_Thread* threadRenderer;
extern SDL_Thread* threadEvent;
extern SDL_Thread* threadAI;

extern const Uint32 eventHalt;
extern const Uint32 eventMobMove;
extern const Uint32 eventMobAttack;
extern const Uint32 eventMobDefend;
extern const Uint32 eventMobLoot;
extern const Uint32 eventMobPick;
extern const Uint32 eventBGMstart;
extern const Uint32 eventBGMstop;
extern const Uint32 eventBGMvolumeChange;
extern const Uint32 eventBGMchange;

// ----- Enumrations ----- //
enum eEffect{ // TODO: Add more effect types
	EFF_NONE = 0, // FIXME
	EFF_UNUSED,
	EFF_HEALING,
	EFF_DAMAGEING,
	EFF_INSTANT_HEAL,
	EFF_INSTANT_DMG
};

enum eDirection{
	D_UP = 0, // ^
	D_DOWN, // v
	D_LEFT, // <
	D_RIGHT // >
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
	Uint16 UID;
};

class vector{
	public:
		vector();
		vector(float x, float y);
		~vector();
		void set(float x, float y);
		vector* get();
		void print();

	private:
		float _x, _y;
};

class renderable{
	public:
		SDL_Texture* getTexture();
		void setTexture(const char* path);
		location getLocation();
		void setLocation(int x, int y);

	private:
		SDL_Texture* _texture;
		location _loc;
};

class container{
	public:
		container(int size);
		void putItem(item i);
		void getItem(item i);
		item* getItemList();
	
	private:
		int _size;
		item* _inv;
};

class chest : public container{
	public:
		void place(location l);
		void take(mob* src);
		void lock(key k);
		void unlock(key k);
		bool isLocked();

	private:
		location _loc;
		key _k;
		bool _hasLock;
};

class mob : public renderable{
	public:
		void attack(mob* target);
		void harm(int pt);
		void heal(int pt);
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
		
		container* getContainer();

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
	public:

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
		std::vector<renderable*> vren;
};

#endif

