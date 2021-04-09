# One MLX90614 Sensor

This sketch and C# communication program are dedicated to reading temperature in Celcius from one MLX90614 or similar infrared temperature sensor. Sensor detects thermal radiation and measures temperatures without making contact with any objects. The temperature is read 5 times each 0.2 second, averaged and sent to serial port, which subsequently read and displayed by C# program.

# Requirements

- Arduino or similar board (we used Teensy 3.6)
- One MLX90614 or similar sensor (we used MLX90614 Infrared Thermometer)
- Two resistors (4,7 kOhm)
- One capacitor (100 nF)
- One silicon diode (dropout voltage ~0.7V)
- USB wire
- Arduino Studio
- .NET version
- Visual Studio Code or Visual Studio 2019 (this maybe not needed if we compile C# programs beforehand)

# Board Wiring

- Connect the Anode of a Silicon Diode to 3V Pin of Teensy. The Diode will drop ~0.7V, so the Cathode will be at ~2.7V. These 2.7V will be the supply voltage “VDD” for the sensor.
- Plug in the USB and measure the supply voltage with a multimeter. It should be somewhere between 2.5V and 2.75V, else it might fry your sensor.
- Disconnect USB.
- Connect Teensy Pin 18 to 2.7V with a 4.7kOhm Resistor (Pullup)
- Connect Teensy Pin 19 to 2.7V with a 4.7kOhm Resistor (Pullup)
- Connect Teensy Pin 18 to I2C Data (SDA) Pin of Sensor
- Connect Teensy Pin 19 to I2C clock (SCL) Pin of Sensor
- Connect GND and 2.7V with a 100nF ceramic Capacitor.
- Connect the VSS Pin of the Sensor to GND.
- Connect the VDD Pin of the Sensor to 2.7V

 See below for a Fritzing diagram with a Teensy 3.1 – a circuit analogous to our Teensy 3.6 setup. 
 
<img src="https://github.com/Mikkevaris/controlledptt-sensor/blob/master/one-mlx-sensor/OneMlx.png" height="350" width="600">

# Compilation

To compile the Arduino sketch, [Adafruit's MLX60914 library](https://github.com/adafruit/Adafruit-MLX90614-Library) is needed. Library is already included in one-mlx-sensor folder by separated .cpp and .h files, so you don't need to download it. Adafruit_MLX90614.h is a header file which contains C function declarations and macro definitions to be shared with the source code file. Adafruit_MLX90614.cpp is a source code file that adds features to header file's declarations and definitions. These files provides sensor's functionality and methods for use in sketch. There's no need to make any changes in these files but they must be in same folder with one-mlx-sensor.ino in order to sketch to work.

Sketch also utilizes Arduino's standard library [Wire](https://www.arduino.cc/en/Reference/Wire). The library allows a Teensy 3.x or Arduino compatible USB development board to communicate with the MLX90614 over I2C/TWI. As a Arduino's standard library, it is automatically installed with your Arduino IDE and ready for use. 

In order to compile the sketch is to make Teensy development board work with the Arduino IDE. To do this you'll need to install few programs. Setup Teensy by following the instructions found in [here](https://www.pjrc.com/teensy/tutorial.html). After the setup, you are ready to upload one-mlx-sensor sketch into the Teensy. Open one-mlx-sensor.ino file in Arduino IDE and click "Upload" on top left corner. After uploading is done, make sure that code runs correctly by viewing the serial monitor in Arduino IDE. If it displays temperature readings, code works correctly. If it doesn't display anything, wrong address of the sensor might be defined in the sketch. To fix this, see the section below.

# Scanning and changing the address of sensor

Sensor's default address is 0x5A. Address of the sensor can be checked using i2c_scanner sketch in utils folder. This sketch uses only Arduino's standard library [Wire](https://www.arduino.cc/en/Reference/Wire), so it is immediately ready for use. Open i2c_scanner in your Arduino IDE and upload it to your development board. After the uploading is complete, view the serial monitor and it should display your sensor's address there. If it didn't display any temperature readings in the previous section, open one-mlx-sensor.ino again if closed. Open Adafruit_MLX90614.h tab and change the definition of address to the correct one, which you just checked with i2c_scanner sketch. The place where to write your right address is commented in the code. Upload the one-mlx-sensor.ino again to your development board and view the serial monitor. It should now display the temperature readings.

If it is needed to change the sensor's address, use i2c_change_address sketch in utils folder. This sketch works only with Arduino or similar development board. Teensy development boards doesn't support I2Cmaster library which is needed in order to compile the sketch. Open i2c_change_address in your Arduino IDE. Before you can upload the sketch, you'll need to install the mentioned library into your Arduino IDE by clicking the "sketch" menu and then Include Library > Add .ZIP Library. You will be asked to select the library you would like to add. The library can be found in this repository's lib folder. Navigate to the .zip file's location and open it. Return to the Sketch > Include Library menu. You should now see the library at the bottom of the drop-down menu. It is ready to be used in your sketch. The place where you need to write the desired new address is commented on in the code. Upload the sketch and the address of sensor should be changed. 

# Running C# program

When the Arduino sketch is uploaded to development board, you are ready to move on to the C# program. Start by opening one-mlx-sensor.sln in Visual Studio, which can be found in pc-mlx folder. However, before you can run the program there's still few things to do. The program uses BaseSensor as a base class, which handles the communication with the hardware. You'll need to include a .dll reference generated of this class in one-sensor-mlx program. To do so, first open BaseSensor.sln in your Visual Studio. Basesensor.sln can be found in repository's base-sensor folder. On the toolbar choose the Release option as shown in image below.

<img src = "https://github.com/Mikkevaris/controlledptt-sensor/blob/master/array-mlx-sensor/toolbarbuildconfiguration.png">

Then select Build > Build Solution. After building is succeeded you can close the BaseSensor class. Now in one-mlx-sensor window right click References which can be found in Solution Explorer on right side of the Visual Studio window. Click "Add References" and then "Browse" in Reference Manager window. Navigate to this repository's folder and then base-sensor > bin > Release and add BaseSensor.dll. Make sure that .dll is checked in Reference Manager window and click "OK". Reference of the BaseSensor class is now included.

Last step in order to run the program is to download Serilog NuGet package. Serilog provides diagnostic logging to files and it is used in this program. Right click on "one-mlx-sensor" in Solution Explorer and select "Manage NuGet Packages..." It opens a window in your Visual Studio where you can browse and install different kind of packages for your project. Search "Serilog" and install the latest version of it. After the installation the program should be ready for running. Run the program by selecting "Start" on the toolbar and the sensor's interface should pop up. The program is now ready for visualizing the temperature readings.
