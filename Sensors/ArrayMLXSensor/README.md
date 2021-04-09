# Array MLX90621 sensor

This sketch and C# communication program are dedicated to reading temperatures simultaneously from 64 different pixels in Celcius with one MLX90621 16x4 IR thermal array or similar sensor. Sensor detects thermal radiation and measures temperatures without making contact with any objects. The temperature is read from all the pixels every second and send to serial port, which subsequently read and visualized by C# program. User can choose from which pixels the average temperature is calculated in C# program. This sensor needs Teensy or similar board. It is not compatible with Arduino due to larger memory requirements needed to store and send temperature data.


# Requirements

- Teensy or similar board (we used Teensy 3.6)
- MLX90621 IR thermal array or similar sensor
- Two resistors (4,7 kOhm)
- One capacitor (100 nF)
- One silicion diode (dropout voltage  ~0.7V)
- USB wire
- Arduino studio
- .Net version
- Visual Studio Code or Visual Studio 2019

# Board Wiring

- Connect the Anode of a Silicon Diode to 3V Pin of Teensy. The Diode will drop ~0.7V, so the Cathode will be at ~2.7V. These 2.7V will be the supply voltage “VDD” for the sensor.
- Plug in the USB and measure the supply voltage with a multimeter. It should be somewhere between 2.5V and 2.75V, else it will fry your sensor.
- Disconnect USB.
- Connect Teensy Pin 18 to 2.7V with a 4.7kOhm Resistor (Pullup)
- Connect Teensy Pin 19 to 2.7V with a 4.7kOhm Resistor (Pullup)
- Connect Teensy Pin 18 to I2C Data (SDA) Pin of Sensor
- Connect Teensy Pin 19 to I2C clock (SCL) Pin of Sensor
- Connect GND and 2.7V with a 100nF ceramic Capacitor.
- Connect the VSS Pin of the Sensor to GND.
- Connect the VDD Pin of the Sensor to 2.7V

 See below for a Fritzing diagram with a Teensy 3.1 – a circuit analogous to our Teensy 3.6 setup. 
 
<img src= "https://github.com/Mikkevaris/controlledptt-sensor/blob/master/array-mlx-sensor/Board_wiring.png" height="400" width="600">

# Compilation

To compile the Arduino sketch, [nox771's i2c_t3 enhanced Teensy 3 Wire library](https://github.com/nox771/i2c_t3) is needed. This library allows a Teensy 3.x or Arduino compatible USB development board to communicate with the MLX90621 over I2C/TWI. You'll need to install this library into your Arduino IDE by opening the IDE and clicking the "sketch" menu and then Include Library > Add .ZIP Library. You will be asked to select the library you would like to add. The library can be found in this repository's lib folder. Navigate to the .zip file's location and open it. Return to the Sketch > Include Library menu. You should now see the library at the bottom of the drop-down menu. It is ready to be used in your sketch. 

The sketch also utilizes MaxBot's MLX90621 [Arduino library](https://forum.arduino.cc/index.php?topic=126244.0) patched with KMoto's [minor change](https://forum.arduino.cc/index.php?topic=126244.msg2307588#msg2307588) in defaultConfig_H. Library is already included in readTemperatures folder by separated .cpp and .h files, so you don't need to install it like as just described before. MLX90621.h is a header file which contains C function declarations and macro definitions to be shared with the source code file. MLX90621.cpp is a source code file that adds features to header file's declarations and definitions. These files provides sensor's functionality and methods for use in sketch. There's no need to make any changes in these files but they must be in same folder with readTemperatures.ino in order to sketch to work.

Final step in order to compile the sketch is to make Teensy development board work with the Arduino IDE. To do this you'll need to install few programs. Setup Teensy by following the instructions found in [here](https://www.pjrc.com/teensy/tutorial.html). After the setup, you are ready to upload readTemperatures sketch into the Teensy. Open readTemperatures.ino file in Arduino IDE and click "Upload" on top left corner. After uploading is done, make sure that code runs correctly by viewing the serial monitor in Arduino IDE. If it displays temperature readings, code works correctly. 

# Running C# program

When the Arduino sketch is uploaded to Teensy, you are ready to move on to the C# program. Start by opening array-mlx.sln in Visual Studio. However, before you can run the program there's still few things to do. The program uses BaseSensor as a base class, which handles the communication with the hardware. You'll need to include a .dll reference generated of this class in array-mlx program. To do so, first open BaseSensor.sln in your Visual Studio. Basesensor.sln can be found in repository's base-sensor folder. On the toolbar choose the Release option as shown in image below.

<img src = "https://github.com/Mikkevaris/controlledptt-sensor/blob/master/array-mlx-sensor/toolbarbuildconfiguration.png">

Then select Build > Build Solution. After building is succeeded you can close the BaseSensor class. Now in array-mlx window right click References which can be found in Solution Explorer on right side of the Visual Studio window. Click "Add References" and then "Browse" in Reference Manager window. Navigate to this repository's folder and then base-sensor > bin > Release and add BaseSensor.dll. Make sure that .dll is checked in Reference Manager window and click "OK". Reference of the BaseSensor class is now included.

Last step in order to run the program is to download Serilog NuGet package. Serilog provides diagnostic logging to files and it is used in this program. Right click on "array-mlx" in Solution Explorer and select "Manage NuGet Packages..." It opens a window in your Visual Studio where you can browse and install different kind of packages for your project. Search "Serilog" and install the latest version of it. After the installation the program should be ready for running. Run the program by selecting "Start" on the toolbar and the sensor's interface should pop up. The program is now ready for visualizing the temperature readings.
