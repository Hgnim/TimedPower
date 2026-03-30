#执行安装程序打包脚本
#执行前需将项目编译后的文件放入./TimedPower_bin

& 'C:\Program Files (x86)\NSIS\makensis.exe' '.\setupScript.nsi'

Read-Host "按下 Enter 以退出"