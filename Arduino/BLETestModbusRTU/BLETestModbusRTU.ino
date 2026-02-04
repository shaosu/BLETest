#include <BLEDevice.h>
#include <BLEServer.h>
#include <BLEUtils.h>
#include <BLE2902.h>

// 自定义UUID
#define SERVICE_UUID           "0000fff0-0000-1000-8000-00805f9b34fb"
#define CHARACTERISTIC_UUID_RX "0000fff1-0000-1000-8000-00805f9b34fb"
#define CHARACTERISTIC_UUID_TX "0000fff2-0000-1000-8000-00805f9b34fb"

BLEServer* pServer = NULL;
BLECharacteristic* pCharacteristicTx = NULL;  // 用于发送数据（NOTIFY）
BLECharacteristic* pCharacteristicRx = NULL;  // 用于接收数据（WRITE）
bool deviceConnected = false;
bool oldDeviceConnected = false;
int ReadCount = 0;
uint8_t SendBuff[256];


// 服务器回调
class MyServerCallbacks: public BLEServerCallbacks {
  void onConnect(BLEServer* pServer) {
    deviceConnected = true;
    Serial.println("BLE device connected.");
  }

  void onDisconnect(BLEServer* pServer) {
    deviceConnected = false;
    Serial.println("BLE device disconnected.");
  }
};

// 工具函数：将数据转换为十六进制字符串
String uint8ToHexString(const uint8_t* data, size_t length) {
    String result = "";
    for (size_t i = 0; i < length; i++) {
        if (data[i] < 16) result += "0";
        result += String(data[i], HEX);
    }
    result.toUpperCase();
    return result;
}

uint16_t ModbusCRC(const uint8_t* data, size_t length)
{
    uint16_t crc = 0xFFFF;  // CRC初始值 
    for (size_t i = 0; i < length; i++) {
        crc ^= (uint16_t)data[i];  // 与数据字节进行异或
        
        for (uint8_t j = 0; j < 8; j++) {
            if (crc & 0x0001) {  // 检查最低位是否为1
                crc >>= 1;       // 右移1位
                crc ^= 0xA001;   // 与多项式0xA001异或
            } else {
                crc >>= 1;       // 右移1位
            }
        }
    }
    
    // Modbus协议要求CRC字节顺序为：高字节在前，低字节在后
    // 交换字节顺序
    //uint16_t swappedCRC = ((crc << 8) & 0xFF00) | ((crc >> 8) & 0x00FF);
    return crc;
}

int RecvModbus03(const uint8_t* data, size_t length)
{
  if (length <8) return 0;
    // 01 03 00 00 00 01 A4 08 
    int count = data[4] *256 + data[5];
    SendBuff[0] =data[0];
    SendBuff[1] =data[1];
    SendBuff[2] =(byte)count *2;
    short tmp =1;
    for (size_t i = 0; i < count; i++) 
    {
       SendBuff[3+ i*2] = (uint8_t)(tmp >>8);
       SendBuff[3+ i*2+1] = (uint8_t)tmp;
       tmp++;
    }
    int crcLen= 3+count*2;
    // CRC LH
    uint16_t crc =ModbusCRC(SendBuff,crcLen);
    SendBuff[3+ count*2] = (uint8_t)crc;
    SendBuff[3+ count*2+1] =(uint8_t)(crc >>8); 
    return crcLen+2;
}

int RecvModbus10(const uint8_t* data, size_t length)
{
  if (length <8) return 0;
    // 发送:01 10 00 00 00 02 04 00 01 00 02 CRC_L CRC_H
    // 返回:01 10 00 00 00 02 CRC_L CRC_H
    int count = data[4] *256 + data[5];
    SendBuff[0] =data[0];
    SendBuff[1] =data[1];
    SendBuff[2] =data[2];
    SendBuff[3] =data[3];
    SendBuff[4] =data[4];
    SendBuff[5] =data[5];
    // CRC LH
    uint16_t crc =ModbusCRC(SendBuff,6);
    SendBuff[6] = (uint8_t)crc;
    SendBuff[7] =(uint8_t)(crc >>8); 
    return 8;
}

