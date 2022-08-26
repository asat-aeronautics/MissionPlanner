1.	Install 4.6.1 .NET Framework 
	After loading solution on visual studio go to Project (on the menu bar), properties  and change the framework to 4.6.1.
 	/ or right click #MissionPlanner -> Properties etc

2.	If there is an error NU1105 (or smth) about windows forms4x: 
	>>>>>dotnet restore MissionPlanner.sln 
	on vs's command line

3.	If there is a message on vs that suggests installing extra packages then do so

4.	There may be a message asking you to turn on developer mode on your computer (do so)

5.	Build MissionPlanner

6.	Built PSUSS seperately by right clicking on its folder and selecting Build ( the folder will be in the Plugins folder outside #MissionPlanner 

7.	Go to PSUSS folder on file explorer -> obj -> PSUSS.dll copy and paste the last file in the plugins folder of the executable app
