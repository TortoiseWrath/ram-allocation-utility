# OBSOLETE

The functionality afforded by this utility is now provided by the standard Minecraft launcher. Use that instead. This project has seen no development since July 2012 and is archived here for historical purposes. A version of the final version of the [Minecraft Forum post](https://www.minecraftforum.net/forums/mapping-and-modding-java-edition/minecraft-tools/1263912-launcher-ram-allocation-utility) is reproduced below with updated links. Past versions of the source code and this documentation are committed and available in this repository.

## License

```
RAM Allocation Utility for Minecraft 1.2/1.3
Copyright (C) 2012  Sean Gillen

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
```

## Original readme

I've seen some articles detailing how to launch Minecraft with more than the default 128-512 MB of RAM allocated to it to improve performance; doing this greatly improved the performance for me.

Noticing that it was tedious to determine how much memory I wanted to use for Minecraft and entering the appropriate command at the command line every time I wanted to launch Minecraft, as well as feeling that existing launchers with a RAM allocation feature seemed a bit involved for such a simple purpose as this, I decided to develop an application that would allow me to perform this process with minimal user input.

**NOTE September 28, 2012:**  
Development here has effectively ground to a halt; as such, I've released the utility under the GPL. If anyone has ideas as to the cause of the problem, or can provide me detailed information about their computer, please let me know, either by replying to this thread or emailing me from my website.

As I said, this has worked fine for me in all of the testcases I've had a chance to put together, so if the utility is something in which you'd be interested, it's still definitely worth a try to use it on your system.

My primary system, on which this works perfectly and consistently, is a Core i5 build with 8GB RAM, Minecraft 1.3.2, 64-bit Windows 7, Java 7, and .NET Framework 6 (or whatever the one that was released in 2008 was). I have tried this on a Core i7 8GB laptop with roughly the same software, and it worked there as well. However, I haven't had a chance to try and get this running on any VMs or other PCs, so I am working with a very limited sample set.

Just in case I do get a chance to put some more time into this, again, please send me any information you can about your computer, your setup, and whether or not this works. Positive samples are still samples nonetheless.

VB.NET 2008 source [here](https://github.com/TortoiseWrath/ram-allocation-utility).

**NOTE August 22, 2012:**  
~~Two~~ Three people have reported an "unable to access jarfile" bug; I have tested this WFM with 1.3.2 on W7 x64. I will investigatee this further in the near future.

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
**PLEASE READ NOTE ABOVE (September 28)**  
All versions can be downloaded from [the releases page](https://github.com/TortoiseWrath/ram-allocation-utility/tags).

## Changelog
```
v1.2 July 5, 2012
	 Fixed shortcut creation.
v1.1 July 4, 2012
	 Fixed typo.
	 Zipped executable to avoid false-positives by heuristic scanners.
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

## Plans for future releases

* Add an "advanced view" allowing users to adjust heap size manually.
* Allow users to allocate percentages of RAM to Minecraft and create shortcuts to these percentages.
* Create a configuration file or registry entry, allowing users to locate their Minecraft and Java executables manually (if need be).
* Use system paths so that it won't break on non-English versions of Windows.
* Add localizations.
* Add proper icons.
* Add an installer.
* Create a 'lite' version with less features to consume less disk space (because 70 KB is clearly too much)
* Improve error handling.
* Convert code to C# or C++ to improve the launcher's memory usage.
* Improve appearance.
* Create versions for any other platforms on which it is necessary, except OS X.

## Screenshots

The launcher:  
![Screenshot of Minecraft 1.2.5 being launched with 3GB RAM via RAM Allocation Utility v1.1 on Windows 7 x64.](/docs/on.png)

Shortcuts:  
![](/docs/oo.png)

Debug switch:  
![](/docs/op.png)