// RX特征的回调（用于接收数据）
class RxCharacteristicCallbacks: public BLECharacteristicCallbacks {
    void onWrite(BLECharacteristic* pCharacteristic) {
        uint8_t* value = pCharacteristic->getData();
        size_t length = pCharacteristic->getLength();
        if (length > 0) {
            Serial.print("RX: ");
            String hexString = uint8ToHexString(value, length);
            Serial.println(hexString);
            
            // 这里可以处理接收到的数据
            // 例如：解析命令、控制设备等
            if (value[1] == 0x03 ) // 03功能码
            {
                int sendLength= RecvModbus03(value, length);
                if (sendLength >0)
                {
                pCharacteristicTx->setValue(SendBuff,sendLength);
                pCharacteristicTx->notify();
                }

            }
            if (value[1] == 0x10  ) // 10功能码
            {
                int sendLength= RecvModbus10(value, length);
                if (sendLength >0)
                {
                pCharacteristicTx->setValue(SendBuff,sendLength);
                pCharacteristicTx->notify();
                }
            }

        }
    }
};

// TX特征的回调（用于发送数据）
class TxCharacteristicCallbacks: public BLECharacteristicCallbacks {
    void onRead(BLECharacteristic* pCharacteristic) {
        ReadCount++;
        Serial.println("TX read: " + String(ReadCount));
        // 当主机读取TX特征时，可以在这里准备要发送的数据
    }
};

void setup() {
  Serial.begin(115200);

  // 1. 初始化BLE
  BLEDevice::init("ESP32-BLE-Peripheral");

  // 2. 创建BLE服务器
  pServer = BLEDevice::createServer();
  pServer->setCallbacks(new MyServerCallbacks());

  // 3. 创建服务
  BLEService* pService = pServer->createService(SERVICE_UUID);

  // 4. 创建TX特征（用于发送数据到客户端）
  pCharacteristicTx = pService->createCharacteristic(
                       CHARACTERISTIC_UUID_TX,
                       BLECharacteristic::PROPERTY_NOTIFY | 
                       BLECharacteristic::PROPERTY_READ
                     );

  // 5. 创建RX特征（用于接收客户端数据）
  pCharacteristicRx = pService->createCharacteristic(
                       CHARACTERISTIC_UUID_RX,
                       BLECharacteristic::PROPERTY_WRITE_NR
                     );
 
  pCharacteristicTx->setCallbacks(new TxCharacteristicCallbacks());
  pCharacteristicTx->setAccessPermissions(ESP_GATT_PERM_READ | ESP_GATT_PERM_WRITE);
  pCharacteristicRx->setCallbacks(new RxCharacteristicCallbacks());
  pCharacteristicRx->setAccessPermissions(ESP_GATT_PERM_READ | ESP_GATT_PERM_WRITE);

  // 创建描述符
  BLE2902* p2902_rx = new BLE2902();
  p2902_rx->setNotifications(false);
  pCharacteristicRx->addDescriptor(p2902_rx);

  // 创建描述符
  BLE2902* p2902_tx = new BLE2902();
  p2902_tx->setNotifications(true);
  pCharacteristicTx->addDescriptor(p2902_tx);


  // 6. 启动服务
  pService->start();

  // 7. 开始广播
  BLEAdvertising* pAdvertising = BLEDevice::getAdvertising();
  pAdvertising->addServiceUUID(SERVICE_UUID);
  pAdvertising->setScanResponse(true);
  pAdvertising->setMinPreferred(0x06);  // 有助于iPhone连接
  pAdvertising->setMinPreferred(0x12);
  BLEDevice::startAdvertising();

  Serial.println("BLE Peripheral set up. Waiting for connections...");
  Serial.println("Device name: ESP32-BLE-Peripheral");
  Serial.println("Service UUID: " + String(SERVICE_UUID));
  Serial.println("TX Characteristic UUID: " + String(CHARACTERISTIC_UUID_TX));
  Serial.println("RX Characteristic UUID: " + String(CHARACTERISTIC_UUID_RX));
}

void loop() {
  // 处理连接状态变化
     static unsigned long lastSendTime = 0;

  if (!deviceConnected && oldDeviceConnected) {
    delay(500); // 给蓝牙栈一个缓冲时间
    pServer->startAdvertising(); // 重新开始广播
    Serial.println("Start Broadcast");
    oldDeviceConnected = deviceConnected;
  }
  if (deviceConnected && !oldDeviceConnected) {
    oldDeviceConnected = deviceConnected;
  }
  
  // 这里可以添加发送数据的代码
  if (deviceConnected) {
    // 示例：每隔一段时间发送数据
    if (millis() - lastSendTime > 2000) 
    { // 每2秒发送一次
      lastSendTime = millis();
      String data = "Connected Heartbeat ESP32: " + String(millis());
      Serial.println(data);
    }
  }
  else
  {
    if (millis() - lastSendTime > 2000) 
    { // 每2秒发送一次
        lastSendTime = millis();
        String data = "No BL Heartbeat ESP32: " + String(millis());
        Serial.println(data);
      }
  }
}