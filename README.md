# SmartControl_PC

点个Star吧~





本项目/文档还在更新中!!!

![软件截图](https://github.com/a2633063/SmartControl_PC/blob/master/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/pic.png)

**被控设备:**

> 以下勾选表示已经支持,为勾选表示暂时不支持或设备还在开发中

- [ ] [按键伴侣ButtonMate](https://github.com/a2633063/SmartControl_ButtonMate_ESP8266)	直接控制墙壁开关,在不修改墙壁开关的前提下实现智能开关的效果
- [x] [zTC1_a1](https://github.com/a2633063/zTC1)	      斐讯排插TC1重新开发固件,仅支持a1版本.
- [ ] [zDC1](https://github.com/a2633063/zDC1_public)		       斐讯排插DC1重新开发固件.
- [ ] [zA1](https://github.com/a2633063/zA1)		          斐讯空气净化器悟净A1重新开发固件.
- [ ] [zM1](https://github.com/a2633063/zM1)		         斐讯空气检测仪悟空M1重新开发固件.
- [ ] RGB灯             设备开发中
- [ ] wifi校时时钟   设备开发中



**支持功能:**

>  以下勾选表示已经支持,为勾选表示暂时不支持或设备还在开发中

- [ ] ~~设备配网(不再支持,以后直接使用web配网)~~

- [x] 通过MQTT通信控制设备

- [x] 通过UDP局域网通信控制设备

- [x] 同步MQTT服务器数据给设备

- [x] 控制开关通断

- [ ] 设置设备定时任务

- [ ] 设置设备名称

- [ ] 查看设备信息

- [ ] 设备OTA升级

  



## 使用说明



> 本软件与设备通信通过udp广播或mqtt服务器通信.udp广播为在整个局域网(255.255.255.255)的10181和10182端口通信.由于udp广播的特性,udp局域网通信不稳定,建议有条件的还是使用mqtt服务器通信.




