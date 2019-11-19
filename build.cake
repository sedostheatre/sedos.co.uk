#tool nuget:?package=Wyam&version=2.2.9
#addin nuget:?package=Cake.Wyam&version=2.2.9

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
        Wyam(new WyamSettings
        {
            UpdatePackages = true,
            UseLocalPackages = true
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
