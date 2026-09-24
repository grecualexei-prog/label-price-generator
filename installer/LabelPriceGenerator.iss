; ------------------------------------------------------------
; Label Price Generator - Business Installer
; Windows x64 installer generated with Inno Setup
; ------------------------------------------------------------

#define MyAppName "Label Price Generator"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Business Label Studio"
#define MyAppURL "https://github.com/grecualexei-prog/label-price-generator"
#define MyAppExeName "LabelPriceGenerator.exe"
#define PublishDir "..\src\LabelPriceGenerator\bin\Release\net8.0-windows\win-x64\publish"

; Optional branding files - add these files in installer folder if you want logo and custom branding.
; #define MyCompanyLogo "company-logo.bmp"
; #define MyCompanyIcon "company-icon.ico"

[Setup]
AppId={{5F4A72C2-314D-4DE4-BE9A-39AB320F1AA3}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename=LabelPriceGenerator-Business-x64
OutputDir=.
Compression=lzma2
SolidCompression=yes
PrivilegesRequired=admin
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x64
CreateAppDir=yes
UsePreviousAppDir=no
UsePreviousGroup=no
UninstallDisplayIcon={app}\{#MyAppExeName}
WizardStyle=modern
ShowLanguageDialog=yes
ShowComponentTree=yes
AlwaysShowDirOnReadyPage=yes
AlwaysShowGroupOnReadyPage=yes
AppCopyright=Copyright (c) 2026
LicenseFile=..

; Branding placeholders (uncomment and add the files to enable them)
; WizardImageFile={#MyCompanyLogo}
; WizardSmallImageFile={#MyCompanyLogo}
; SetupIconFile={#MyCompanyIcon}

[Languages]
Name: "romana"; MessagesFile: "compiler:Languages\Romanian.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "{#PublishDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{#MyAppName} (Dezinstaleaza)"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Deschide Label Price Generator"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}"

[Messages]
WelcomeLabel1=Instalare {#MyAppName}
WelcomeLabel2=Acest program va instala {#MyAppName} pe computerul dumneavoastra.

; ------------------------------------------------------------
; Notes:
; - Run a Windows publish before compiling:
;   dotnet publish src\LabelPriceGenerator\LabelPriceGenerator.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:UseAppHost=true
; - Put your company logo into installer folder and uncomment the branding lines above.
; - If you want a product-specific installer name, replace Business Label Studio with your company name.
; ------------------------------------------------------------
