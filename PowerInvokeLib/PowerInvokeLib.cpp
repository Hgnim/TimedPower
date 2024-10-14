// PowerInvokeLib.cpp : 定义静态库的函数。
//

#include "pch.h"
#include "framework.h"

/*// TODO: 这是一个库函数示例
void fnPowerInvokeLib()
{
}*/
#include <iostream>

#include "PowerInvokeLib.h"

int TestOutput()
{
    return -1;
};

void shutdown() {
    system("shutdown /d p:0:0 /c \"TimedPower定时电源进行的操作\" /s /t 0");
};
void reboot() {
    system("shutdown /d p:0:0 /c \"TimedPower定时电源进行的操作\" /r /t 0");
}
void sleep() {
    system("rundll32.exe powrprof.dll,SetSuspendState 0,1,1");
    /*语法
C++
BOOLEAN SetSuspendState(
  [in] BOOLEAN bHibernate,
  [in] BOOLEAN bForce,
  [in] BOOLEAN bWakeupEventsDisabled
);
参数

[in] bHibernate
如果此参数为 TRUE，则系统进入休眠状态。 如果参数为 FALSE，则系统挂起。

[in] bForce
此参数不起作用。

[in] bWakeupEventsDisabled
如果此参数为 TRUE，则系统将禁用所有唤醒事件。 如果参数为 FALSE，则任何系统唤醒事件仍保持启用状态。

返回值
如果该函数成功，则返回值为非零值。
如果函数失败，则返回值为零。 要获得更多的错误信息，请调用 GetLastError。
    */
}
void userOff() {
    system("shutdown /l");
}
void userLock() {
    system("rundll32.exe user32.dll,LockWorkStation");
}
void hibernate() {
    system("shutdown /h");
}


