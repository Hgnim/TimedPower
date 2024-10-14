#pragma once

#include "pch.h"
#include "CLR_ClassLibrary.h"
#include "../PowerInvokeLib/PowerInvokeLib.h"

int CLRClassLibrary::PowerInovkeLib::TestOutputCS() {
	return TestOutput();
}
void CLRClassLibrary::PowerInovkeLib::pi_shutdown() {
	shutdown();
}
void CLRClassLibrary::PowerInovkeLib::pi_reboot() {
	reboot();
}
void CLRClassLibrary::PowerInovkeLib::pi_sleep() {
	sleep();
}
void CLRClassLibrary::PowerInovkeLib::pi_userOff() {
	userOff();
}
void  CLRClassLibrary::PowerInovkeLib::pi_userLock() {
	userLock();
}
void CLRClassLibrary::PowerInovkeLib::pi_hibernate() {
	pi_hibernate();
}

