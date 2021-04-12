[![version](https://img.shields.io/badge/version-v2.0-orange)](https://github.com/naitsok/controlled-ptt/)
[![build](https://img.shields.io/badge/build-passing-green.svg)](https://github.com/naitsok/controlled-ptt/releases/)

[![License](https://img.shields.io/badge/license-MIT-blue)](./LICENSE)

# Controlled Photothermal Therapy 2.0

Controlled Photothermal Therapy 2.0 (or just Controlled PTT 2) is the second version of software and hardware setup to study thermal effects of nanoparticles under laser irradiation *in vitro* (on living cells) or *in vivo* (in small animals). The primary aim is to control the temperature if cell media *in vitro*, but the setup can be applied for animal studies. Depending on time of laser irradiation, nanoparticle type, their photothermal conversion efficiency, different thermal dose can be delivered to the irradiated object. Thus, different biological responses can be triggered depending on the maximum achived temperature and gained thermal dose. More about thermal dose can be found in our [publication](https://www.sciencedirect.com/science/article/pii/S0378517320306414).

Controlled PTT 2 consists of two main parts: [hardware part](#hardware) and [software part](#software). The hardware part consists of temperature sensor(s) and a laser. Depending on the application, different sensor parts and laser parts can be used. You can also develop your own sensor or laser parts, or they can be developed specifically for you upon a request. Please contact [Konstantin Tamarov](mailto:konstantin.tamarov@uef.fi) to discuss your requirements.

Controlled PTT 2 was developed by Konstantin Tamarov, PhD, Emilia Happonen, MSc, and Mikke Varis at Department of Applied Physics at University of Eastern Finland. Please see [Credits](#credits) section for the correct referencing when using the software.

## Requrements

.NET Framework 4.7.1

## Usage

To use the Controlled PTT in your research, either its executables must be [downloaded](#download-executables) from the [latest release](https://github.com/naitsok/controlled-ptt/releases/) or it can be [built from the source](#building-from-the-source-code).

### Download executables

### Building from the source code

### Selecting sensor part

### Selecting laser part



## Detailed description

### Hardware

### Software

### Development

#### Developing a new sensor part

#### Developing a new laser part

## Credits



## Changelog

### v2.0.0
#### Features:
- App. App controls sensor and laser parts. Allows to perform experiments with and without connected laser. Laser power can be controlled to reach specific temperature. Experiment can stop either by time expiration or gained thermal dose.
- Sensor. There are three different sensor parts included. The first two are based on either one or two MLX90614ESF-BCF-000 sensor connected to Arduino compatible board. The third type of sensor part is based on the 16x4 pixel array MLX90621ESF-BAD-000 sensor. For the array sensor a more advanced board with larg memory such as Teensy is needed.
- Laser. Laser part for now is based on the connection to Agilent N5768A or similar. A simple diode laser such as HS-808-1000 infrared handheld laser. The laser must be calibrated beforehand to verify its optical power dependence on the applied current from the power supply.
