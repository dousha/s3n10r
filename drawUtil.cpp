#include "header.hpp"

// magic, do not touch
// these global variables handles
// screen push/poping
// and, yes, after you push your
// screen in, you can pick them
// out from _scr as a texture

SDL_Renderer* _ren = NULL;
SDL_Texture* _scr = NULL;

void flushScreen(SDL_Renderer* ren){
	SDL_RenderClear(ren);
	SDL_RenderPresent(ren);
}

void pushRenderer(SDL_Renderer* ren){
	_ren = ren;
}

SDL_Renderer* popRenderer(){
	return _ren;
}

void pushScreen(SDL_Renderer* ren){
	pushRenderer(ren);
	SDL_Texture* _scr =
		SDL_CreateTexture(_ren,
							SDL_PIXELFORMAT_RGBA8888,
							SDL_TEXTUREACCESS_TARGET,
							WINDOW_WIDTH,
							WINDOW_HEIGHT);
	SDL_SetRenderTarget(_ren, _scr);
	SDL_RenderPresent(_ren);
}

void popScreen(SDL_Renderer* ren){
	SDL_RenderCopy(ren, _scr, NULL, NULL);
}

void print(SDL_Renderer* ren,
			layer lay,
			int x, int y,
			const char chr){
	pushRenderer(ren);
	SDL_SetRenderTarget(_ren, lay.tex);
	int col = (int) chr % CHAR_PER_ROW;
	int row = ((int) chr - col) / CHAR_PER_COL;
	// use traditional SDL_Rect
	SDL_Rect src, dest;
	src.x = col * FONT_WIDTH + FONT_OFFSET;
	src.y = row * FONT_HEIGHT + FONT_OFFSET;
	src.w = FONT_WIDTH;
	src.h = FONT_HEIGHT;
	dest.x = x;
	dest.y = y;
	dest.w = FONT_WIDTH;
	dest.h = FONT_HEIGHT;
	// then copy it
	SDL_RenderCopy(_ren, tFont, &src, &dest);
	SDL_RenderPresent(_ren);
}

void println(SDL_Renderer* ren,
			layer lay,
			int x, int y, int w,
			const char* str){
	if(strlen(str) <= 0) return;
	else{
		int i = 0, j = 0;
		for(i = 0; i < strlen(str); i++){
			print(ren, lay, x, y, str[i]);
			x += FONT_WIDTH;
			if(x >= w){
				y += FONT_HEIGHT;
				if(y >= WINDOW_HEIGHT){
					// TODO: wait for player press 'A'
				}
			}
		}
	}
}

void createDialog(SDL_Renderer* ren,
					layer lay,
					dialog dia){
	// TODO: create a diaglogue

}

void createMenu(SDL_Renderer* ren,
				layer lay,
				menu me){
	// TODO: create a menu
}


