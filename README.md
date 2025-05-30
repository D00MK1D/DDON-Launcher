# DDON_Launcher
A Windows Forms launcher for Dragon's Dogma Online to communicate with the private server account API developed [here](https://github.com/sebastian-heinz/Arrowgene.DragonsDogmaOnline "here"). 

![image](https://github.com/user-attachments/assets/a893f61d-2afa-495a-b009-6f257b4aa4ab)


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
2. Initialize git submodules ``` git submodule update --init --recursive ```
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
- or leave it null to indicate this block is about actions that affect files not contained in arc files.
- Add an action list, indicating what will be done with each file.

The possible actions are:
- `replace`: Copies the contents of the modded file `src` into the game file `dst` as is.
```json
{
	"action": "replace",
	"src": "files/button_win_00_ID_HQ.tex",
    "dst": "ui\\00_font\\button_win_00_ID_HQ.tex",
	"create": true // Optional. False by default. Creates the file if it doesn't exist
}
```

- `convert`: Copies the contents of the modded file `src` into the game file `dst`, but converts it to the adequate format. Currently the following conversions are supported:
	- `.dds`/`.txt` pair to `.tex`: Converts a DDS texture to a TEX texture using the information of an acompanying TXT file
```json
{
	"action": "convert",
	"src": "files/button_win_00_ID_HQ.dds",
	"txt": "files/button_win_00_ID_HQ.txt",
	"dst": "ui\\00_font\\button_win_00_ID_HQ.tex",
	"create": true // Optional. False by default. Creates the file if it doesn't exist
}
```

- `packGmd`: Patches GMD files with the texts in the provided file. This action can only be used in a block where `arc` is null, as the target arc files are specified inside the CSV file.
```json
{
	"action": "packGmd",
	"gmd": "gmd.csv",
	"romLang": "English" // Optional. English by default. At the moment can only be English or Japanese, chooses which language column to use.
}
```

The paths inside the ARC file MUST use escaped backward slashes (`\\`). Extension is optional but **recommended**, it might be required to disambiguate files that have the same basename. (e.g. `ui\\00_font\\button_win_00_ID_HQ.tex` instead of `ui/00_font/button_win_00_ID_HQ`)
If arc is null, the paths can be either backward or forward slashes. The paths are relative to nativePC.

#### Example manifest

```json
{
	"name": "XBox Button Layout Mod",
	"author": "Genolka",
	"arcs": [
		{
			"arc": null,
			"actions": [
				{
					"action": "replace",
					"src": "bgm_s_001.sngw",
					"dst": "sound/stream/bgm/bgm_system/wave/bgm_s_001.sngw"
				},
				{
					"action": "packGmd",
					"gmd": "gmd.csv"
				}
			]
		},
		{
			"arc": "ui/gui_cmn_win.arc",
			"actions": [
				{
					"action": "replace",
					"src": "files/button_win_00_ID_HQ.tex",
					"dst": "ui\\00_font\\button_win_00_ID_HQ.tex"
				}
			]
		},
		{
			"arc": "ui/gui_cmn.arc",
			"actions": [
				{
					"action": "convert",
					"src": "files/button_hud_win_00_ID_HQ.dds",
					"txt": "files/button_hud_win_00_ID_HQ.txt",
					"dst": "ui\\00_font\\button_hud_win_00_ID_HQ.241F5DEB"
				}
			]
		}
	]
}
```
