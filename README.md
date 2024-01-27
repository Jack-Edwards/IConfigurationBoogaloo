The solitary unit test in this solution fails.  An exception is thrown when assigning to `var myGarden` on line 5 of `Program.cs`.

I can "resolve" the error by renaming "MyGarden" to "GardenSettings" in the `appsettings.Test.json` file, but in that case the actual configuration data is incorrect.  The first row of data appears to be duplicated, while the second _actual_ row of data is not reflected.
