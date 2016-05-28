## Launcher

Description...    

## [Packaging][3]

Packaging involves the process of building, packing, and preparing release files for distribution.

* Open Launcher.sln solution in Visual Studio 
* Update the assembly version in Project Settings (not sure if necessary)
* Build Launcher solution
* Download and Install [NuGetPackageExplorer][1]
* Update Troposphir-1.1.0.nupkg file as follows:
	1. Replace Launcher.exe with the newest version (if applicable)
	2. Add or remove any new game files 
	3. Edit metadata by updating the version number of the package (e.g. 1.1.0 to 1.2.0)
	4. Click on File > Save as ... (e.g. Troposphir-1.2.0.nupkg)
* Use the Package Manager Console to execute ` Squirrel.exe --releasify ` command
``` PM> Squirrel --releasify Troposphir.1.2.0.nupkg ```

## Distribution

Distribution involves the process of distributing installation files or patch updates to the users.

* Upload the following patch updates to the website's FTP server
	1. ./Releases/*.nupkg
	2. ./Releases/RELEASES
* Upload the following installation files to the website's FTP server
	1. Setup.exe
	
 [1]: https://github.com/NuGetPackageExplorer/NuGetPackageExplorer
 [2]: https://docs.nuget.org/consume/package-manager-console
 [3]: https://github.com/Squirrel/Squirrel.Windows/blob/master/docs/getting-started/2-packaging.md