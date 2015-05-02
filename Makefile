SRC=header.cpp plugin.cpp main.cpp variables.cpp drawUtil.cpp
OBJ=$(SRC:.cpp=.o)
DEP=header.hpp
OUT=s3n10r
LD=-lSDL2 -lSDL2_image -lpthread
CFLAG=-O4 -Wall -std=c++11
DEBUG_CFLAG=-g -Wall -std=c++11

%.o : %.cpp $(DEP) Makefile
	g++ -c -o $@ $< $(CFLAG)

all : compile

compile: $(OBJ) Makefile
	g++ $(OBJ) $(LD) -o $(OUT)

dbg: compile
	g++ $(DEBUF_CFLAG) $(OBJ) $(LD) -o $(OUT)
	ddd ./s3n10r

clean:
	rm -f *o $(OUT)

