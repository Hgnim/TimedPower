#pragma once

using namespace System;

namespace CLRClassLibrary {
	public ref class PowerInovkeLib
	{
	public:static int TestOutputCS();
	public: static void pi_shutdown();
	public: static void pi_reboot();
	public: static void pi_sleep();
	public: static void pi_userOff();
	public:static void pi_userLock();
	public:static void pi_hibernate();
	};	
}
