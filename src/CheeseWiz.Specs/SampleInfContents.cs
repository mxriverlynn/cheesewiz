using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheeseWiz.Specs
{
	public class SampleInfContents
	{

		public static string Sample = 
@"[Version]
Signature=""$Windows NT$""
Provider=""Microsoft""
CESignature=""$Windows CE$""

[CEStrings]
AppName=""CheeseWiz.CFApp.Installer""
InstallDir=%CE1%\%AppName%

[Strings]
Manufacturer=""Microsoft""

[CEDevice]
VersionMin=4.0
VersionMax=6.99
BuildMax=0xE0000000

[DefaultInstall]
CEShortcuts=Shortcuts
AddReg=RegKeys
CopyFiles=Files.Common1,Files.Common2

[SourceDisksNames]
1=,""Common1"",,""C:\Dev\Derick-Github\cheesewiz\src\CheeseWiz.CFApp\obj\Debug\""
2=,""Common2"",,""C:\Dev\Derick-Github\cheesewiz\src\CheeseWiz.CFApp\obj\Debug\es\""

[SourceDisksFiles]
""CheeseWiz.CFApp.exe""=1
""CheeseWiz.CFApp.resources.dll""=2

[DestinationDirs]
Shortcuts=0,%CE2%\Start Menu
Files.Common1=0,""%InstallDir%""
Files.Common2=0,""%InstallDir%\es""

[Files.Common1]
""CheeseWiz.CFApp.exe"",""CheeseWiz.CFApp.exe"",,0

[Files.Common2]
""CheeseWiz.CFApp.resources.dll"",""CheeseWiz.CFApp.resources.dll"",,0


[Shortcuts]

[RegKeys]

";

	}
}
