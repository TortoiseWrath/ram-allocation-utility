# RAM Allocation Utility
I've seen some articles detailing how to launch Minecraft with more than the default 128-512 MB of RAM allocated to it to improve performance; doing this greatly improved the performance for me.

Noticing that it was tedious to determine how much memory I wanted to use for Minecraft and entering the appropriate command at the command line every time I wanted to launch Minecraft, as well as feeling that existing launchers with a RAM allocation feature seemed a bit involved for such a simple purpose as this, I decided to develop an application that would allow me to perform this process with minimal user input.

**UPDATE July 4, 2012:**  
**v1.0 has been released!**  
Everything is very different now.  
Thanks to ChrisPerson for providing some of the code used in the detection of the Java location. Check out his RAM Expansion Tool over at [PlanetMinecraft](http://www.planetminecraft.com/mod/ram-expansion-tool/).

The interface is pretty intuitive, and I don't think it requires too much explanation here.  
This has been tested on 64-bit Windows 7 with Minecraft 1.2.5 and 1.3.2. Further testing is planned.

## Command-line options and shortcuts
(added in v1.0)  
A shortcut can be created on the desktop (this can be renamed or moved without breaking anything) to launch Minecraft with a certain amount of RAM.

For example, you can create a shortcut to launch Minecraft with 1GB of RAM.

The command-line switches are:  
* /rf*nnn* - start Minecraft with *nnn* **bytes** of RAM (1 MiB = 1048576 bytes)
* /d*nnn* - launch the launcher, emulating *nnn* free **bytes** of RAM (for debugging purposes)

## Installation
*Should* be compatible with Windows XP and above.  
Extract the executable from the ZIP file, and place it in the same folder as your minecraft.exe.  
Alternatively, place it in whatever folder you like, and place minecraft.exe in the root of your C: drive.  
Rename it to whatever you like.  
Renaming or moving the executable will break any shortcuts you have created with it.

## Download
All versions can be downloaded from [the releases page](https://github.com/TortoiseWrath/ram-allocation-utility/tags).

## Changelog
```
v1.0 July 4, 2012
	 Rewrote program in VB.NET
	 Added GUI.
	 Granularized heap size options below 4 gibibytes available physical memory.
	 Added command-line switches.
	 Added shortcut creation feature.
	 Better Minecraft and Java location algorithm.
	 Fixed compatibility with Windows XP/Vista.
v0.1 June 22, 2012
	 Initial release.
```

## Screenshots

The launcher:  
![Screenshot of Minecraft 1.2.5 being launched with 3GB RAM via RAM Allocation Utility v1.0 on Windows 7 x64.](/docs/on.png)

Shortcuts:  
![](/docs/oo.png)

Debug switch:  
![](/docs/op.png)