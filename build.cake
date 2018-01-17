#tool "nuget:https://api.nuget.org/v3/index.json?package=Wyam"
#addin "nuget:https://api.nuget.org/v3/index.json?package=Cake.Wyam"

var target = Argument("target", "Default");
var releaseDir = Directory("./release");

Task("InstallBootstrap")
    .Does(() =>
    {
        NuGetInstall("bootstrap.sass", new NuGetInstallSettings { Prerelease=true, OutputDirectory="theme/assets/lib" });
    });

Task("Build")
    .IsDependentOn("InstallBootstrap")
    .Does(() =>
    {
        Wyam(new WyamSettings
        {
            UpdatePackages = false
        });
    });

Task("Preview")
    .IsDependentOn("InstallBootstrap")
    .Does(() =>
    {
        Wyam(new WyamSettings
        {
            UpdatePackages = false,
            Preview = true,
            Watch = true
        });
    });

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);
