
# TreeClip

TreeClip is a Windows application that generates a visual layout of a folder and its subfolders/files, copying the layout directly to the clipboard. This makes it easy to share a folder structure in a neatly formatted tree style.

## Features

- 📁 Organizes folder structures with subfolders and files
- 📄 Uses ASCII art for a clean, readable tree layout
- 🔒 Indicates restricted folders with "Access Denied" message
- Directly copies the generated tree layout to the clipboard


## Requirements
- .NET Framework 4.7.2 or higher
- Windows 10 - 11
## Installation / How to use

To install TreeClip as a standalone

1. Download the latest release.
2. Run the provided TreeClipSetup.exe installer.
3. Once installed, you can use TreeClip directly from the context menu by right-clicking on any folder and selecting TreeClip Format.
## Usage

1. After installation, right-click on a folder in Windows Explorer or Desktop.
2. Select TreeClip Format from the context menu.
3. A notification will appear confirming that the folder structure has been copied to the clipboard.
4. Paste it anywhere (e.g., in a text editor) to view the layout.
Example of the output:
```
📁 FolderName
   ├── 📁 Subfolder1
   │   └── 📄 File1.txt
   ├── 📁 Subfolder2
   │   ├── 📄 File2.txt
   │   └── 📄 File3.txt
   └── 📄 File4.txt

```


## Building from Source
TreeClip is designed to work best when integrated with the Windows context menu, allowing you to generate folder layouts directly from Windows Explorer. However, if you’d prefer to compile and run it manually, that option is available as well. The steps below guide you through building the project, with additional instructions for setting up the optional installer to streamline use.
### Prerequisites
1. Install Visual Studio with the .NET Desktop Development workload.
2. Ensure you have the correct version of the .NET SDK installed, compatible with .NET Framework 4.7.2 or higher.
### Compiling
1. Clone the repository:
```bash
git clone https://github.com/Zordux/TreeClip.git
```
2. Open the project in Visual Studio.
3. Build the project:
- Go to Build > Build Solution or press Ctrl + Shift + B
- The TreeClip.exe executable will be generated in the bin/Debug or bin/Release folder.
4. To test the application, run the TreeClip.exe with a folder path as an argument:
```bash
TreeClip.exe "C:\Path\To\Your\Folder"
```
### Creating the Installer
To set up TreeClip with the context menu integration, use the provided Inno Setup script.
1. Install Inno Setup
2. Open the TreeClipInstaller.iss file in Inno Setup.
3. Update the following placeholders:
- <Path_To_Your_LICENSE.txt>: Path to your LICENSE file.
- <Path_To_Your_Output_Directory>: Directory for the output installer (TreeClipSetup.exe).
- <Path_To_Your_Executable>: Path to the compiled TreeClip.exe.
- <Path_To_Your_Icon_File>: Path to TreeClipClear.ico (icon file).
4. Compile the installer by selecting Compile in Inno Setup.
5. The TreeClipSetup.exe file will be generated in the specified output directory.
### Adding to the Windows Context Menu Manually
If you'd like to manually set up the context menu:
1. Open Registry Editor (regedit.exe).
2. Navigate to: 
```mathematica
HKEY_CURRENT_USER\Software\Classes\Directory\shell
```
3. Create a new key named TreeClip Format.
4. Inside TreeClip Format, add the following:
- (Default) (string): Set to "TreeClip Format".
- Icon (string): Set to the path of TreeClipClear.ico.
5. Create a subkey named command.
6. Set the (Default) value under command to:
```
"C:\Path\To\TreeClip.exe" "%1"
```
Replace "C:\Path\To\TreeClip.exe" with the actual path to TreeClip.exe.
### Contributing
Feel free to submit issues or pull requests to improve TreeClip!

### License
This project is licensed under the terms specified in the LICENSE file.

