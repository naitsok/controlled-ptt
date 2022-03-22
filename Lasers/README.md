## Lasers

This directory contains the C# projects for the Laser modules. Each Laser module contains the C# application that connects to the laser hardware and controls it. The core of each Laser module is the [BaseLaser](./BaseLaser) DLL. All C# modules must reference and inherit from the [BaseLaser](./BaseLaser) class. The [ControlledPTT.App](../App) also references the [BaseLaser](./BaseLaser) and uses it to create the selected particular Laser modules. 

### Requirements

Each sensor part consists of two compnents: (1) the C# module to read the data sent from the sensor and send in to the [ControlledPTT.App](../App); (2) board connected to the sensor hardware and PC. The following requirements are in place:

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) to run the C# module on a PC with Windows OS. .NET Framework 4.7.2 is included by default in Windows 7 or higher.

### Selecting laser part

The currently developed laser parts are:
1. [CNI LED Laser](./Lasers/CNIMDLIII) with the MDL-III-LED controller. Controlled PTT 2 sends the power data to the controller via COM port connection. The Prolific USB-to-Serial Comm Port is [Lib](./Lasers/CNIMDLIII/Lib) folder.
2. Connect a laser diode to [Agilent N5768A or similar](./Lasers/Agilent) power supply, which is in turn connected to PC and Controlled PTT 2. The power supply sets the current to the laser diode and thus regulates its power.

If you have a specific laser hardware which can be connected to PC, new laser part [can be developed](#developing-a-new-laser-part) upon a [request](mailto:konstantin.tamarov@uef.fi) or by [yourself](#development).

### Developing a new laser part

The correct implementation of a new laser part requires at least the development the software parts. The hardware part is under supplier/manufacture of laser. The software part must be developed using Visual Studio 2019 and .NET Framework 4.7.2. The sensor part executable must be inherited from the [Baselaser](./BaseLaser) class, which is in turn inherited from the System.Windows.Forms.Form class. Refer to the source code for the available C# projects.

Here are the main moments that need to be considered:
- The C# project for sensor part must inherit from the [Baselaser](./BaseLaser).
- Not implemented methods in the [Baselaser](./BaseLaser) must be implemented.
- Post-build events must copy the compiled files, configurations, libraries, etc. to the build directory.