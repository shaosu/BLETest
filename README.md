# BLETest

## 资料
1. 开发板:esp32-pico-kit-v4.1  BLE蓝牙从机模式
2. 开发环境Arduino IDE V2.3.6
3. 界面开发环境:Windows10及以上(必须)
4. .Net 4.8
5. ESP32蓝牙名称:ESP32-BLE-Peripheral

## 操作
1. 单机扫描,选择蓝牙
2. 单机服务,选择服务
3. 单机特征,选择特征
4. 单机连接
5. 读或者写数据
6. 断开连接


# Note小米蓝牙温湿度计

1. 服务UUID:EBEOCCBO-7AOA-4BOC-8A1A-6FF2997DA3A6
2. 对应服务的特征UUID:EBE0CCC1-7A0A-4B0C-8A1A-6FF2997DA3A6 温度湿度的读和通知特征
3. 温度 = (温度高字节 << 8 | 温度低字节) / 100.0f
4. 湿度 = (湿度高字节 << 8 | 湿度低字节) - 52992; // 0xCF00
5. 电池电量:1字节
6. Hex:04 0A 3D CF 0B 温度:25.64℃ 湿度:61% 电量:11%
7. LYWSD03MMC MAC:a4:c1:38:3d:4f:99 RSSI:-57