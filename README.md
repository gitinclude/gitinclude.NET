# gitinclude.NET

## Why?

I started this as a nice little puzzle in response to a StackOverflow question, where the problem was to provide an easy and offline way to create a pattern like this (let's call it *soluiton 1*):
```
StrategicProject/*
!StrategicProject/SpecificProject1/
StrategicProject/SpecificProject1/*
!StrategicProject/SpecificProject1/Method1/
StrategicProject/SpecificProject1/Method1/*
!StrategicProject/SpecificProject1/Method1/doc/
StrategicProject/SpecificProject1/Method1/doc/*
!StrategicProject/SpecificProject1/Method1/doc/*.tex
```
...for ignoring everything inside the `StrategicProject` folder, even `.tex` files, except for a few specific deeply nested `.tex` files.

Just using 
```
StrategicProject/*
!StrategicProject/SpecificProject1/Method1/doc/*.tex
```
does not work in git, because git "does not look in" ignored folders.

Although *solution 2*
```
StrategicProject/**
!StrategicProject/**/
!StrategicProject/SpecificProject1/Method1/doc/*.tex
```
and *solution 3*
```
StrategicProject/*
!StrategicProject/SpecificProject1/Method1/doc/*.tex

!*/ # on the last line of your .gitignore file: tell git to look in all folders, even ignored ones.
```
do work, they are not in all aspects better, because they perform less well (*solution 1* has the best performance, then *solution 2* and worst is *solution 3*).

The lines `!StrategicProject/**/` and `!*/` end with a slash and therefore only match folders and "include them" (well, not really, because only files can be tracked).
They do not result in including files, but they allow un-ignoring deeply nested files.

This repo contains the code and downloads (executable files) for creating the best performing *solution 1* with "just one line in a `.gitinclude` and a mouse click".

## How to use?

Create a `.gitinclude` file in the same folder as your `.gitignore` file
```
Folder/SubFolder/File.txt
Folder/*.cs # the order doesn't matter
```
Execute the app (via the console or double click, etc) for the folder that contains the `.gitinclude` and `.gitignore` (passing the folder path as argument or by executing it from that folder without argument).
Now, the `.gitignore` has a new section:
```
MyAlreadyIgnoredFolder

# .gitignore generated rules START
Folder/*
!Folder/*.cs
!Folder/SubFolder/
Folder/SubFolder/*
!Folder/SubFolder/File.txt
# .gitignore generated rules END
```
Executing the app again updates the `.gitignore` if needed.

## Downloads

| Platform | Self-contained (just works) | Requires .NET runtime (small file)
| --- | --- | --- |
| Windows-X64 | [download](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/windows/gitinclude.exe) | [download](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/windows/small-without-dotnet-runtime/gitinclude.exe)
| Linux-X64 | [download](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/linux/gitinclude) | [download](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/linux/small-without-dotnet-runtime/gitinclude)
| OSX-X64 | [download](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/osx/gitinclude) | [download](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/osx/small-without-dotnet-runtime/gitinclude)
