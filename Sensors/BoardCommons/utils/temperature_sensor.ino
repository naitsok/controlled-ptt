/****************************************************************************** 
MLX90614_Serial_Demo.ino
Serial output example for the MLX90614 Infrared Thermometer

This example reads from the MLX90614 and prints out ambient and object 
temperatures every half-second or so. Open the serial monitor and set the
baud rate to 9600.

Hardware Hookup (if you're not using the eval board):
MLX90614 ------------- Arduino
  VDD ------------------ 3.3V
  VSS ------------------ GND
  SDA ------------------ SDA (A4 on older boards)
  SCL ------------------ SCL (A5 on older boards)
  
An LED can be attached to pin 8 to monitor for any read errors.

Jim Lindblom @ SparkFun Electronics
October 23, 2015
https://github.com/sparkfun/SparkFun_MLX90614_Arduino_Library

Development environment specifics:
Arduino 1.6.5
SparkFun IR Thermometer Evaluation Board - MLX90614
******************************************************************************/

#include <Wire.h> // I2C library, required for MLX90614
#include <SparkFunMLX90614.h> // SparkFunMLX90614 Arduino library

IRTherm therm; // Create an IRTherm object to interact with throughout
int counter;
double objTemp;
double ambTemp;

// const byte LED_PIN = 8; // Optional LED attached to pin 8 (active low)

void setup() 
{
  Serial.begin(9600); // Initialize Serial to log output
  therm.begin(); // Initialize thermal IR sensor
  therm.setUnit(TEMP_C); // Set the library's units to Farenheit
  counter = 0;
  objTemp = 0;
  ambTemp = 0;
  // Alternatively, TEMP_F can be replaced with TEMP_C for Celsius or
  // TEMP_K for Kelvin.
  
  // pinMode(LED_PIN, OUTPUT); // LED pin as output
  // setLED(LOW); // LED OFF
}

void loop() 
{
  // setLED(HIGH); //LED on
  
  // Call therm.read() to read object and ambient temperatures from the sensor.
  if (therm.read()) // On success, read() will return 1, on fail 0.
  {
    // Use the object() and ambient() functions to grab the object and ambient
	  // temperatures.
	  // They'll be floats, calculated out to the unit you set with setUnit().
    // print temperature separated by space: first object temp, then ambient temp;
  
    // Measure temperature each 0.1 second. Average 5 measurement, send data each 0.5 second

    objTemp += therm.object();
    ambTemp += therm.ambient();
    counter += 1;

    if(counter == 5)
    {
      objTemp = objTemp / 5;
      ambTemp = ambTemp / 5;
      Serial.println(String(objTemp, 2) + " " + String(ambTemp, 2));
      objTemp = 0;
      ambTemp = 0;
      counter = 0;
    }
  }
  delay(100);
}

/*
void setLED(bool on)
{
  if (on)
    digitalWrite(LED_PIN, LOW);
  else
    digitalWrite(LED_PIN, HIGH);
}
*/
