/*
 * This file contains API of the plugin
 * Mainly public classes and methods,
 * and some constants
 */

#include "header.hpp"

class sPlugin{
	public:
		sPlugin();
		~sPlugin(){};

		virtual void onCreate() = 0;
		virtual void onEvent() = 0;
		virtual void onDestroy() = 0;
};



