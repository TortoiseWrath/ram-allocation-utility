
Imports IWshRuntimeLibrary
Public Class Form1

    'Changelog:
    '0.1 - June 22, 2012
    'Initial release

    '1.0 - July 4, 2012
    'Coded in VB.NET now
    'Added GUI
    'Added slider
    'Added shortcut creation

    'Things to implement in a future release:
    'Advanced view with precise values and -Xms setting
    'Better appearance
    'Reconfiguration
    'Save configuration data, user locatable executables
    'Internationalize - non-hard-coded drive letters, program files, system32, etc, localizations
    'Icons, installer, etc.
    'Lite version with minimal features
    'Add error for shortcut trying to launch with more than available RAM
    'Convert to C#/C++

    Dim snapTo As UShort
    Dim MBRAM As UInteger = 0

    Private Function Launch_Minecraft(ByVal minram As ULong, ByVal maxram As ULong)
        Dim javapath As String = ""
        Dim minecraft As String = ""
        Dim startupPath As String = Application.StartupPath

        'Locate Java.
        If System.IO.File.Exists("C:\Windows\System32\javaw.exe") Then
            javapath = "C:\Windows\System32\javaw.exe"
        ElseIf System.IO.File.Exists("C:\Program Files\Java\jre7\javaw.exe") Then
            javapath = "C:\Program Files\Java\jre7\javaw.exe"
        ElseIf System.IO.File.Exists("C:\Program Files\Java\jre6\javaw.exe") Then
            javapath = "C:\Program Files\Java\jre6\javaw.exe"
        ElseIf System.IO.File.Exists("C:\Windows\System32\java.exe") Then
            javapath = "C:\Windows\System32\java.exe"
        ElseIf System.IO.File.Exists("C:\Program Files\Java\jre7\java.exe") Then
            javapath = "C:\Program Files\Java\jre7\java.exe"
        ElseIf System.IO.File.Exists("C:\Program Files\Java\jre6\java.exe") Then
            javapath = "C:\Program Files\Java\jre6\java.exe"
        Else
            javapath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Runtime Environment", "CurrentVersion", "")
            If javapath = "" Then
                MsgBox("Java runtime not found!" + vbNewLine + "Terminating launcher.")
                Me.Close()
            End If
            javapath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Runtime Environment\" + javapath, "JavaHome", "")
            If javapath = "" Then
                MsgBox("Java runtime not found!" + vbNewLine + "Terminating launcher.")
                Me.Close()
            ElseIf System.IO.File.Exists(javapath + "\bin\javaw.exe") Then
                javapath = javapath + "\javaw.exe"
            ElseIf System.IO.File.Exists(javapath + "\bin\java.exe") Then
                javapath = javapath + "\java.exe"
            Else
                MsgBox("Java runtime not found!" + vbNewLine + "Terminating launcher.")
                Me.Close()
            End If
        End If

        'Locate Minecraft.
        'minecraft.exe must be placed in My Documents\ (doesn't currently work???)
        'or C:\
        'or same directory as this utility (does that one work?)
        'if the last works, only on XP SP3/SP2 x64, Vista SP1+, W7
        If System.IO.File.Exists("%USERPROFILE%\Documents\minecraft.exe") Then
            minecraft = "%USERPROFILE%\Documents\minecraft.exe"
        ElseIf System.IO.File.Exists("%USERPROFILE%\My Documents\minecraft.exe") Then
            minecraft = "%USERPROFILE%\My Documents\minecraft.exe"
        ElseIf System.IO.File.Exists("C:\minecraft.exe") Then
            minecraft = "C:\minecraft.exe"
        ElseIf System.IO.File.Exists(startupPath + "\minecraft.exe") Then
            minecraft = startupPath + "\minecraft.exe"
        End If

        'Launch Minecraft.
        Dim launchCommand As New ProcessStartInfo
        launchCommand.FileName = javapath
        'launchCommand.Arguments = "-Xms64m -Xmx" + Convert.ToString(Me.TrackBar1.Value * snapTo * 1024 * 1024) + " -jar """ + minecraft + """"
        launchCommand.Arguments = "-Xms" + Convert.ToString(minram) + " -Xmx" + Convert.ToString(maxram) + " -jar """ + minecraft + """"
        Dim process As Process = System.Diagnostics.Process.Start(launchCommand)
        Me.Close()

        Launch_Minecraft = "blarg"
    End Function

    Private Sub Dialog_Loaded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Command-line arguments:
        '/rf123 = start with 123 bytes of RAM
        '/rp97 = start with 97% of available RAM
        '/d123 = emulate 123 bytes available RAM

        'Get command-line argument.
        Dim input As String = ""
        Dim debugRAM As String = ""
        For Each s As String In My.Application.CommandLineArgs
            If s.ToLower.StartsWith("/r") Then
                input = s.Remove(0, 2)
            End If
            If s.ToLower.StartsWith("/d") Then
                debugRAM = s.Remove(0, 2)
            End If
        Next

        'Interpret command-line argument.
        Dim inputType As String = ""
        Dim inputValuet As String = ""
        Dim inputValue As Double = 0
        If input = "" Then
            inputType = "n"
        Else
            inputType = input.Remove(1, input.Length - 1)
            inputValuet = input.Remove(0, 1)
            inputValue = Convert.ToDouble(inputValuet)
        End If

        'Find free RAM.
        Dim freeRAM As Double
        If debugRAM = "" Then
            freeRAM = My.Computer.Info.AvailablePhysicalMemory
        Else
            freeRAM = Convert.ToDouble(debugRAM)
        End If

        'If less than 1GB free RAM, find maximum and default value for slider
        MBRAM = Math.Floor(freeRAM / 1048576)
        If MBRAM < 1024 Then
            'Dim i As Byte
            'Dim maxRAM As UInteger = 0
            'For i = 0 To 7
            'If ltGB(i) < freeRAM Then
            'maxRAM = ltGB(i)
            'End If
            ' Next

            ' If maxRAM = 0 Then
            If MBRAM < 64 Then
                'If less than 64MB free RAM, fail
                MsgBox("Free RAM is only " + Convert.ToString(MBRAM) + " MiB." + vbNewLine + "64 MiB free RAM is required to run the JVM." + vbNewLine + "Terminating launcher.", 0, "Error")
                Me.Close()
            Else
                'If 64MB-1GB free RAM, update slider
                Me.TrackBar1.Maximum = Math.Floor(MBRAM / 64)
                snapTo = 64
                Me.TrackBar1.Value = Me.TrackBar1.Maximum
                Me.Label1.Text = "Available RAM: " + Convert.ToString(Me.TrackBar1.Maximum * 64) + " MiB"
            End If
        ElseIf MBRAM < 4096 Then
            'If 1GB-4GB free RAM, update slider
            Me.TrackBar1.Maximum = Math.Floor(MBRAM / 512)
            snapTo = 512
            Me.TrackBar1.Value = 2
            Me.Label1.Text = "Available RAM: " + Convert.ToString(Me.TrackBar1.Maximum / 2) + "GiB"
        Else
            'If >4GB free RAM, update slider
            Me.TrackBar1.Maximum = Math.Floor(MBRAM / 1024)
            snapTo = 1024
            Me.TrackBar1.Value = 1
            Me.Label1.Text = "Available RAM: " + Convert.ToString(Me.TrackBar1.Maximum) + "GiB"
        End If
        Me.TextBox1.Text = Me.TrackBar1.Value * snapTo
        Me.TextBox3.Text = Math.Round(Me.TextBox1.Text / (Me.TrackBar1.Maximum * snapTo) * 100)
        If Me.TextBox1.Text >= 1024 Then
            Me.TextBox1.Text = Me.TextBox1.Text / 1024
            Me.TextBox1.Text = Me.TextBox1.Text + " GiB"
        Else
            Me.TextBox1.Text = Me.TextBox1.Text + " MiB"
        End If

        'Launch Minecraft if command-line switch was passed.
        If inputType = "f" Then
            Launch_Minecraft(inputValue, inputValue)
        End If

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim trackbar_value As ULong = Me.TrackBar1.Value
        Dim selectedRAM As ULong = trackbar_value * snapTo * 1024 * 1024
        Launch_Minecraft(selectedRAM, selectedRAM)
    End Sub

    Private Sub Slider_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        Me.TextBox1.Text = Me.TrackBar1.Value * snapTo
        If Me.TextBox3.Enabled = False Then
            Me.TextBox3.Text = Math.Round(Me.TextBox1.Text / (Me.TrackBar1.Maximum * snapTo) * 100)
        End If
        If Me.TextBox1.Text >= 1024 Then
            Me.TextBox1.Text = Me.TextBox1.Text / 1024
            Me.TextBox1.Text = Me.TextBox1.Text + " GiB"
        Else
            Me.TextBox1.Text = Me.TextBox1.Text + " MiB"
        End If
    End Sub

    Private Sub Percentage_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.KeyPress
        If Me.TrackBar1.Enabled = False Then
            If Me.TextBox3.Text = "" Then
            Else
                Me.TrackBar1.Value = Math.Max(Math.Round(Me.TextBox3.Text / snapTo), 1)
            End If
        End If
    End Sub

    Private Sub Switch_Mode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            'Do something if mode was switched to slider
            Me.TrackBar1.Enabled = True
            Me.TextBox3.Enabled = False
        Else
            'Do something if mode was switched to percentage
            MsgBox("Eh... maybe in the next version.")
            RadioButton1.Checked = True
            'Me.TrackBar1.Enabled = False
            'Me.TextBox3.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Create desktop shortcut.
        Dim WshShell As WshShell = New WshShell
        Dim shortcut As IWshRuntimeLibrary.IWshShortcut
        Dim desktopfolder As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        shortcut = CType(WshShell.CreateShortcut(desktopfolder + "\Launch Minecraft with " + Convert.ToString(TrackBar1.Value * snapTo) + " MiB RAM.lnk"), IWshRuntimeLibrary.IWshShortcut)
        'shortcut = CType(WshShell.CreateShortcut(desktopfolder + "\Launch.lnk"), IWshRuntimeLibrary.IWshShortcut)
        shortcut.TargetPath = Application.ExecutablePath
        Dim trackbar_value As ULong = Me.TrackBar1.Value
        shortcut.Arguments = "-rf" + Convert.ToString(trackbar_value * snapTo * 1024 * 1024)
        shortcut.Save()
        MsgBox("Shortcut saved to desktop.")
    End Sub
End Class
