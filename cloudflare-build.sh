#!/bin/sh
curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 5.0 -InstallDir ./dotnet5
./dotnet5/dotnet --version
./dotnet5/dotnet build /p:RestorePackagesWithLockFile=true
./dotnet5/dotnet run
