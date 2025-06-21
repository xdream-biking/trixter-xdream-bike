# trixter-xdream-bike

_This page refers to the state of this repo's product in this development branch. It has not been released yet._

An API and diagnostic utility for interaction with a Trixter X-Dream V1 Exercise Bike for use on modern PCs, not the original Trixter ones.

<img src="https://github.com/user-attachments/assets/fa2f2039-3b30-40ff-b4bc-5f4e064b09eb" align="center" width="512" />

Also, a [discussion forum](https://github.com/xdream-biking/trixter-xdream-bike/discussions) and [wiki](https://github.com/xdream-biking/trixter-xdream-bike/wiki) for the X-Dream Mountain Biking software supplied with that bike.
It is not necessary to use the diagnostic utility from this repository to utilise the advice in the discussions or wiki.

---

The "Trixter" company or companies that made this bike and the X-Dream mountain biking simulator are now dissolved.  
This repository and the associated discussions / wikis are not associated with these companies or any that acquired them.

---

The source code in this repository is intended to provide developers with an API to interact with this bike, and some diagnostic tools to demonstrate its use, and to provide a better alternative to the equivalent utilities provided with the original X-Dream software.

Help with the X-Dream mountain biking simulation software itself can be found in the Discussions.

# Trixer.XDream.API

A .NET Standard 2.0 client API which provides classes to:
- read status from and send resistance to a Trixter V1 X-Dream Bike.
- emulate a Trixter V1 X-Dream Bike.

# Trixter.XDream.Diagnostics

A replacement for the console and UI test applications that were supplied with the X-Dream software.

So far the improvements over the originals are:
- console and GUI options in a single application
- detects the COM port the bike is on
- detects backpedalling and shows the crank RPM in the backwards direction
- calculates flywheel and crank cumulative revolutions.
- estimates of the power being applied to the flywheel
- estimated energy expended by rider
- shows an animated graph of crank positions covered to indicate sensor problems
- captures incoming telemetry from the bike and saves to .csv
- is maintainable

## Details Tab

The utility has a graphic user interface that shows the state of the various controls and a slider bar to set flywheel resistance.
Each brake applies 50% flywheel resistance.

![image](https://github.com/user-attachments/assets/ef9ad901-cbdc-49e5-85c2-0d8c1befb8f7)

## Crank Tab

The Crank tab shows information about activation from the crank position sensor, to show if graphically if there is a problem with the crank sensor. 
This could also be done by turning the crank very slowly and watching the crank position number on the Diagnostics tab or the test utility supplied with the X-Dream software.

https://github.com/user-attachments/assets/91aed2b2-9df8-48e2-b423-215dfc9cc127

## Driver Tab

This tab provides an opinion on the state of the bike's driver.

## Data capture

Incoming data from the bike can be captured and eventually saved as a .csv file.












