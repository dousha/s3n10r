#include "header.hpp"

// --- vector --- //
vector::vector(){
	this->_x = 0;
	this->_y = 0;
}

vector::vector(float x, float y){
	this->_x = 0;
	this->_y = 0;
	this->set(x, y);
}

void vector::set(float x, float y){
	this->_x = x;
	this->_y = y;
}

vector* vector::get(){
	return this;
}

void vector::print(){
	// we will just print it to the log?
	printf("(%f, %f)", this->_x, this->_y);
}

// --- renderable --- //
void renderable::setLocation(int x, int y){
	this->_loc.x = x;
	this->_loc.y = y;
}

location renderable::getLocation(){
	return this->_loc;
}

void renderable::setTexture(const char* path){
	// we load it.
	this->_texture = IMG_LoadTexture(r, path);
}

void renderable::setTexture(SDL_Texture* tex){
	// we save it.
	this->_texture = tex;
}

SDL_Texture* renderable::getTexture(){
	return this->_texture;
}

// --- container --- //
void container::getItem(item i){
	// seek
	for(int j = 0; j < this->_size; j++){
		if(strcmp(this->_inv[j].name, i.name) == 0){
			item it = {"", "", {EFF_NONE, EFF_NONE, EFF_NONE, EFF_NONE}, 0};
			_inv[j] = it; // fill with air
			break;
		}
	}
}

void container::putItem(item i){
	// seek for air
	for(int j = 0; j < this->_size; j++){
		if(strlen(this->_inv[j].name) == 0){
			this->_inv[j] = i;
			break;
		}
	}
}

item* container::getItemList(){
	return this->_inv;
}

// --- chest --- //
void chest::lock(key k){
	this->_k = k;
	this->_hasLock = true;
}

void chest::unlock(key k){
	if(k.UID == this->_k.UID){
		this->_hasLock = false;
	}
}

bool chest::isLocked(){
	return this->_hasLock;
}

void chest::place(location l){
	this->_loc = l;
}

void chest::take(mob* m){
	item i = {"Chest",
				"A not large chest.",
				{EFF_NONE, EFF_NONE, EFF_NONE, EFF_NONE},
				3};
	m->getContainer()->putItem(i);
}

// --- mob --- //
void mob::attack(mob* m){
	m->harm((int) this->_attr.atk * this->_attr.smt *
			(this->_attr.spd - m->getAttribute().def) *
			getRandom(this->_attr.seed, 1, this->_attr.expr));
}

void mob::harm(int pt){
	this->_attr.hp -= pt;
}

void mob::heal(int pt){
	this->_attr.hp += pt;
}

container* mob::getContainer(){
	return this->_inv;
}

unsigned short int mob::getType(){
	return this->_type;
}

void mob::setType(unsigned short int type){
	this->_type = type;
}

void mob::talk(){
	// TODO: pop up a dialogue, and make some conversations
}

attribute mob::getAttribute(){
	return this->_attr;
}
