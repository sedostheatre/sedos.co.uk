#tool nuget:?package=Wyam
#addin nuget:?package=Cake.Wyam

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
            Verbose = true,
            UseLocalPackages  = true
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
