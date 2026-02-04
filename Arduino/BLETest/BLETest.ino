#include <BLEDevice.h>
#include <BLEServer.h>
#include <BLEUtils.h>
#include <BLE2902.h>

// 自定义UUID，随意生成或使用在线工具
#define SERVICE_UUID           "0000fff0-0000-1000-8000-00805f9b34fb"
#define CHARACTERISTIC_UUID_RX "0000fff1-0000-1000-8000-00805f9b34fb"
#define CHARACTERISTIC_UUID_TX "0000fff2-0000-1000-8000-00805f9b34fb"

BLEServer* pServer = NULL;
BLECharacteristic* pCharacteristicTx = NULL;
//BLECharacteristic* pCharacteristicRx = NULL;
bool deviceConnected = false;
bool oldDeviceConnected = false;
int ReadCount =0;
// 回调函数：连接、断开时的处理
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

String uint8ToHexString(const uint8_t* data, size_t length) {
    String result = "";
    for (size_t i = 0; i < length; i++) {
        if (data[i] < 16) result += "0";  // 补零
        result += String(data[i], HEX);
    }
    result.toUpperCase();  // 转换为大写
    return result;
}

// 数据接收回调
class CharacteristicCallbacks: public BLECharacteristicCallbacks {
    void onWrite(BLECharacteristic* pCharacteristic) {
        uint8_t* value = pCharacteristic->getData();
        size_t length = pCharacteristic->getLength();
        if (length > 0) {
            Serial.print("Received data: ");
            String hexString = uint8ToHexString(value, length);
            Serial.print(hexString);
            Serial.println();
            
            // 示例：收到数据后回复确认
            if (deviceConnected) {
                String response = "ACK:";
                pCharacteristicTx->setValue(value,length);
                //pCharacteristicTx->notify();
                Serial.println("Sent ACK:" + response);
            }
        }
    }

      void onRead(BLECharacteristic* pCharacteristic) {
        // 当主机读取该特征值时，此函数会被调用
        ReadCount++;
        Serial.println("onRead:" + String(ReadCount) );
        // 核心逻辑：读取完成后，清空特征值的数据
        // 注意：这里只是清空了BLE特征值当前缓存的数据。
        // 您需要同时清空您的数据源（如全局变量g_sensorData）
        // 可选：也可以显式地设置特征值的值为空
        //pCharacteristic->setValue(""); 
    }

};


void setup() {
  Serial.begin(115200);

  // 1. 初始化 BLE
  BLEDevice::init("ESP32-BLE-Peripheral");

  // 2. 创建BLE服务器
  pServer = BLEDevice::createServer();
  pServer->setCallbacks(new MyServerCallbacks());

  // 3. 创建服务
  BLEService* pService = pServer->createService(SERVICE_UUID);

  // 4. 在该服务下创建一个可读写的Characteristic
  pCharacteristicTx = pService->createCharacteristic(
                       CHARACTERISTIC_UUID_TX,
                       BLECharacteristic::PROPERTY_READ   |
                       BLECharacteristic::PROPERTY_NOTIFY |
                       BLECharacteristic::PROPERTY_WRITE  
                     );

  // 5. 为Characteristic添加描述（可选）
  pCharacteristicTx->addDescriptor(new BLE2902());
  pCharacteristicTx->setCallbacks(new CharacteristicCallbacks());

  // 6. 启动服务
  pService->start();

  // 7. 设为可被Central发现、连接
  BLEAdvertising* pAdvertising = BLEDevice::getAdvertising();
  pAdvertising->addServiceUUID(SERVICE_UUID);
  pAdvertising->setScanResponse(true);
  BLEDevice::startAdvertising();

  Serial.println("BLE Peripheral set up. Waiting for connections...");
  Serial.println("Device name: ESP32-BLE-Peripheral");
  Serial.println("Service UUID: " + String(SERVICE_UUID));
}

void loop() {

  // 处理设备连接状态变化
    if (!deviceConnected && oldDeviceConnected) {
        delay(500); // 给蓝牙栈一个缓冲时间
        pServer->startAdvertising(); // 重新开始广播
        Serial.println("Restart advertising...");
        oldDeviceConnected = deviceConnected;
    }
    
    if (deviceConnected && !oldDeviceConnected) {
        oldDeviceConnected = deviceConnected;
    }


  // 简单示例：每隔5秒向已连接设备Notify一次计数
  static unsigned long lastMillis = 0;
  static int count = 0;

  if(millis() - lastMillis > 5000) {
    lastMillis = millis();
    //if(deviceConnected) 
    {
      count++;
      String data = "Runing:" + String(count) +" Connected:" + String(deviceConnected);
      pCharacteristicTx->setValue(data.c_str());
      pCharacteristicTx->notify();
      Serial.println(data);
      //pCharacteristicTx->setValue("");  // 清空数据
    }
  }

   // 处理串口输入（用于测试发送自定义数据）
    if (Serial.available()) {
        //Serial.readBytes()
        String input = Serial.readString();
        bool is_at= input.startsWith("AT");
        if (is_at)
        {
          input.trim();
          Serial.println("Recv AT Cmd:" + input);
        }
        else
        {
            if (input.length() > 0 && deviceConnected) 
            {
              pCharacteristicTx->setValue(input.c_str());
              Serial.println("Sent To BL:" + input);
            }
        }
    }
    
    delay(10); // 短暂延迟以减少CPU占用

}
