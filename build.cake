var target = Argument("target", "Default");
var releaseDir = Directory("./release");

Task("Build")
    .Does(() =>
    {
        DotNetCoreRun("./Sedos.csproj");
    });

Task("Preview")
    .Does(() =>
    {
        DotNetCoreRun("./Sedos.csproj", "preview");
    });

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);
