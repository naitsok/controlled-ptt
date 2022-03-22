## Sensors

This directory contains the C# projects for the Sensor modules. Each Sensor module contains the C# application, the sketches for Arduino studio to program the boards, and instructions for board wiring. The core of each Sensor module is the [BaseSensor](./BaseSensor) DLL. All C# modules must reference and inherit from the [BaseSensor](./BaseSensor) class. The [ControlledPTT.App](../App) also references the [BaseSensor](./BaseSensor) and uses it to create the selected particular Sensor modules. 

### Requirements

Each sensor part consists of two compnents: (1) the C# module to read the data sent from the sensor and send in to the [ControlledPTT.App](../App); (2) board connected to the sensor hardware and PC. The following requirements are in place:

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) to run the C# module on a PC with Windows OS. .NET Framework 4.7.2 is included by default in Windows 7 or higher.
- [Arduino Studio 1.8.13](https://www.arduino.cc/en/software) or higher. Arduino Studio is needed to install necessary drivers and upload the program to the board. More details in the [sensors section](#selecting-sensor-part).

### Selecting sensor part

The curently developed sensor parts are based on the [Melexis](https://www.melexis.com/en) infrared temperature sensors:
1. MLX90621ESF-BAD-000. 16x4  array sensor with FOV 40x10 degrees (40 - 50 €).
2. MLX90614ESF-BCF-000. Single pixel sensor with FOV 10 degrees (25 - 35 €).
3. MLX90614ESF-BCI-000. Single pixel sensor with FOV 5 degrees (30 - 40 €).

The latter two single point sensors can be used on their own with a basic Arduino board (Uno, RedBoard, etc.). See [MLX Sensor](./Sensors/MLXSensor) part for more details. 

Furthermore, two single point sensors can be simultaneously attached to one board for better precision. See [Two MLX Sensors](./Sensors/TwoMLXSensors) part for more details. 

Array sensor requires a board with more memory than Arduino. In our case a [Teensy 3.6](https://www.pjrc.com/teensy/) board was used. See [Array MLX Sensor](./Sensors/ArrayMLXSensor) part for more details.

In order to use a selected sesnor part, the sensor must be correcly mounted to board and the appropriate sketch must be uploaded to the board. The detailed description of board wiring and sketch uploading can be found on the links above.

If there is no part suitable for your hardware, new sensor part [can be developed](#developing-a-new-sensor-part) upon a [request](mailto:konstantin.tamarov@uef.fi) or by [yourself](#development). 

#### Troubleshooting

- Make sure that the board connected via USB is recognized by PC. It can be done using Windows Device Manager and checking if there are unrecognized USB devices.
- After uploading the sketch to the board using Arduino Studio, Serial Monitor there can be used to check if board is sending data to PC.
- The compiled Windows Forms executables for each sensor part can be run separately without running ControlledPTT.App. By clicking "Connect to Board" button, the received data from board can be verified. Note that Serial Monitor of Arduino Studio must be closed and the appropriate COM port must be selected.

### Developing a new sensor part

[BoardCommons](./BoardCommons) folder contains necessary libraries for Arduino Studio, example sketches and utilites, such as getting/setting the addresses for the connected sensors. 

The correct implementation of a new sensor part requires the development of hardware and software parts. The hardware part is completely under one's specification. The software part must be developed using Visual Studio 2019 and .NET Framework 4.7.2. The sensor part executable must be inherited from the [BaseSensor](./BaseSensor) class, which is in turn inherited from the System.Windows.Forms.Form class. Refer to the source code for the available C# projects and the Arduino Studio sketches.

Here are the main moments that need to be considered:
- The C# project for sensor part must inherit from the [BaseSensor](./BaseSensor).
- Not implemented methods in the [BaseSensor](./BaseSensor) must be implemented.
- Post-build events must copy the compiled files, configurations, libraries, etc. to the build directory.



