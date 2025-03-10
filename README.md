# 定时电源(TimedPower)

[English](https://github.com/Hgnim/TimedPower/blob/doc/README.en.md) | [简体中文](https://github.com/Hgnim/TimedPower/blob/doc/README.md) | [繁體中文](https://github.com/Hgnim/TimedPower/blob/doc/README.zh-Hant.md) | [русский](https://github.com/Hgnim/TimedPower/blob/doc/README.ru.md) | [Deutsch](https://github.com/Hgnim/TimedPower/blob/doc/README.de.md) | [Español](https://github.com/Hgnim/TimedPower/blob/doc/README.es.md) | [Français](https://github.com/Hgnim/TimedPower/blob/doc/README.fr.md) | [Português](https://github.com/Hgnim/TimedPower/blob/doc/README.pt.md)
<!--翻译时需要先将语言选择这一行去掉-->

基于Windows平台下的多功能定时电源操作软件。\
软件目前只支持中英两种语言。

![downloads](https://img.shields.io/github/downloads/hgnim/timedpower/total.svg)
![Github tag](https://badgen.net/github/tag/hgnim/timedpower)

## 介绍

- 该软件可以定时关机、重启、睡眠、休眠、锁定、注销。\
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image1.png)
- 操作简单，外观简约，支持明暗双主题。\
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image2.png)
- 支持任意时间后进行电源操作和设置某个时间点定时操作。\
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image3.png)
- 在倒计时最后几秒时会发送桌面通知进行提醒，误将倒计时设置太短后执行操作会进行弹窗确认。\
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image4.png)
- 倒计时进行时会在任务栏的程序图标中显示进度条，进度条会随着时间变短而变色，增加观赏感:) \
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image5.png)
- 可以在设置中开启添加Windows右键菜单快捷按钮（可选功能，需要在软件设置中手动启用）。也可以通过右键主窗口中的时间输入框进行快捷输入。\
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image6.png)
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image7.png)
- 支持自动定时任务执行，可快捷添加静默进行的计时任务。并且包含误操作保护机制。\
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image8.png)
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image9.png)
- 可用任务文件定义倒计时任务操作，执行文件以一键开始任务。\
  ![image](https://raw.githubusercontent.com/Hgnim/TimedPower/refs/heads/doc/imgs/image10.png)

## 文档

前往[**帮助文档**](https://github.com/Hgnim/TimedPower/wiki)

## 用户须知

- 使用该软件前必需[安装.net 8.0 runtime框架](https://dotnet.microsoft.com/zh-cn/download/dotnet/thank-you/runtime-8.0.10-windows-x64-installer)。
- Windows版本要求10.0.17763.0及以上。现在目前只支持windows x64平台。
- 用户在使用定时休眠功能时，需要确保系统已启用且支持休眠功能，否则将会没有任何效果。

## 获取软件

[前往最新版本下载页面](https://github.com/Hgnim/TimedPower/releases/latest)

## 贡献

- 如果在使用本软件的时候发现了问题与错误或有功能增强与改进的想法，欢迎[创建Issues](https://github.com/Hgnim/TimedPower/issues/new)提出你的看法。
- 此项目接受大多类型的贡献，在进行较大的更改时请先联系存储库管理者。

## 声明

- 此软件为免费开源软件，禁止将其应用于商业用途。
- 该软件在每个版本发布前都已经进行了多次调试，以将异常率降到最低，并对一些用户容易疏忽和误操作的地方做出了保护<del>\(防呆\)</del>机制。但也不敢保证其绝对的万无一失，可能会因各种潜在因素导致异常。
- 在使用软件前，请务必提前了解软件的运作方式，任何因用户使用不当而导致出现致命问题开发者概不负责。
- 本软件的开发者对使用者因任何原因在使用本软件时对自己或他人造成的任何形式的损失和伤害不承担责任。

## 相关视频

相关介绍视频参考(点击将跳转至bilibili观看)：\
[![bilibili_img](https://i0.hdslb.com/bfs/archive/fc7e7cc4588dad7f350031a8d0b9e09a8adb3a7f.jpg@308w_174h)](https://www.bilibili.com/video/BV1yxNAenEBb)
> 视频中使用的软件版本为v2.8.7
