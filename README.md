# Prerequisites

This tool requires you to install [loopMIDI](https://www.tobias-erichsen.de/software/loopmidi.html) for creating a virtual MIDI device. You do not need to set loopMIDI to automatically start.

# Installation

1. Copy the release to anywhere you like.
2. Run the program for the first time.
3. Select your LPD8 device, or device with similar issue
4. Press Enable

# Usage

* Run the program before Voicemeeter.
* Select `Virtual LPD8VMCL` as MIDI device in Voicemeeter and MacroButtons
* Enjoy!

# What does this do?

If you have an LPD8 MIDI controller and want to use it with Voicemeeter Macro Buttons you will probably have noticed that you can control the pad LEDs from Macro Buttons. However when you use a 2 Positions button type and set the pad LEDs to reflect the state of the button there is a tiny problem. When you press and release a pad on the LPD8 it will itself trigger the LED to go on and off, meaning once you release the pad, it will overwrite whatever Macro Buttons has set. Also, if you do manage to set the LED from Macro Buttons, switching programs will erase the LED state again.

This tiny tool will create a virtual MIDI device that sits between the LPD8 and VoiceMeeter and replays all note on and note off messages it received from Macro Buttons to the LPD8 every 50ms. So releasing the pad will turn the LED off, but if Macro Buttons has sent a note on MIDI message to turn the LED on, it will turn on within 50ms. Also after switching programs.

Now your LPD8 can show the correct button state of Macro Buttons! Yay!