#include "header.hpp"

static int tEvent(void* data){
	for(;;){
		printf("[tEvent] Event thread created.");
		while(SDL_WaitEvent(&e)){
			switch(e.type){
				case SDL_KEYDOWN:
					if(e.key.repeat == false){
						switch(e.key.keysym.sym){
							case SDLK_w: // U
								// do something
								break;
							case SDLK_a: // L
								// do something
								break;
							case SDLK_s: // D
								//
								break;
							case SDLK_d: // R
								//
								break;
							case SDLK_q: // LT
								//
								break;
							case SDLK_g: // SEL
								//
								break;
							case SDLK_h: // STA
								//
								break;
							case SDLK_k: // B
								//
								break;
							case SDLK_l: // A
								//
								break;
							case SDLK_p: // RT
								//
								break;
							default:
								break;
						}
					}
					break;
				case SDL_QUIT:
					printf("[tEvent] Event thread destroyed.");
					return 0;
			}
		}
	}
}

static int tRenderer(void* data){
	for(;;){
		while(SDL_WaitEvent(&e)){
			Uint32 type = e.user.type;
			if(type == eventHalt){
				return 0;
			}else{
				// repaint anyway
			}
		}
	}
}

static int tAI(void* data){
	for(;;){
		while(SDL_WaitEvent(&e)){
			Uint32 type = e.user.type;
			if(type == eventMobMove){
				continue;
			}
			else if(type == eventHalt){
				return 0;
			}
		}
	}
}

static int tBGM(void* data){
	for(;;){
		while(SDL_WaitEvent(&e)){
			Uint32 type = e.user.type;
			if(type == eventBGMstart){
				printf("[tBGM] Now start BGM.");
				break;
			}
			else if(type == eventBGMchange){
				printf("[tBGM] Now BGM change to %s", e.user.data1);
				break;
			}
			else if(type == eventBGMstop){
				printf("[tBGM] Now stop BGM.");
				break;
			}
			else if(type == eventBGMvolumeChange){
				printf("[tBGM] BGM volume: %f", e.user.data1);
				break;
			}
			else if(type == eventHalt){
				return 0;
			}
		}
	}
}

void init(){
	SDL_Init(SDL_INIT_EVERYTHING);
	w = SDL_CreateWindow("s3n10r", 0, 0, WINDOW_WIDTH, 
						WINDOW_HEIGHT, 
						SDL_WINDOW_SHOWN);
	r = SDL_CreateRenderer(w, 0, SDL_RENDERER_ACCELERATED | 
							SDL_RENDERER_PRESENTVSYNC | 
							SDL_RENDERER_TARGETTEXTURE);
	SDL_RenderClear(r);
	SDL_RenderPresent(r);

	// register event
	/*
	eventMobMove = SDL_RegisterEvents(1);
	eventMobAttack = SDL_RegisterEvents(2);
	eventMobDefend = SDL_RegisterEvents(3);
	eventMobLoot = SDL_RegisterEvents(4);
	eventMobPick = SDL_RegisterEvents(5);*/

	// create event thread
	threadEvent = SDL_CreateThread(tEvent, "EventThread", (void *) 0);
	threadRenderer = SDL_CreateThread(tRenderer, "EventRenderer", (void *) 0);
	threadAI = SDL_CreateThread(tAI, "EventAI", (void *) 0);
	return;
}

void wait(){
	SDL_WaitThread(threadAI, 0);
	SDL_WaitThread(threadRenderer, 0);
	SDL_WaitThread(threadEvent, 0);
}

void shutdown(){
	// watch out of memory leak
	SDL_DestroyTexture(tFont);
	SDL_DestroyTexture(tTile);
	SDL_DestroyTexture(tBg);
	SDL_DestroyTexture(tFlash);
	SDL_DestroyTexture(tMob);

	SDL_DestroyWindow(w);
	SDL_DestroyRenderer(r);
}

int main(int argc, char **argv) {
    printf("[s3n10r] Hello!");
    init();
	printf("[s3n10r] Now give the control to Event bus");
	wait();
	printf("[s3n10r] Now performing clean up");
	shutdown();
	printf("[s3n10r] Have a nice day :)");
	return 0;
}

