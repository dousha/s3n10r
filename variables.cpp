#include "header.hpp"

// ----- Constants ------ //
const int WINDOW_WIDTH = 240;
const int WINDOW_HEIGHT = 160;

// ----- Variables/Resources ------ //
SDL_Event e;
SDL_Window* w = NULL;
SDL_Renderer* r = NULL;

SDL_Texture* tFont = NULL;
SDL_Texture* tTile = NULL;
SDL_Texture* tBg = NULL;
SDL_Texture* tFlash = NULL;
SDL_Texture* tMob = NULL;

SDL_Thread* threadRenderer = NULL;
SDL_Thread* threadEvent = NULL;
SDL_Thread* threadAI = NULL;

const Uint32 eventHalt = 1024;
const Uint32 eventMobMove = 1025;
const Uint32 eventMobAttack = 1026;
const Uint32 eventMobDefend = 1027;
const Uint32 eventMobLoot = 1028;
const Uint32 eventMobPick = 1029;
const Uint32 eventBGMstart = 1030;
const Uint32 eventBGMstop = 1031;
const Uint32 eventBGMvolumeChange = 1032;
const Uint32 eventBGMchange = 1033;


