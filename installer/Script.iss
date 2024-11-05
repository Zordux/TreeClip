#define MyAppName "TreeClip"
#define MyAppVersion "1.0"
#define MyAppPublisher "Zordux's, GitHub"
#define MyAppURL "https://github.com/Zordux"
#define MyAppExeName "TreeClip.exe"

[Setup]
AppId={{7C98BEE3-4188-42FC-B19E-1F15C9CA3D2C}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={userappdata}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=<Path_To_Your_LICENSE.txt>  ; Replace with the actual path to your LICENSE file
PrivilegesRequired=lowest
OutputDir=<Path_To_Your_Output_Directory> ; Replace with your desired output directory
OutputBaseFilename=TreeClipSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
SetupIconFile=<Path_To_Your_Icon_File> ; Replace with the path to TreeClipClear.ico

[Files]
Source: "<Path_To_Your_Executable>\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion ; Replace with the path to your executable
Source: "<Path_To_Your_Icon_File>\TreeClipClear.ico"; DestDir: "{app}"; Flags: ignoreversion ; Replace with the path to TreeClipClear.ico

[Registry]
Root: HKCU; Subkey: "Software\Classes\Directory\shell\TreeClip Format"; ValueType: string; ValueName: ""; ValueData: "TreeClip Format"; Flags: uninsdeletekeyifempty
Root: HKCU; Subkey: "Software\Classes\Directory\shell\TreeClip Format"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\TreeClipClear.ico"; Flags: uninsdeletevalue
Root: HKCU; Subkey: "Software\Classes\Directory\shell\TreeClip Format\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""; Flags: uninsdeletekeyifempty

[Icons]
Name: "{userprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFileName: "{app}\TreeClipClear.ico"
