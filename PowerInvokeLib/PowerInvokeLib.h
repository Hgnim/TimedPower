#pragma once


extern "C" {
    __declspec(dllexport) int TestOutput();
    __declspec(dllexport) void shutdown();
    __declspec(dllexport)void reboot();
    __declspec(dllexport)void sleep();
    __declspec(dllexport)void userOff();
    __declspec(dllexport)void userLock();
    __declspec(dllexport)void hibernate();
}
