# DDON_Launcher
A Windows Forms launcher for Dragon's Dogma Online to communicate with the private server account API developed [here](https://github.com/sebastian-heinz/Arrowgene.DragonsDogmaOnline "here"). 

![image](https://github.com/user-attachments/assets/3443c8a3-c355-4e7f-a42b-f57aa64a23ad)

Place the launcher .exe alongside the client's DDO.exe

### Images used:

https://www.steamgriddb.com/hero/103510

https://www.steamgriddb.com/logo/109328

## Development

### Requirements

- Git
- .NET 9
- Visual Studio 2022

### Setting up the development environment

1. Clone the repository
2. Initialize git submodules ```git submodule init --update --recursive ```
3. Compile the required submodules
	- Run `dotnet build --configuration Release` on **./Arrowgene.DragonsDogmaOnline/Arrowgene.Ddon.Cli**
	- Run `dotnet build --configuration Release` on **./Arrowgene.DragonsDogmaOnline/Arrowgene.Ddon.Client**
4. Open the project in Visual Studio

### Building

To build the launcher with everything bundled in a single .exe:

```dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true```

## Extra features

### Translation patch

Download the latest translation and use it to patch the client with one click.

### Mod installer

Patch your game files with the ones in a mod zip file.

#### Creating a mod

Place in a folder the files you want to pack into the game files and create a text file named "manifest.json"

```
    files/
        button_hud_win_00_ID_HQ.tex
        button_win_00_ID_HQ.tex
    manifest.json
```

Edit the manifest.json file and specify in there the name of the mod, its author, and a list of the ARC files that will be patched.

For each arc:
- Specify the path to it, relative to the rom folder (e.g. `ui/gui_cmn.arc`, instead of `nativePC/rom/ui/gui_cmn.arc`)
- Add an action list, indicating what will be done with each file.

The possible actions are:
- `replace`: Copies the contents of the modded file `src` into the game file `dst` that's inside the ARC as is.
```json
{
	"action": "replace",
	"src": "files/button_win_00_ID_HQ.tex",
    "dst": "ui\\00_font\\button_win_00_ID_HQ"
}
```

- `convert`: Copies the contents of the modded file `src` into the game file `dst` inside the ARC, but converts it to the adequate format. Currently the following conversions are supported:
	- `.dds`/`.txt` pair to `.tex`: Converts a DDS texture to a TEX texture using the information of an acompanying TXT file
```json
{
	"action": "convert",
	"src": "files/button_win_00_ID_HQ.dds",
	"txt": "files/button_win_00_ID_HQ.txt",
	"dst": "ui\\00_font\\button_win_00_ID_HQ"
}
```

The paths inside the ARC file MUST use escaped backward slashes (`\\`) and no extension. (e.g. `ui\\00_font\\button_win_00_ID_HQ` instead of `ui/00_font/button_win_00_ID_HQ.tex`)

#### Example manifest

```json
{
	"name": "XBox Button Layout Mod",
	"author": "Genolka",
	"arcs": [
		{
			"arc": "ui/gui_cmn_win.arc",
			"actions": [
				{
					"action": "replace",
					"src": "files/button_win_00_ID_HQ.tex",
					"dst": "ui\\00_font\\button_win_00_ID_HQ"
				}
			]
		},
		{
			"arc": "ui/gui_cmn.arc",
			"actions": [
				{
					"action": "replace",
					"src": "files/button_hud_win_00_ID_HQ.tex",
					"dst": "ui\\00_font\\button_hud_win_00_ID_HQ"
				}
			]
		}
	]
}
```