The solitary unit test in this solution fails.  An exception is thrown when assigning to `var myGarden` on line 5 of `Program.cs`.

I can "resolve" the error by eliminating the settings from the `appsettings.Test.json` file, but in that case the default data fetched from `appsettings.json` is now incorrect.
The first row of data appears to be duplicated while the second row of data from the json file is not reflected.