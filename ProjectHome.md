![http://dl.dropbox.com/u/10970475/Projects/SettingsEditor/screenshot1.png](http://dl.dropbox.com/u/10970475/Projects/SettingsEditor/screenshot1.png) ![http://dl.dropbox.com/u/10970475/Projects/SettingsEditor/screenshot2.png](http://dl.dropbox.com/u/10970475/Projects/SettingsEditor/screenshot2.png)

# **Settings Editor** opens INI files into a pretty tab-based view for editing. #
Used for:
  1. Windows developers who need to give users a nice looking GUI for editing INI files without any work at all.
  1. People who often edit INI files and want a graphical view.
### [Download Now](http://code.google.com/p/ini-settings-editor/downloads/list) ###
See the [Wiki](http://code.google.com/p/ini-settings-editor/w/list) for documentation.
## Project Goals & Features ##
  * Require no work at all from the developer. Download the binaries and open any INI file with it. To integrate it into your program, just execute "INIEditor.exe file.ini" and that's it.
  * Automatically "Humanize" any settings names. Example: In the editor, the setting called myValue becomes "My Value".
  * Let the developer make things more fancy if she/he wants with no coding: Just embed options into the INI itself. For example, to add an icon and dropdown options to a section to make it prettier, just add the following line into the INI file under the section you want:
```
[Sample Section]
GROUP_ICON=icons\scheduler.ico
DayOfWeekForScheduler=Monday
DayOfWeekForScheduler_OPTION=Monday
DayOfWeekForScheduler_OPTION=Tuesday
DayOfWeekForScheduler_OPTION=Wednesday
```
## Why Settings Editor? ##
  * Every time I program a small tool for internal corporate use, or for public distribution, I keep needing to make a good settings editor. This actually takes quite a lot of time, just to lay it out and make it look right. So, I made a settings editor that is external and very intelligent: It works with any Windows INI file and automatically builds a settings editor.
  * At the end of the day, there's no good Windows INI editor out there... As much as MS wants us to use the registry, there are so many reasons why this is a bad idea, especially for smaller applications with a few settings. The most popular Windows tools still use INI files, like Fire Fox, Irfanview and 7-Zip, just to name a few.