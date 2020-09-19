var target = Argument("target", "Default");
var releaseDir = Directory("./release");

Task("InstallBootstrap")
    .Does(() =>
    {
        NuGetInstall("bootstrap.sass", new NuGetInstallSettings {
            OutputDirectory = "theme/assets/lib",
            Version = "4.0.0"
        });
    });

Task("Build")
    .IsDependentOn("InstallBootstrap")
    .Does(() =>
    {
        DotNetCoreRun("./Sedos.csproj");
    });

Task("Preview")
    .IsDependentOn("InstallBootstrap")
    .Does(() =>
    {
        DotNetCoreRun("./Sedos.csproj", "preview");
    });

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);
