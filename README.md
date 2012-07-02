# RAM Allocation Utility
I've seen some articles detailing how to launch Minecraft with more than the default 128-512 MB of RAM allocated to it to improve performance; doing this greatly improved the performance for me.

Noticing that it was tedious to determine how much memory I wanted to use for Minecraft and entering the appropriate command at the command line every time I wanted to launch Minecraft, as well as feeling that existing launchers with a RAM allocation feature seemed a bit involved for such a simple purpose as this, I decided to develop an application that would allow me to perform this process with minimal user input.

This is still in the very early stages of development, but it works well enough for me that I thought I should publish it in case anybody wants it.

The utility can be used by opening the file in Notepad, editing the location for the Minecraft executable on the second line (it defaults to C:\Minecraft.exe), and saving it to the location where you want the Minecraft icon.

~~Tested with Minecraft 1.2.5 on Windows 7 64-bit; as far as I know, it should work with all Minecraft versions on Windows XP+.~~

**UPDATE 1 July 2012:**  
This has been tested with Minecraft 1.2.5; as far as I know, it should work with all versions of Minecraft.  
This works fine on Windows 7 (though I've only tested it on 64-bit Windows 7, it should work with 32-bit as well).

To use this on Windows XP, the XP must be 32-bit and updated to SP3, and the [KB968930 patch](http://www.microsoft.com/en-us/download/details.aspx?id=16818) must be installed.

I haven't tested this on Vista yet; if the launcher flashes on the screen and does not ask for user input (as described by [MicroGames18](https://www.minecraftforum.net/comments/23154672)), Vista SP1 or SP2 and the aforementioned patch must be installed; the patch can be downloaded [here](http://www.microsoft.com/en-us/download/details.aspx?id=9864) (for 32-bit Vista) or [here](http://www.microsoft.com/en-us/download/details.aspx?id=9239) (for 64-bit Vista).

It will probably work in Windows 8 upon release; I'll do further testing to see how it behaves on Vista and W8.

## Screenshots

![Screenshot of RAM Allocation Utility v0.1 running on Windows 7 64-bit](/docs/o6.png) ![Screenshot of Minecraft 1.2.5 having been launched via RAM Allocation Utility v0.1 on Windows 7 64-bit](/docs/o7.png)

Launching Minecraft with 5GB of RAM (launching with >4GB requires 64-bit Windows and Java):
![Screenshot of RAM Allocation Utility v0.1 running on Windows 7 64-bit](/docs/oi.png) ![Screenshot of Minecraft 1.2.5 having been launched with 5GB RAM via RAM Allocation Utility v0.1 on Windows 7 64-bit.](/docs/oj.png)

Running on Windows XP after installing patch: ![Screenshot of RAM Allocation Utility v0.1 running on Windows XP](/docs/oh.png)

If you receive this error installing the patch on Windows XP, [this update](http://www.microsoft.com/en-us/download/details.aspx?id=16614) needs also be installed.  
![Error message when installing update KB968930 on Windows XP SP3](/docs/og.png)