# trixter-xdream-bike
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
- estimate of the power being applied to the flywheel from a power table of crank speed and resistance to power.
- estimate of expended energy
- is maintainable

The default mode of the utility has a graphic user interface that shows the state of the various controls and a slider bar to set flywheel resistance.
Each brake applies 50% flywheel resistance.

<img src="https://github.com/user-attachments/assets/d33ca02c-bf63-4199-a4d3-a1334d5d861a" align="center" width="550px"  ></a>


The utility also has a console mode to provide a similar experience to the original.
If the utility is invoked with the --console command line option, or through the program menu short cut for the console mode, it shows a console application.

<img src="https://github.com/user-attachments/assets/3b6dfc6f-fbf2-4cc4-956c-261a198fb4f8" align="center" width="750px" ></a>

