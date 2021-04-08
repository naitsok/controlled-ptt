# Two MLX90614 sensors

This folder contains code to communicate with two MLX90614 or similar sensors connected to one Arduino, Teensy or similar boards. In order to use two sensors simultaneously, their addresses must be different. Sensors detects thermal radiation and measures temperatures without making contact with any objects. The temperatures are read 5 times each 0.2 second separately with both sensors, averaged and sent to serial port, which subsequently read and displayed by C# program.

# Requirements

- Arduino or similar board (we used Teensy 3.6)
- Two MLX90614 or similar sensor (we used MLX90614 Infrared Thermometer)
- Two resistors (4,7 kOhm)
- Two capacitors (100 nF)
- Two silicon diodes (dropout voltage ~0.7V)
- USB wire
- Arduino Studio
- .NET version
- Visual Studio Code or Visual Studio 2019 (this maybe not needed if we compile C# programs beforehand)

# Board Wiring

- Connect the Anodes of a Silicon Diodes to 3V Pin of Teensy. The Diodes will drop ~0.7V, so the Cathodes will be at ~2.7V. These 2.7V will be the supply voltage “VDD” for the sensors.
- Plug in the USB and measure the supply voltage with a multimeter. It should be somewhere between 2.5V and 2.75V, else it might fry your sensor.
- Disconnect USB.
- Connect Teensy Pin 18 to 2.7V with a 4.7kOhm Resistor (Pullup)
- Connect Teensy Pin 19 to 2.7V with a 4.7kOhm Resistor (Pullup)
- Connect Teensy Pin 18 to I2C Data (SDA) Pin of the first Sensor
- Connect Teensy Pin 19 to I2C clock (SCL) Pin of the first Sensor
- Connect GND and 2.7V with a 100nF ceramic Capacitor.
- Connect the VSS Pin of the first Sensor to GND.
- Connect the VDD Pin of the first Sensor to 2.7V
- Connect Teensy Pin 18 to I2C Data (SDA) Pin of the second Sensor
- Connect Teensy Pin 19 to I2C clock (SCL) Pin of the second Sensor
- Connect GND and 2.7V with a 100nF ceramic Capacitor.
- Connect the VSS Pin of the second Sensor to GND.
- Connect the VDD Pin of the second Sensor to 2.7V

 See below for a Fritzing diagram with a Teensy 3.1 – a circuit analogous to our Teensy 3.6 setup. 
 
<img src="https://github.com/Mikkevaris/controlledptt-sensor/blob/master/two-mlx-sensors/Two-point-sensors-board-wiring.png" height="350" width="600">

# Scanning and changing the address of sensor

Sensor's default address is 0x5A. Address of the sensor can be checked using i2c_scanner sketch in utils folder. This sketch uses only Arduino's standard library [Wire](https://www.arduino.cc/en/Reference/Wire), so it is immediately ready for use. Open i2c_scanner in your Arduino IDE and upload it to your development board. After the uploading is complete, view the serial monitor and it should display the addresses of your sensors there.

As mentioned before, in order to use two sensors simultaneously, their addresses must be different. So you have to change the address of one your sensor using i2c_change_address sketch found in utils folder. Keep in mind that this sketch compiles only with Arduino or similar development board. Teensy development boards doesn't support I2Cmaster library which is needed in order to compile the sketch. Also note that you can have only one sensor in the circuit when changing the address, so remove the other sensor before running this sketch.

Start by opening i2c_change_address in your Arduino IDE. Before you can upload the sketch, you'll need to install the I2Cmaster library into your Arduino IDE by clicking the "sketch" menu and then Include Library > Add .ZIP Library. You will be asked to select the library you would like to add. The library can be found in this repository's lib folder. Navigate to the .zip file's location and open it. Return to the Sketch > Include Library menu. You should now see the library at the bottom of the drop-down menu. It is ready to be used in your sketch. Instructions where to write the new desired address of the sensor can be found commented in the sketch. Write the new address and upload the sketch. Address of the sensor should now be changed.

# Compilation

To compile the Arduino sketch, [Adafruit's MLX60914 library](https://github.com/adafruit/Adafruit-MLX90614-Library) is needed. Library is already included in two-mlx-sensor folder by separated .cpp and .h files, so you don't need to download it. Adafruit_MLX90614.h is a header file which contains C function declarations and macro definitions to be shared with the source code file. Adafruit_MLX90614.cpp is a source code file that adds features to header file's declarations and definitions. These files provides sensor's functionality and methods for use in sketch. There's no need to make any changes in these files but they must be in same folder with two-mlx-sensor.ino in order to sketch to work.

Sketch also utilizes Arduino's standard library [Wire](https://www.arduino.cc/en/Reference/Wire). The library allows a Teensy 3.x or Arduino compatible USB development board to communicate with the MLX90614 over I2C/TWI. As a Arduino's standard library, it is automatically installed with your Arduino IDE and ready for use. 

If using Teensy development board, you'll need to make Teensy work with the Arduino IDE in order to compile the sketch. To do this you'll need to install few programs. Setup Teensy by following the instructions found in [here](https://www.pjrc.com/teensy/tutorial.html). 

You are now ready to upload two-mlx-sensor sketch. Open two-mlx-sensor.ino file in Arduino IDE. You'll see the part in code where the addresses of sensors are defined. Change the correct addresses of sensors which you determined in previous section. Click "Upload" on top left corner. After uploading is done, make sure that code runs correctly by viewing the serial monitor in Arduino IDE. If it displays temperature readings, code works correctly. If it doesn't display anything, wrong addresses of the sensors might still be defined in the sketch. To fix this, see the section above again.

# Running C# program

When the Arduino sketch is uploaded to development board, you are ready to move on to the C# program. Start by opening two-mlx-sensor.sln in Visual Studio, which can be found in Pc-mlx folder. However, before you can run the program there's still few things to do. The program uses BaseSensor as a base class, which handles the communication with the hardware. You'll need to include a .dll reference generated of this class in one-sensor-mlx program. To do so, first open BaseSensor.sln in your Visual Studio. Basesensor.sln can be found in repository's base-sensor folder. On the toolbar choose the Release option as shown in image below.

<img src = "https://github.com/Mikkevaris/controlledptt-sensor/blob/master/array-mlx-sensor/toolbarbuildconfiguration.png">

Then select Build > Build Solution. After building is succeeded you can close the BaseSensor class. Now in two-mlx-sensor window right click References which can be found in Solution Explorer on right side of the Visual Studio window. Click "Add References" and then "Browse" in Reference Manager window. Navigate to this repository's folder and then base-sensor > bin > Release and add BaseSensor.dll. Make sure that .dll is checked in Reference Manager window and click "OK". Reference of the BaseSensor class is now included.

Last step in order to run the program is to download Serilog NuGet package. Serilog provides diagnostic logging to files and it is used in this program. Right click on "two-mlx-sensor" in Solution Explorer and select "Manage NuGet Packages..." It opens a window in your Visual Studio where you can browse and install different kind of packages for your project. Search "Serilog" and install the latest version of it. After the installation the program should be ready for running. Run the program by selecting "Start" on the toolbar and the sensor's interface should pop up. The program is now ready for visualizing the temperature readings.
