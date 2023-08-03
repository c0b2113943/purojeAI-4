#include <Arduino.h>

#include <Wire.h>
#include <MPU6050.h>

MPU6050 mpu;

void setup()
{
  Wire.begin();
  Wire.beginTransmission(0x68); // MPU6050のアドレス
  Wire.write(0x6B); // PWR_MGMT_1 レジスタにアクセス
  Wire.write(0); // MPU6050を起動
  Wire.endTransmission(true);

  Serial.begin(9600);
}

void loop()
{
  int16_t ax, ay, az, gx, gy, gz;
  mpu.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);

  // データをカンマ区切りでシリアルポートに送信
  Serial.print(ay+550); // pitch
  // Serial.print(",");
  // Serial.print(ax-600); // roll
  Serial.println();

  delay(17);
}
