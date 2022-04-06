cd ..
del /S "gitinclude"
del /S "gitinclude.exe"
del /S "ConsoleApp"
del /S "ConsoleApp.exe"

dotnet publish -p:PublishProfile="win-x64-self-contained"
dotnet publish -p:PublishProfile="win-x64-small-without-dotnet-runtime"

forfiles /S /M ConsoleApp.exe /C "cmd /c rename @file gitinclude.exe"

dotnet publish -p:PublishProfile="linux-x64-self-contained"
dotnet publish -p:PublishProfile="linux-x64-small-without-dotnet-runtime"
dotnet publish -p:PublishProfile="osx-x64-self-contained"
dotnet publish -p:PublishProfile="osx-x64-small-without-dotnet-runtime"

forfiles /S /M ConsoleApp /C "cmd /c rename @file gitinclude"

@pause
