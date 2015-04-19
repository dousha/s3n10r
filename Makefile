s3n10r:
	make compile

compile: header.hpp main.cpp Makefile
	g++ --std=c++11 -O4 -Wall *.hpp *.cpp -lSDL2 -lSDL2_image -lpthread -o s3n10r

clean: s3n10r
	rm -rf s3n10r

exu: s3n10r
	make compile
	./s3n10r

dbg: s3n10r
	g++ --std=c++11 -g -Wall *.hpp *.cpp -lSDL2 -lSDL2_image -lpthread -o s3n10r
	ddd ./s3n10r

