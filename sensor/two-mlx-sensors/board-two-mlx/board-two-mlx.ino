/****************************************************************************** 
Arduino, Teensy 3.x or similar board to read temperature from one MLX90614 or similar
infrared temperature sensor. Reads the temperature in Celcius and 
send the data via serial port each second. To see output in
Arduino studio, open serial monitor and seth the baud rate to 9600.

Hardware Hookup (if you're not using the eval board):
MLX90614 ------------- Arduino, Teensy 3.x or compatible board
  VDD ------------------ 3.3V
  VSS ------------------ GND
  SDA ------------------ PIN 18 (SDA PIN if using arduino board)
  SCL ------------------ PIN 19 (SCL PIN if using arduino board)

Development environment specifics:
Arduino 1.8.12
SparkFun IR Thermometer Evaluation Board - MLX90614
******************************************************************************/

#include "Adafruit_MLX90614.h" 
                               
#include <Wire.h>

//Define device's addresses
int device1Address = 0x0A;   // If addresses has been changed, it can be checked using sketch                                                 
int device2Address = 0x50;   // in Utils folder of repository.

//Create two instances of the sensor class.
Adafruit_MLX90614 mlx = Adafruit_MLX90614(device1Address);
Adafruit_MLX90614 mlx2 = Adafruit_MLX90614(device2Address);

//Sensor 1
float obj_temp1 = 0;             // Sensor measures temperature from the object
float amb_temp1 = 0;             // and on its shell

//Sensor 2
float obj_temp2 = 0;
float amb_temp2 = 0;

int counter = 0;                // to average measurements

void setup() 
{
  Serial.begin(9600);

  mlx.begin(); // Initialise the I2C bus.
  
}

void loop()
{
  // read the temperatures from sensor 1.
  obj_temp1 += mlx.readObjectTempC();
  amb_temp1 += mlx.readAmbientTempC(); 

  // read the temperatures from sensor 2.
  obj_temp2 += mlx2.readObjectTempC();
  amb_temp2 += mlx2.readAmbientTempC();

  counter++;

  if ( counter == 5 )
  {
    obj_temp1 = obj_temp1 / 5;
    amb_temp1 = amb_temp1 / 5;
    obj_temp2 = obj_temp2 / 5;
    amb_temp2 = amb_temp2 / 5;
    Serial.println(String(obj_temp1,2) + " " + String(amb_temp1,2) + " " + String(obj_temp2,2) + " " + String(amb_temp2,2)); // It must be printed like this so that C# visualisation works.
    obj_temp1 = 0;
    amb_temp1 = 0;
    obj_temp2 = 0;
    amb_temp2 = 0;
    counter = 0;
  }
  delay(200);
   

}
