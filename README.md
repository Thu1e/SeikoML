# SeikoModLoader
A modloader and rudimentary API for Risk Of Rain 2

---
# Installing
1. Go over to [The Thunderstore](https://thunderstore.io/package/Mattomanx77/SeikoML/) and download the latest version.
2. Extract the contents of the archive in your \Risk of Rain 2\Risk of Rain 2_Data\Managed folder
3. Run the InstallMod.bat file in order to install the modloader
---
# Adding mods
1. Download any _SeikoML compatible_ mods from the [Thunderstore](https://thunderstore.io).
2. Do **not** extract the files
3. Place the zip file as is inside your mods folder located in \Risk of Rain 2\Risk of Rain 2_Data\Managed\mods
---
# Uninstalling the modloader
1. Delete the patched Assebly-CSharp.dll
2. Rename Assembly-CSharp-Vanilla.dll to Assembly-Csharp.dll
---
# Creating mods for SeikoML
Creating mods for SeikoML is as simple process. First thing first, you'll have to create a C# project in your IDE of choice (We recommend Visual Studio).

After you have your project, make sure you add SeikoML.dll and Assembly-Csharp.dll as your dependencies so you can reference them in your code.

Then you can start creating mods by creating a class that inherits from the `ISeikoMod` interface:
```csharp
using System;
using RoR2;
using SeikoML;

namespace MyMod
{
    public class MyCoolMod1 : ISeikoML
    {
        public static void OnStart() //This is inherited from the Interface and is Ran the moment the modloader loads
        {
            Debug.Log("Hello World!"); //Prints a message in the Game's log file!
        }
    }
}
```
This is just the basework, you can head over to the [Example mods](https://github.com/risk-of-thunder/SeikoML/tree/master/ModExample) to see more of how the API works and how you can use it in your own mods!
