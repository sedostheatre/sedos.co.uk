var target = Argument("target", "Default");
var releaseDir = Directory("./release");

Task("Build")
    .Does(() =>
    {
        DotNetCoreBuild("./Sedos.csproj", new DotNetCoreBuildSettings{MSBuildSettings=new	DotNetCoreMSBuildSettings().WithProperty("RestorePackagesWithLockFile", "true")});
        DotNetCoreRun("./Sedos.csproj");
    });

Task("Preview")
    .Does(() =>
    {
        DotNetCoreBuild("./Sedos.csproj", new DotNetCoreBuildSettings{MSBuildSettings=new	DotNetCoreMSBuildSettings().WithProperty("RestorePackagesWithLockFile", "true")});
        DotNetCoreRun("./Sedos.csproj", "preview");
    });

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);
