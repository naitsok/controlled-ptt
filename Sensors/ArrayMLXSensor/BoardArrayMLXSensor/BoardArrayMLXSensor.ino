
/*
* A class for interfacing the Melexis 90620 Sensor from a Teensy 3.1
* Uses the i2c_t3 library for communication with the sensor
* 2013 by Felix Bonowski
* Based on a forum post by maxbot: http://forum.arduino.cc/index.php/topic,126244.msg949212.html#msg949212
* This code is in the public domain.
*
* Connection Instructions:
* Connect the Anode of a Silicon Diode to 3V Pin of Teensy. The Diode will drop ~0.7V, so the Cathode will be at ~2.7V. These 2.7V will be the supply voltage "VDD" for the sensor.
* Plug in the USB and measure the supply voltage with a multimeter! - it should be somewhere between 2.5V and 2.75V, else it will fry your precious sensor...
* ...disconnect USB again...
* Connect Teensy Pin 18 to 2.7V with a 4.7kOhm Resistor (Pullup)
* Connect Teensy Pin 19 to 2.7V with a 4.7kOhm Resistor (Pullup)
* Connect Teensy Pin 18 to I2C Data (SDA) Pin of Sensor
* Connect Teensy Pin 19 to I2C clock (SCL) Pin of Sensor
* Connect GND and 2.7V with a 100nF ceramic Capacitor.
* Connect the VSS Pin of the Sensor to GND.
* Connect the VDD Pin of the Sensor to 2.7V

 *  Created on: 9.7.2015
 *      Author: Robin van Emden
 */

#include <Arduino.h>
#include <i2c_t3.h>
#include "MLX90621.h"

MLX90621 sensor; // create an instance of the Sensor class
String data = "";

void setup(){ 
  Serial.begin(19200);
  // Serial.println("trying to initialize sensor...");
  sensor.initialise(16); // start the thermo cam with 8 frames per second
  // Serial.println("sensor initialized!");
}

void loop(){
  sensor.measure(); //get new readings from the sensor
  
  for(int i = 0; i < 4; i++){ //go through all the rows
    for(int j = 0; j < 16; j++){ //go through all the columns
      double temperature = sensor.getTemperature(j + i * 4); // extract the temperature at position i,j
      data = data + String(temperature, 2) + "\t";
    }
  }
  double ambTemperature = sensor.getAmbient();
  data = data + String(ambTemperature, 2) + "\t";
  Serial.println(data);
  data = "";
  delay(250);
}
